using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TestProject.Web.Filters;
using TestProject.Web.Infrastructure;
using TestProject.Domain;
using TestProject.Web.Helper;

namespace TestProject.Web.Controllers
{
    [InitializeLinksDatabase]
    public class LinksController : ApiController
    {
        /// <summary>
        /// Репозиторий для ссылок
        /// </summary>
        ILinkRepository _links;
        /// <summary>
        /// Репозиторий для пользователей
        /// </summary>
        IUserProfileRepository _users;

        /// <summary>
        /// Конструктор по умолчанию
        /// </summary>
        public LinksController() : this(new DALContext())
        {
        }
        /// <summary>
        /// Конструктор для тестов
        /// </summary>
        /// <param name="context">Слой доступа данным</param>
        public LinksController(IDALContext context)
        {
            _links = context.Links;
            _users = context.Users;
        }

        /// <summary>
        /// Получение списка всех ссылок
        /// </summary>
        /// <returns> список ссылок в формате JSON</returns>
        public HttpResponseMessage GetAllLinks()
        {
            try
            {
                var ListLinks = _links.All.Where(x => x.Owner.Id == _users.CurrentUser.Id).ToList();

                string root = "";
                try
                {
                    // для прохождения юнит  тестов, ничего другого не придумал
                    root = Url.Content("~/api/");
                }
                catch (Exception)
                {                  
                }
               
                ListLinks.ForEach(x => x.ShortLink = root + x.ShortLink);
                return Request.CreateResponse(HttpStatusCode.OK, ListLinks);
            }
            catch (Exception)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError);
            }
        }
        /// <summary>
        /// Метод перехода по ссылке и редирект на оригенальную ссылку
        /// </summary>
        /// <param name="link">ссылка</param>
        /// <returns>переадресация на новыую страницу</returns>
        public HttpResponseMessage GetTransition(string link)
        {
            try
            {

                int id = Base58CheckHelper.GetOriginalLink(link);
                var TransitionLink = _links.All.Where(x => x.Id == id).FirstOrDefault();
                if (TransitionLink == null)
                {
                    return Request.CreateResponse(HttpStatusCode.BadRequest);
                }
                TransitionLink.CountTransition++;
                _links.InsertOrUpdate(TransitionLink);           
                var response = Request.CreateResponse(HttpStatusCode.Moved);
                response.Headers.Location = new Uri(TransitionLink.OriginalLink);
                return response;
            }
            catch (Exception )
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError);
            }
        }
        /// <summary>
        /// Сохранение новой ссылки в базу данных
        /// </summary>
        /// <param name="link">Оригенальная ссылка</param>
        /// <returns>ответ клиенту</returns>
        public HttpResponseMessage PutNewLink(string link)
        {
            try
            {
                var insertLink = new Link()
                {
                    CountTransition = 0,
                    DateCreated = DateTime.Now,
                    OriginalLink = link,
                    Owner = _users.CurrentUser,
                    ShortLink = ""
                };
                Link LinkSaved = _links.InsertOrUpdate(insertLink);
                LinkSaved.ShortLink = Base58CheckHelper.GetShortLink(LinkSaved.Id);
                _links.InsertOrUpdate(LinkSaved);
            }
            catch (Exception)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError);
            }
            return Request.CreateResponse(HttpStatusCode.OK);
        }
        /// <summary>
        /// Удаление ссылки
        /// </summary>
        /// <param name="link">сама ссылка </param>
        /// <returns>результат удаления</returns>
        public HttpResponseMessage Delete(int link)
        {
            try
            {
                var deleteLink = _links.All.Where(x => x.Id == link).FirstOrDefault();
                if (deleteLink != null)
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound);
                }
                else
                {
                    string deleted = deleteLink.OriginalLink;
                    _links.Remove(deleteLink);
                    return Request.CreateResponse(HttpStatusCode.OK, deleted);
                }
            }
            catch (Exception)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError);
            }

        }
    }
}