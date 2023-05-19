using DapperServer.DataAccessLayer.Interfaces;
using DapperServer.DataAccessLayer.Data;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DapperServer.DataAccessLayer
{
    public static class DataConfiguration
    {
        public static void DataDependencies(IServiceCollection services)
        {
            services.AddTransient<IDbContext, DbContext>();
        }
    }
}
