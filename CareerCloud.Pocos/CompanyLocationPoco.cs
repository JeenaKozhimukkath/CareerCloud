using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CareerCloud.Pocos
{
    [Table("Company_Locations")]
    public class CompanyLocationPoco : IPoco
    {
        [Key]
        public Guid Id { get; set; }

        public Guid Company { get; set; }

        [Column("Country_Code")]
        public string CountryCode { get; set; }

        [Column("State_Province_Code")]
        public string StateProvinceCode { get; set; }

        [Column("Street_Address")]
        public string StreetAddress { get; set; }

        [Column("City_Town")]
        public string CityTown { get; set; }

        [Column("Zip_Postal_Code")]
        public string ZipPostalCode { get; set; }

        [Column("Time_Stamp")]
        public byte[] TimeStamp { get; set; }
    }
}
