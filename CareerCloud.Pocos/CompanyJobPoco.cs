using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CareerCloud.Pocos
{
    [Table("Company_Jobs")]
    public class CompanyJobPoco
    {
        [Key]
        public Guid Id { get; set; }
        public Guid Company { get; set; }

        [Column("Profile_Created")]
        public DateTime ProfileCreated { get; set; }

        [Column("Is_Inactive")]
        public Boolean IsInactive { get; set; }

        [Column("Is_Company_Hidden")]
        public Boolean IsCompanyHidden { get; set; }

        [Column("Time_Stamp")]
        public byte?[] TimeStamp { get; set; }
    }
}
