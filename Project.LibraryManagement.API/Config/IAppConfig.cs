using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project.LibraryManagement.API.Config
{
    public interface IAppConfig
    {
        string ConnectionString { get; }
    }
}
