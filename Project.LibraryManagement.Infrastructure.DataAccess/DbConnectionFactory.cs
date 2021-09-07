using System;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Threading;

namespace Project.LibraryManagement.Infrastructure.DataAccess
{
    public class DbConnectionFactory : IDbConnectionFactory
    {
        private readonly AsyncLocal<DbConnection> AsyncLocal = new();
        private readonly string _connectionString;
        private readonly object _lock = new();

        public DbConnectionFactory(string connectionString)
        {
            _connectionString = connectionString;
        }

        public DbConnection GetConnection()
        {
            if (IsConnectionStateOk())
            {
                return AsyncLocal.Value;
            }

            lock (_lock)
            {
                if (IsConnectionStateOk())
                {
                    return AsyncLocal.Value;
                }

                var sqlConnection = new SqlConnection(_connectionString);
                sqlConnection.Disposed += OnDisposed;
                sqlConnection.Open();
                AsyncLocal.Value = sqlConnection;
            }

            return AsyncLocal.Value;
        }

        private bool IsConnectionStateOk()
        {
            var dbConnection = AsyncLocal.Value;

            if (dbConnection == null)
            {
                return false;
            }

            return dbConnection.State != ConnectionState.Closed && dbConnection.State != ConnectionState.Broken;
        }

        private void OnDisposed(object sender, EventArgs e)
        {
            if (sender is not DbConnection dbConnection)
            {
                return;
            }

            dbConnection.Disposed -= OnDisposed;
            lock (_lock)
            {
                AsyncLocal.Value = null;
            }
        }
    }
}

