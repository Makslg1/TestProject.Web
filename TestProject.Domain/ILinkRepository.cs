using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject.Domain
{
    public interface ILinkRepository
    {
        IQueryable<Link> All { get; }  
        Link InsertOrUpdate(Link task);
        void Remove(Link task);
        void Save();
    }
}
