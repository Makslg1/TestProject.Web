using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using TestProject.Domain;

namespace TestProject.Web.Infrastructure
{
    public class LinkRepository : ILinkRepository
    {
        LinksDatabase _context;

        public LinkRepository(LinksDatabase context)
        {
            _context = context;
        }

        IQueryable<Link> ILinkRepository.All
        {
            get { return _context.Links; }
        }

        Link ILinkRepository.InsertOrUpdate(Link link)
        {
            if (link.Id == default(int))
            {
                _context.Links.Add(link);
            }
            else
            {
                _context.Entry(link).State = EntityState.Modified;
            }
            _context.SaveChanges();
            _context.Entry(link).GetDatabaseValues();
            return link;
        }

        void ILinkRepository.Remove(Link link)
        {
            _context.Entry(link).State = EntityState.Deleted;
            _context.SaveChanges();
        }

        void ILinkRepository.Save()
        {
            _context.SaveChanges();
        }
    }
}