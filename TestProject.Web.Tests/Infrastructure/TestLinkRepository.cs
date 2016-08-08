using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestProject.Domain;

namespace TestProject.Web.Tests.Infrastructure
{
    /// <summary>
    /// тестовый репозиторий для работы со ссылками
    /// </summary>
    class TestLinkRepository : ILinkRepository
    {
        private List<Link> _links = new List<Link>();
        public TestLinkRepository()
        {
            _links.Add(new Link {  CountTransition=0, Id=0, DateCreated=DateTime.Now, OriginalLink= "http://ya.ru/", Owner=new UserProfile {Id=0 , UserName="asdfa"} , ShortLink= "1111" });
        }
        public IQueryable<Link> All
        {
            get
            {
                return _links.AsQueryable();
            }
        }

        public Link InsertOrUpdate(Link link)
        {
            if (link.Id==default(int))
            {
                 link.Id = _links.Count;
                _links.Add(link);               
            }
            return link;
        }

        public void Remove(Link link)
        {
            _links.Remove(link);
        }

        public void Save()
        {            
        }
    }
}
