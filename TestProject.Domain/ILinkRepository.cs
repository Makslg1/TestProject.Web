using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject.Domain
{
    /// <summary>
    /// Интерфейс репозитория ссылки
    /// </summary>
    public interface ILinkRepository
    {
        IQueryable<Link> All { get; }  
        Link InsertOrUpdate(Link task);
        void Remove(Link task);
        void Save();
    }
}
