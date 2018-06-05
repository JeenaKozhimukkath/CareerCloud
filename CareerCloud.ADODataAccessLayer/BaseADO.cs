using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data.SqlClient;

namespace CareerCloud.ADODataAccessLayer
{
    public abstract class BaseADO
    {
        protected readonly SqlConnection _connection;
        public BaseADO()
        {
            _connection = new SqlConnection(ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString);
        }
    }
}
