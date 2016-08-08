using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestProject.Domain;

namespace TestProject.Web.Tests.Infrastructure
{
    /// <summary>
    /// реализация тестового слоя доступа к данным
    /// </summary>
    class TestDALContext : IDALContext
    {
        private static IUserProfileRepository _users = new TestUserRepository();
        private static ILinkRepository _links = new TestLinkRepository();

        public ILinkRepository Links
        {
            get
            {
                return _links;
            }
        }

        public IUserProfileRepository Users
        {
            get
            {
                return _users;
            }
        }
    }
}
