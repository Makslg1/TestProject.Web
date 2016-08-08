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
        ILinkRepository _links;
        IUserProfileRepository _users;
        public LinksController() : this(new DALContext())
        {
        }
        public LinksController(IDALContext context)
        {
            _links = context.Links;
            _users = context.Users;
        }

        public HttpResponseMessage GetAllLinks()
        {
            try
            {
                var ListLinks = _links.All.Where(x => x.Owner.Id == _users.CurrentUser.Id).ToList();
                ListLinks.ForEach(x => x.ShortLink = Url.Content("~/api/") + x.ShortLink);
                return Request.CreateResponse(HttpStatusCode.OK, ListLinks);
            }
            catch (Exception)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError);
            }
        }

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