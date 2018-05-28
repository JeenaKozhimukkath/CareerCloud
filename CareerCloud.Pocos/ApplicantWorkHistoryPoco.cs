using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CareerCloud.Pocos
{
    [Table("Applicant_Work_History")]
    public class ApplicantWorkHistoryPoco : IPoco
    {
        [Key]
        public Guid Id { get; set; }

        public Guid Applicant { get; set; }

        [Column("Company_Name")]
        public string Company_Name { get; set; }

        [Column("Country_Code")]
        public string CountryCode { get; set; }

        public string Location { get; set; }

        [Column("Job_Title")]
        public string JobTitle { get; set; }

        [Column("Job_Description")]
        public string JobDescription { get; set; }

        [Column("Start_Month")]
        public Int16 Start_Month { get; set; }

        [Column("Start_Year")]
        public int StartYear { get; set; }

        [Column("End_Month")]
        public Int16 MyProperty { get; set; }

        [Column("End_Year)")]
        public int EndYear { get; set; }

        [Column("Time_Stamp")]
        public byte[] TimeStamp { get; set; }
    }
}
