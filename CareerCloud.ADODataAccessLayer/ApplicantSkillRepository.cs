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
    class ApplicantSkillRepository : BaseADO, IDataRepository<ApplicantSkillPoco>
    {
        public void Add(params ApplicantSkillPoco[] items)
        {
            using (_connection)
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = _connection;

                foreach (ApplicantSkillPoco poco in items)
                {
                    cmd.CommandText = @"insert into Applicant_Skills
                                        (Id,Applicant,Skill,Skill_Level,Start_Month,Start_Year,End_Month,End_Year)
                                        values
                                        (@Id,@Applicant,@Skill,@Skill_Level,@Start_Month,@Start_Year,@End_Month,@End_Year)";
                    cmd.Parameters.AddWithValue("@Id", poco.Id);
                    cmd.Parameters.AddWithValue("@Applicant", poco.Applicant);
                    cmd.Parameters.AddWithValue("@Skill",poco.Skill);
                    cmd.Parameters.AddWithValue("@Skill_Level",poco.SkillLevel);
                    cmd.Parameters.AddWithValue("@Start_Month",poco.StartMonth);
                    cmd.Parameters.AddWithValue("@Start_Year", poco.StartYear);
                    cmd.Parameters.AddWithValue("@End_Month", poco.EndMonth);
                    cmd.Parameters.AddWithValue("@End_Year", poco.EndYear);
                   
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

        public IList<ApplicantSkillPoco> GetAll(params Expression<Func<ApplicantSkillPoco, object>>[] navigationProperties)
        {
            ApplicantSkillPoco[] pocos = new ApplicantSkillPoco[1000];

            using (_connection)
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = _connection;
                cmd.CommandText = "Select Id,Applicant,Skill,Skill_Level,Start_Month,Start_Year,End_Month,End_Year,Time_Stamp from Applicant_Skills";

                _connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                int position = 0;
                while (reader.Read())
                {
                    ApplicantSkillPoco poco = new ApplicantSkillPoco();

                    poco.Id = reader.GetGuid(0);
                    poco.Applicant = reader.GetGuid(1);
                    poco.Skill = reader[2].ToString();
                    poco.SkillLevel = reader[3].ToString();
                    poco.StartMonth = (byte)reader[4];
                    poco.StartYear = (int)reader[5];
                    poco.EndMonth = (byte)reader[6];
                    poco.EndYear= (int)reader[7];
                    poco.TimeStamp = (byte[])reader[8];

                    pocos[position] = poco;
                    position++;
                }
                _connection.Close();
            }

            return pocos;
        }

        public IList<ApplicantSkillPoco> GetList(Expression<Func<ApplicantSkillPoco, bool>> where, params Expression<Func<ApplicantSkillPoco, object>>[] navigationProperties)
        {
            throw new NotImplementedException();
        }

        public ApplicantSkillPoco GetSingle(Expression<Func<ApplicantSkillPoco, bool>> where, params Expression<Func<ApplicantSkillPoco, object>>[] navigationProperties)
        {
            IQueryable<ApplicantSkillPoco> pocos = GetAll().AsQueryable();
            return pocos.Where(where).FirstOrDefault();
        }

        public void Remove(params ApplicantSkillPoco[] items)
        {
            throw new NotImplementedException();
        }

        public void Update(params ApplicantSkillPoco[] items)
        {
            throw new NotImplementedException();
        }
    }
}
