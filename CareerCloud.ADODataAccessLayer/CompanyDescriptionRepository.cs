using System;
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
    public class CompanyDescriptionRepository : BaseADO, IDataRepository<CompanyDescriptionPoco>
    {
        public void Add(params CompanyDescriptionPoco[] items)
        {
            using (_connection)
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = _connection;

                int rowsEffected = 0;
                foreach (CompanyDescriptionPoco poco in items)
                {
                    cmd.CommandText = @"insert into Company_Descriptions
                                    (Id,Company,LanguageID,Company_Name,Company_Description)
                                    values
                                    (@Id,@Company,@LanguageID,@Company_Name,@Company_Description)";
                    cmd.Parameters.AddWithValue("@Id", poco.Id);
                    cmd.Parameters.AddWithValue("@Company", poco.Company);
                    cmd.Parameters.AddWithValue("@LanguageID", poco.LanguageId);
                    cmd.Parameters.AddWithValue("@Company_Name", poco.CompanyName);
                    cmd.Parameters.AddWithValue("@Company_Description", poco.CompanyDescription);
                   
                    _connection.Open();
                     rowsEffected += cmd.ExecuteNonQuery();
                    _connection.Close();
                }
            }
        }

        public void CallStoredProc(string name, params Tuple<string, string>[] parameters)
        {
            throw new NotImplementedException();
        }

        public IList<CompanyDescriptionPoco> GetAll(params Expression<Func<CompanyDescriptionPoco, object>>[] navigationProperties)
        {
            CompanyDescriptionPoco[] pocos = new CompanyDescriptionPoco[1000];
            SqlConnection _newconnection = new SqlConnection(ConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString); 
            using (_newconnection)
            {

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = _newconnection;
                cmd.CommandText = "Select Id,Company,LanguageID,Company_Name,Company_Description,Time_Stamp from Company_Descriptions";

                _newconnection.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                int position = 0;
                while (reader.Read())
                {
                    CompanyDescriptionPoco poco = new CompanyDescriptionPoco();

                    poco.Id = reader.GetGuid(0);
                    poco.Company = reader.GetGuid(1);
                    poco.LanguageId = reader.GetString(2);
                    poco.CompanyName = reader.GetString(3);
                    poco.CompanyDescription = reader.GetString(4);
                    poco.TimeStamp = (byte[])reader[5];

                    pocos[position] = poco;
                    position++;
                }
                _newconnection.Close();
            }

            return pocos;
        }

        public IList<CompanyDescriptionPoco> GetList(Expression<Func<CompanyDescriptionPoco, bool>> where, params Expression<Func<CompanyDescriptionPoco, object>>[] navigationProperties)
        {
            throw new NotImplementedException();
        }

        public CompanyDescriptionPoco GetSingle(Expression<Func<CompanyDescriptionPoco, bool>> where, params Expression<Func<CompanyDescriptionPoco, object>>[] navigationProperties)
        {
            IQueryable<CompanyDescriptionPoco> pocos = GetAll().AsQueryable();
            return pocos.Where(where).FirstOrDefault();
        }

        public void Remove(params CompanyDescriptionPoco[] items)
        {
            using (_connection)
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = _connection;

                foreach (CompanyDescriptionPoco poco in items)
                {
                    cmd.CommandText = @"delete from Company_Descriptions where Id=@Id";
                    cmd.Parameters.AddWithValue("@Id", poco.Id);

                    _connection.Open();
                    cmd.ExecuteNonQuery();
                    _connection.Close();
                }
            }
        }

        public void Update(params CompanyDescriptionPoco[] items)
        {
            using (_connection)
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = _connection;

                foreach (CompanyDescriptionPoco poco in items)
                {
                    cmd.CommandText = @"Update Company_Descriptions set
                                        Company=@Company,LanguageID=@LanguageID
                                        ,Company_Name=@Company_Name
                                        ,Company_Description=@Company_Description
                                        where Id=@Id";

                    cmd.Parameters.AddWithValue("@Id", poco.Id);
                    cmd.Parameters.AddWithValue("@Company", poco.Company);
                    cmd.Parameters.AddWithValue("@LanguageID", poco.LanguageId);
                    cmd.Parameters.AddWithValue("@Company_Name", poco.CompanyName);
                    cmd.Parameters.AddWithValue("@Company_Description", poco.CompanyDescription);

                    _connection.Open();
                     cmd.ExecuteNonQuery();
                    _connection.Close();
                }
            }
         }
    }
}
