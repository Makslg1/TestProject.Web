using System;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Threading;
using System.Web.Mvc;
using TestProject.Domain;
using TestProject.Web.Infrastructure;

namespace TestProject.Web.Filters
{
    /// <summary>
    /// Фильтр по созданию базы данных при первом запуске. 
    /// </summary>
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = false, Inherited = true)]
    public class InitializeLinksDatabaseAttribute : ActionFilterAttribute
    {
        private static LinksDatabaseInitializer _initializer;
        private static object _initializerLock = new object();
        private static bool _isInitialized;

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            LazyInitializer.EnsureInitialized(ref _initializer, ref _isInitialized, ref _initializerLock);
        }
        private class LinksDatabaseInitializer
        {
            public LinksDatabaseInitializer()
            {
                Database.SetInitializer<LinksDatabase>(null);
                try
                {
                    using (var context = new LinksDatabase())
                    {
                        if (!context.Database.Exists())
                        {
                            ((IObjectContextAdapter)context).ObjectContext.CreateDatabase();
                        }

                    }
                }
                catch (Exception ex)
                {
                    throw new InvalidOperationException("База данных не может  быть инициализирована. Проверьте строку подключение в config файле", ex);
                }
            }
        }

    }

}