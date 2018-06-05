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
    class ApplicantWorkHistoryRepository : BaseADO, IDataRepository<ApplicantWorkHistoryPoco>
    {
        public void Add(params ApplicantWorkHistoryPoco[] items)
        {
            throw new NotImplementedException();
        }

        public void CallStoredProc(string name, params Tuple<string, string>[] parameters)
        {
            throw new NotImplementedException();
        }

        public IList<ApplicantWorkHistoryPoco> GetAll(params Expression<Func<ApplicantWorkHistoryPoco, object>>[] navigationProperties)
        {
            throw new NotImplementedException();
        }

        public IList<ApplicantWorkHistoryPoco> GetList(Expression<Func<ApplicantWorkHistoryPoco, bool>> where, params Expression<Func<ApplicantWorkHistoryPoco, object>>[] navigationProperties)
        {
            throw new NotImplementedException();
        }

        public ApplicantWorkHistoryPoco GetSingle(Expression<Func<ApplicantWorkHistoryPoco, bool>> where, params Expression<Func<ApplicantWorkHistoryPoco, object>>[] navigationProperties)
        {
            throw new NotImplementedException();
        }

        public void Remove(params ApplicantWorkHistoryPoco[] items)
        {
            throw new NotImplementedException();
        }

        public void Update(params ApplicantWorkHistoryPoco[] items)
        {
            throw new NotImplementedException();
        }
    }
}
