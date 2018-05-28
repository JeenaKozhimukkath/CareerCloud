using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CareerCloud.Pocos
{
    [Table("Company_Profiles")]
    public class CompanyProfilePoco : IPoco
    {
        [Key]
        public Guid Id { get; set; }

        public DateTime Registration { get; set; }

        [Column("Company_Website")]
        public string CompanyWebsite { get; set; }

        [Column("Contact_Phone")]
        public string ContactPhone { get; set; }

        [Column("Contact_Name")]
        public string ContactName { get; set; }

        [Column("Company_Logo")]
        public byte[] CompanyLogo { get; set; }

        [Column("Time_Stamp")]
        public byte?[] TimeStamp { get; set; }
    }
}
