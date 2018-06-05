using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CareerCloud.DataAccessLayer;
using CareerCloud.Pocos;
using System.Data.SqlClient;
using System.Linq.Expressions;

namespace CareerCloud.ADODataAccessLayer 
{
    class CompanyJobRepository : BaseADO, IDataRepository<CompanyJobPoco>
    {
        public void Add(params CompanyJobPoco[] items)
        {
            throw new NotImplementedException();
        }

        public void CallStoredProc(string name, params Tuple<string, string>[] parameters)
        {
            throw new NotImplementedException();
        }

        public IList<CompanyJobPoco> GetAll(params Expression<Func<CompanyJobPoco, object>>[] navigationProperties)
        {
            throw new NotImplementedException();
        }

        public IList<CompanyJobPoco> GetList(Expression<Func<CompanyJobPoco, bool>> where, params Expression<Func<CompanyJobPoco, object>>[] navigationProperties)
        {
            throw new NotImplementedException();
        }

        public CompanyJobPoco GetSingle(Expression<Func<CompanyJobPoco, bool>> where, params Expression<Func<CompanyJobPoco, object>>[] navigationProperties)
        {
            throw new NotImplementedException();
        }

        public void Remove(params CompanyJobPoco[] items)
        {
            throw new NotImplementedException();
        }

        public void Update(params CompanyJobPoco[] items)
        {
            throw new NotImplementedException();
        }
    }
}
