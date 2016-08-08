using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject.Domain
{
    public interface IDALContext
    {
        IUserProfileRepository Users { get; }
        ILinkRepository Links { get; }
    }
}
