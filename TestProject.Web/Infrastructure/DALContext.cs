using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TestProject.Domain;

namespace TestProject.Web.Infrastructure
{
    /// <summary>
    /// Реализация интерфейса слоя доступа к данным
    /// </summary>
    public class DALContext : IDALContext
    {
        LinksDatabase _database;
        IUserProfileRepository _users;
        ILinkRepository _links;

        public DALContext()
        {
            _database = new LinksDatabase();
        }

        public IUserProfileRepository Users
        {
            get
            {
                if (_users == null)
                {
                    _users = new UserRespository(_database);
                }
                return _users;
            }
        }

        public ILinkRepository Links
        {
            get
            {
                if (_links == null)
                {
                    _links = new LinkRepository(_database);
                }
                return _links;
            }
        }
    }
}