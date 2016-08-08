using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TestProject.Web.Filters;
using TestProject.Web.Infrastructure;
using TestProject.Domain;


namespace TestProject.Web.Controllers
{
    public class HomeController : Controller
    {
        /// <summary>
        /// Главная страница
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            return View();
        }
        /// <summary>
        /// Страница со списком ссылок
        /// </summary>
        /// <returns></returns>
        public ActionResult Details()
        {
            return View();
        }
    }
}