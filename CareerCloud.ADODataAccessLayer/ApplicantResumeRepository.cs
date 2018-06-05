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
    class ApplicantResumeRepository : BaseADO, IDataRepository<ApplicantResumePoco>
    {
        public void Add(params ApplicantResumePoco[] items)
        {
            using (_connection)
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = _connection;

                foreach (ApplicantResumePoco poco in items)
                {
                    cmd.CommandText = @"insert into Applicant_Resumes
                                    (Id,Applicant,Resume,Last_Updated)
                                    values
                                    (@Id,@Applicant,@Resume,@Last_Updated)";
                    cmd.Parameters.AddWithValue("@Id", poco.Id);
                    cmd.Parameters.AddWithValue("@Applicant",poco.Applicant);
                    cmd.Parameters.AddWithValue("@Resume",poco.Resume);
                    cmd.Parameters.AddWithValue("@Last_Updated",poco.LastUpdated);

                    _connection.Open();
                    int rowsEffected = cmd.ExecuteNonQuery();
                    _connection.Close();
                }
            }
        }

        public void CallStoredProc(string name, params Tuple<string, string>[] parameters)
        {
            throw new NotImplementedException();
        }

        public IList<ApplicantResumePoco> GetAll(params Expression<Func<ApplicantResumePoco, object>>[] navigationProperties)
        {
            ApplicantResumePoco[] pocos = new ApplicantResumePoco[1000];

            using (_connection)
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = _connection;
                cmd.CommandText = "Select Id,Applicant,Resume,Last_Updated from Applicant_Resumes";

                _connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                int position = 0;
                while (reader.Read())
                {
                    ApplicantResumePoco poco = new ApplicantResumePoco();

                    poco.Id = reader.GetGuid(0);
                    poco.Applicant = reader.GetGuid(1);
                    poco.Resume = reader[2].ToString();
                    poco.LastUpdated = (DateTime?)reader[3];

                    pocos[position] = poco;
                    position++;
                }
                _connection.Close();
            }

            return pocos;
        }

        public IList<ApplicantResumePoco> GetList(Expression<Func<ApplicantResumePoco, bool>> where, params Expression<Func<ApplicantResumePoco, object>>[] navigationProperties)
        {
            throw new NotImplementedException();
        }

        public ApplicantResumePoco GetSingle(Expression<Func<ApplicantResumePoco, bool>> where, params Expression<Func<ApplicantResumePoco, object>>[] navigationProperties)
        {
            throw new NotImplementedException();
        }

        public void Remove(params ApplicantResumePoco[] items)
        {
            throw new NotImplementedException();
        }

        public void Update(params ApplicantResumePoco[] items)
        {
            throw new NotImplementedException();
        }
    }
}
