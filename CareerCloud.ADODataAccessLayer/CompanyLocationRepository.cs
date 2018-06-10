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
    public class CompanyLocationRepository : BaseADO, IDataRepository<CompanyLocationPoco>
    {
        public void Add(params CompanyLocationPoco[] items)
        {
            using (_connection)
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = _connection;

                int rowsEffected = 0;
                foreach (CompanyLocationPoco poco in items)
                {
                    cmd.CommandText = @"insert into Company_Locations
                                    (Id,Company,Country_Code,State_Province_Code,Street_Address,City_Town,Zip_Postal_Code)
                                    values
                                    (@Id,@Company,@Country_Code,@State_Province_Code,@Street_Address,@City_Town,@Zip_Postal_Code)";
                    cmd.Parameters.AddWithValue("@Id", poco.Id);
                    cmd.Parameters.AddWithValue("@Company", poco.Company);
                    cmd.Parameters.AddWithValue("@Country_Code", poco.CountryCode);
                    cmd.Parameters.AddWithValue("@State_Province_Code", poco.Province);
                    cmd.Parameters.AddWithValue("@Street_Address", poco.Street);
                    cmd.Parameters.AddWithValue("@City_Town", poco.City);
                    cmd.Parameters.AddWithValue("@Zip_Postal_Code", poco.PostalCode);

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

        public IList<CompanyLocationPoco> GetAll(params Expression<Func<CompanyLocationPoco, object>>[] navigationProperties)
        {
            CompanyLocationPoco[] pocos = new CompanyLocationPoco[1000];

            using (_connection)
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = _connection;
                cmd.CommandText = "Select Id,Company,Country_Code,State_Province_Code,Street_Address,City_Town,Zip_Postal_Code,Time_Stamp from Company_Locations";

                _connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                int position = 0;
                while (reader.Read())
                {
                    CompanyLocationPoco poco = new CompanyLocationPoco();

                    poco.Id = reader.GetGuid(0);
                    poco.Company = reader.GetGuid(1);
                    poco.CountryCode = reader.GetString(2);
                    poco.Province = reader.GetString(3);
                    poco.Street = reader.GetString(4);
                    poco.City = reader.GetString(5);
                    poco.PostalCode = reader.GetString(6);
                    poco.TimeStamp = (byte[])reader[7];

                    pocos[position] = poco;
                    position++;
                }
                _connection.Close();
            }

            return pocos;
        }

        public IList<CompanyLocationPoco> GetList(Expression<Func<CompanyLocationPoco, bool>> where, params Expression<Func<CompanyLocationPoco, object>>[] navigationProperties)
        {
            throw new NotImplementedException();
        }

        public CompanyLocationPoco GetSingle(Expression<Func<CompanyLocationPoco, bool>> where, params Expression<Func<CompanyLocationPoco, object>>[] navigationProperties)
        {
            IQueryable<CompanyLocationPoco> pocos = GetAll().AsQueryable();
            return pocos.Where(where).FirstOrDefault();
        }

        public void Remove(params CompanyLocationPoco[] items)
        {
            throw new NotImplementedException();
        }

        public void Update(params CompanyLocationPoco[] items)
        {
            throw new NotImplementedException();
        }
    }
}
