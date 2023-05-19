using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DapperServer.DataAccessLayer.Implementation
{
    public class RepositoryBase
    {
        protected IDbTransaction Transaction { get; private set; }
        protected IDbConnection Connection { get; private set; }

        public RepositoryBase(IDbTransaction transaction, IDbConnection connection)
        {
            if (transaction != null)
                Connection = transaction.Connection;
            else
                Connection = connection;

            Transaction = transaction;
        }
    }
}
