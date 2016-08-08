using Microsoft.VisualStudio.TestTools.UnitTesting;
using TestProject.Web.Controllers;
using TestProject.Web.Tests.Infrastructure;
using System.Net.Http;
using System.Collections.Generic;
using TestProject.Domain;
using System.Web.Http.Results;
using TestProject.Web;


namespace TestProject.Web.Tests.Controllers
{
    [TestClass]
    public class LinksControllerTest
    {
        LinksController controller;
        [TestInitialize]
        public void InitializeController()
        {
            controller = new LinksController(new TestDALContext());
            controller.Request = new HttpRequestMessage();
            controller.Configuration = new System.Web.Http.HttpConfiguration();
        }
        /// <summary>
        /// Проверка метода возвращающего весь список ссылок
        /// </summary>
        [TestMethod]
        public void ApiGetAllLinks()
        {

            var response = controller.GetAllLinks();
            List<Link> testlink;
            response.TryGetContentValue(out testlink);
            Assert.IsTrue(testlink.Count == 1);
        }

        /// <summary>
        /// проверка метода передресации
        /// </summary>
        [TestMethod]
        public void ApiGetTransition()
        {
     
            var response = controller.GetTransition("1111");
            if (response.StatusCode==System.Net.HttpStatusCode.Moved) {
                Assert.IsTrue(response.Headers.Location.AbsoluteUri == "http://ya.ru/","Не переходит по ссылке");
                response = controller.GetAllLinks();
                List<Link> testlink;
                response.TryGetContentValue(out testlink);
                Assert.IsTrue(testlink[0].CountTransition == 1, "Не увеличивается счетчик");
            }
        }
        /// <summary>
        /// проверка метода вставки новый ссылки
        /// </summary>
        [TestMethod]
        public void ApiPutNewLink()
        {
            var response = controller.PutNewLink("http://www.asp.net/");
            if (response.IsSuccessStatusCode)
            {
                response= controller.GetAllLinks();
                List<Link> testlink;
                response.TryGetContentValue(out testlink);
                int LastId = testlink.Count - 1;
                Assert.IsTrue(testlink[LastId] .ShortLink==Helper.Base58CheckHelper.GetShortLink(LastId) ,"Не работает кодировка Url");
            }
            else {
                Assert.Fail("Не удалось вставить ссылку в базу");
            }
            
        }
    }
}
