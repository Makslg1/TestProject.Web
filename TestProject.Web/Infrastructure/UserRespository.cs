using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using TestProject.Domain;

namespace TestProject.Web.Infrastructure
{
    /// <summary>
    /// Репозиторий для работы с пользователями
    /// </summary>
    public class UserRespository : IUserProfileRepository
    {
        LinksDatabase _context;

        public UserRespository(LinksDatabase context)
        {
            _context = context;
        }

        IQueryable<UserProfile> IUserProfileRepository.All
        {
            get
            {
                return _context.UserProfiles;
            }
        }

        UserProfile IUserProfileRepository.CurrentUser
        {
            get
            {
                //В базе данных нам нужен только один пользователь.           
                if (_context.UserProfiles.Count() == 0)
                {
                    _context.UserProfiles.Add(new UserProfile { UserName = "User" });
                    _context.SaveChanges();
                }
                return _context
                    .UserProfiles
                    .FirstOrDefault();
            }
        }

        void IUserProfileRepository.InsertOrUpdate(UserProfile user)
        {
            if (user.Id == default(int))
            {
                _context.UserProfiles.Add(user);
            }
            else
            {
                _context.Entry(user).State = EntityState.Modified;
            }
            _context.SaveChanges();
        }

        void IUserProfileRepository.Remove(UserProfile user)
        {
            _context.Entry(user).State = EntityState.Deleted;

        }

        void IUserProfileRepository.Save()
        {
            _context.SaveChanges();
        }
    }
}