using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject.Domain
{
    /// <summary>
    /// Интерфейс слоя доступа к данным
    /// </summary>
    public interface IDALContext
    {
        IUserProfileRepository Users { get; }
        ILinkRepository Links { get; }
    }
}
