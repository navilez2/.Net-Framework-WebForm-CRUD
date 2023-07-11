using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace DataBase
{
    internal class DataBase
    {
        public DataBase() { }

        internal string GetConnectionString(string dataBaseName)
        {
            return ConfigurationManager.ConnectionStrings[dataBaseName].ConnectionString.ToString();
        }
    }
}
