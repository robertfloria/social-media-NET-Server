using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DapperServer.Common.Settings
{
    public class AppSettings
    {
        public string IsDevelopment { get; set; }
        public string Environment { get; set; }
        public string Secret { get; set; }
        public string DatabaseConnectionString { get; set; }
    }
}
