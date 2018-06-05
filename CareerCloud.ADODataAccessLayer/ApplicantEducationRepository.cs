
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using CareerCloud.DataAccessLayer;
using CareerCloud.Pocos;
using System.Data.SqlClient;

namespace CareerCloud.ADODataAccessLayer
{
    class ApplicantEducationRepository : BaseADO, IDataRepository<ApplicantEducationPoco>
    {
        public void Add(params ApplicantEducationPoco[] items)
        {
            using (_connection)
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = _connection;

                foreach (ApplicantEducationPoco poco in items)
                {
                    cmd.CommandText = @"insert into Applicant_Educations
                                    (Id,Applicant,Major,Certificate_Diploma,Start_Date,Completion_Date,Completion_Percent)
                                    values
                                    (@Id,@Applicant,@Major,@Certificate_Diploma,@Start_Date,@Completion_Date,@Completion_Percent)";
                    cmd.Parameters.AddWithValue("@Id", poco.Id);
                    cmd.Parameters.AddWithValue("@Applicant", poco.Applicant);
                    cmd.Parameters.AddWithValue("@Major", poco.Major);
                    cmd.Parameters.AddWithValue("@Certificate_Diploma", poco.CertificateDiploma);
                    cmd.Parameters.AddWithValue("@Start_Date", poco.StartDate);
                    cmd.Parameters.AddWithValue("@Completion_Date", poco.CompletionDate);
                    cmd.Parameters.AddWithValue("@Completion_Percent", poco.CompletionPercent);

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

        public IList<ApplicantEducationPoco> GetAll(params Expression<Func<ApplicantEducationPoco, object>>[] navigationProperties)
        {
            ApplicantEducationPoco[] pocos = new ApplicantEducationPoco[1000];

            using (_connection)
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = _connection;
                cmd.CommandText = "Select Id,Applicant,Major,Certificate_Diploma,Start_Date,Completion_Date,Completion_Percent,TimeStamp from Application_Educations";

                _connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                int position = 0;
                while (reader.Read())
                {
                    ApplicantEducationPoco poco = new ApplicantEducationPoco();

                    poco.Id = reader.GetGuid(0);
                    poco.Applicant= reader.GetGuid(1);
                    poco.Major =reader.GetString(2);
                    poco.CertificateDiploma =reader.GetString(3);
                    poco.StartDate =(DateTime?)reader[4];
                    poco.CompletionDate = (DateTime?)reader[5];
                    poco.CompletionPercent =(byte?)reader[6];
                    poco.TimeStamp =(byte[])reader[7];

                    pocos[position] = poco;
                    position++;
                }
                _connection.Close();
            }

            return pocos;
        }

        public IList<ApplicantEducationPoco> GetList(Expression<Func<ApplicantEducationPoco, bool>> where, params Expression<Func<ApplicantEducationPoco, object>>[] navigationProperties)
        {
            throw new NotImplementedException();
        }

        public ApplicantEducationPoco GetSingle(Expression<Func<ApplicantEducationPoco, bool>> where, params Expression<Func<ApplicantEducationPoco, object>>[] navigationProperties)
        {
            IQueryable<ApplicantEducationPoco> pocos = GetAll().AsQueryable();
            return pocos.Where(where).FirstOrDefault();
        }

        public void Remove(params ApplicantEducationPoco[] items)
        {
            throw new NotImplementedException();
        }

        public void Update(params ApplicantEducationPoco[] items)
        {
            throw new NotImplementedException();
        }
    }
}
