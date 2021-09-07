using System;
using System.Data.Common;

namespace Project.LibraryManagement.Infrastructure.DataAccess
{
    public interface IDbConnectionFactory
    {
        DbConnection GetConnection();
    }
}
