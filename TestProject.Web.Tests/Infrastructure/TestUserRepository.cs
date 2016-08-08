using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestProject.Domain;

namespace TestProject.Web.Tests.Infrastructure
{
    class TestUserRepository : IUserProfileRepository
    {
        private List<UserProfile> _users = new List<UserProfile>();
        public TestUserRepository()
        {
            _users.Add(new UserProfile() { Id = 0, UserName = "User1", Links = new List<Link>() });

        }

        public IQueryable<UserProfile> All
        {
            get { return _users.AsQueryable(); }
        }

        public UserProfile CurrentUser
        {
            get { return _users[0]; }
        }

        public void InsertOrUpdate(UserProfile user)
        {
            throw new NotImplementedException();
        }

        public void Remove(UserProfile user)
        {
            throw new NotImplementedException();
        }

        public void Save()
        {
            throw new NotImplementedException();
        }
    }
}
