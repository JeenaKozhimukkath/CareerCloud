﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CareerCloud.DataAccessLayer;
using CareerCloud.Pocos;
using System.Data.SqlClient;
using System.Linq.Expressions;
using System.Configuration;

namespace CareerCloud.ADODataAccessLayer
{
    public class CompanyJobDescriptionRepository : BaseADO, IDataRepository<CompanyJobDescriptionPoco>
    {
        public void Add(params CompanyJobDescriptionPoco[] items)
        {
            SqlConnection connection = new SqlConnection(_ConnectionStr);
            using (connection)
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = connection;

                int rowsEffected = 0;
                foreach (CompanyJobDescriptionPoco poco in items)
                {
                    cmd.CommandText = @"insert into Company_Jobs_Descriptions
                                    (Id,Job,Job_Name,Job_Descriptions)
                                    values
                                    (@Id,@Job,@Job_Name,@Job_Descriptions)";
                    cmd.Parameters.AddWithValue("@Id", poco.Id);
                    cmd.Parameters.AddWithValue("@Job", poco.Job);
                    cmd.Parameters.AddWithValue("@Job_Name", poco.JobName);
                    cmd.Parameters.AddWithValue("@Job_Descriptions", poco.JobDescriptions);
                    

                    connection.Open();
                    rowsEffected += cmd.ExecuteNonQuery();
                    connection.Close();
                }
            }
        }

        public void CallStoredProc(string name, params Tuple<string, string>[] parameters)
        {
            throw new NotImplementedException();
        }

        public IList<CompanyJobDescriptionPoco> GetAll(params Expression<Func<CompanyJobDescriptionPoco, object>>[] navigationProperties)
        {
            CompanyJobDescriptionPoco[] pocos = new CompanyJobDescriptionPoco[1010];
            SqlConnection connection = new SqlConnection(_ConnectionStr);
            using (connection)
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = connection;
                cmd.CommandText = "Select Id,Job,Job_Name,Job_Descriptions,Time_Stamp from Company_Jobs_Descriptions";

                connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                int position = 0;
                while (reader.Read())
                {
                    CompanyJobDescriptionPoco poco = new CompanyJobDescriptionPoco();

                    poco.Id = reader.GetGuid(0);
                    poco.Job = reader.GetGuid(1);
                    poco.JobName = reader.IsDBNull(2) ? null : reader.GetString(2);
                    poco.JobDescriptions = reader.IsDBNull(3) ? null : reader.GetString(3);
                    poco.TimeStamp = (byte[])reader[4];

                    pocos[position] = poco;
                    position++;
                }
                connection.Close();
            }

            return pocos.Where(p => p != null).ToList();
        }

        public IList<CompanyJobDescriptionPoco> GetList(Expression<Func<CompanyJobDescriptionPoco, bool>> where, params Expression<Func<CompanyJobDescriptionPoco, object>>[] navigationProperties)
        {
            throw new NotImplementedException();
        }

        public CompanyJobDescriptionPoco GetSingle(Expression<Func<CompanyJobDescriptionPoco, bool>> where, params Expression<Func<CompanyJobDescriptionPoco, object>>[] navigationProperties)
        {
            IQueryable<CompanyJobDescriptionPoco> pocos = GetAll().AsQueryable();
            return pocos.Where(where).FirstOrDefault();
        }

        public void Remove(params CompanyJobDescriptionPoco[] items)
        {
            SqlConnection connection = new SqlConnection(_ConnectionStr);
            using (connection)
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = connection;

                foreach (CompanyJobDescriptionPoco poco in items)
                {
                    cmd.CommandText = @"delete from Company_Jobs_Descriptions where Id=@Id";
                    cmd.Parameters.AddWithValue("@Id", poco.Id);

                    connection.Open();
                    cmd.ExecuteNonQuery();
                    connection.Close();
                }
            }
        }

        public void Update(params CompanyJobDescriptionPoco[] items)
        {
            SqlConnection connection = new SqlConnection(_ConnectionStr);
            using (connection)
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = connection;

                foreach (CompanyJobDescriptionPoco poco in items)
                {
                    cmd.CommandText = @"Update Company_Jobs_Descriptions set
                                        Job=@Job,Job_Name=@Job_Name,Job_Descriptions=@Job_Descriptions
                                        where Id=@Id";

                    cmd.Parameters.AddWithValue("@Job", poco.Job);
                    cmd.Parameters.AddWithValue("@Job_Name", poco.JobName);
                    cmd.Parameters.AddWithValue("@Job_Descriptions", poco.JobDescriptions);
                    cmd.Parameters.AddWithValue("@Id", poco.Id);

                    connection.Open();
                    cmd.ExecuteNonQuery();
                    connection.Close();
                }
            }
        }
    }
}
