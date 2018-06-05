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
    class ApplicantProfileRepository : BaseADO, IDataRepository<ApplicantProfilePoco>
    {
        public void Add(params ApplicantProfilePoco[] items)
        {
            using (_connection)
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = _connection;

                foreach (ApplicantProfilePoco poco in items)
                {
                    cmd.CommandText = @"insert into Applicant_Profiles
                                    (Id,Login,Current_Salary,Current_Rate,Currency,Country_Code,State_Province_Code,Street_Address,City_Town,Zip_Postal_Code)
                                    values
                                    (@Id,@Login,@Current_Salary,@Current_Rate,@Currency,@Country_Code,@State_Province_Code,@Street_Address,@City_Town,@Zip_Postal_Code)";
                    cmd.Parameters.AddWithValue("@Id", poco.Id);
                    cmd.Parameters.AddWithValue("@Login", poco.Login);
                    cmd.Parameters.AddWithValue("@Current_Salary", poco.CurrentSalary);
                    cmd.Parameters.AddWithValue("@Current_Rate", poco.CurrentRate);
                    cmd.Parameters.AddWithValue("@Currency", poco.Currency);
                    cmd.Parameters.AddWithValue("@Country_Code", poco.Country);
                    cmd.Parameters.AddWithValue("@State_Province_Code", poco.Province);
                    cmd.Parameters.AddWithValue("@Street_Address", poco.Street);
                    cmd.Parameters.AddWithValue("@City_Town", poco.City);
                    cmd.Parameters.AddWithValue("@Zip_Postal_Code", poco.PostalCode);
                    

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

        public IList<ApplicantProfilePoco> GetAll(params Expression<Func<ApplicantProfilePoco, object>>[] navigationProperties)
        {
            ApplicantProfilePoco[] pocos = new ApplicantProfilePoco[1000];

            using (_connection)
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = _connection;
                cmd.CommandText = "Select Id,Login,Current_Salary,Current_Rate,Currency,Country_Code,State_Province_Code,Street_Address,City_Town,Zip_Postal_Code,Time_Stamp from Applicant_Profiles";

                _connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                int position = 0;
                while (reader.Read())
                {
                    ApplicantProfilePoco poco = new ApplicantProfilePoco();

                    poco.Id = reader.GetGuid(0);
                    poco.Login = reader.GetGuid(1);
                    poco.CurrentSalary = (decimal?)reader[2];
                    poco.CurrentRate = (decimal?)reader[3];
                    poco.Currency = reader.GetString(4);
                    poco.Country= reader.GetString(5);
                    poco.Province= reader.GetString(6);
                    poco.Street= reader.GetString(7);
                    poco.City= reader.GetString(8);
                    poco.PostalCode= reader.GetString(9);
                    poco.TimeStamp= (byte[])reader[10];
                    pocos[position] = poco;
                    position++;
                }
                _connection.Close();
            }

            return pocos;
        }

        public IList<ApplicantProfilePoco> GetList(Expression<Func<ApplicantProfilePoco, bool>> where, params Expression<Func<ApplicantProfilePoco, object>>[] navigationProperties)
        {
            throw new NotImplementedException();
        }

        public ApplicantProfilePoco GetSingle(Expression<Func<ApplicantProfilePoco, bool>> where, params Expression<Func<ApplicantProfilePoco, object>>[] navigationProperties)
        {
            IQueryable<ApplicantProfilePoco> pocos = GetAll().AsQueryable();
            return pocos.Where(where).FirstOrDefault();
        }

        public void Remove(params ApplicantProfilePoco[] items)
        {
            throw new NotImplementedException();
        }

        public void Update(params ApplicantProfilePoco[] items)
        {
            throw new NotImplementedException();
        }
    }
}
