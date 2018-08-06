using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using CareerCloud.Pocos;

namespace CareerCloud.EntityFrameworkDataAccess
{
    public class CareerCloudContext : DbContext
    {
        public CareerCloudContext() : base(@"Data Source=JEENA\HUMBERBRIDGING;Initial Catalog=JOB_PORTAL_DB;Integrated Security=True;User ID=sa;Password=********;")
        {
            var ensureDLLIsCopied =
               System.Data.Entity.SqlServer.SqlProviderServices.Instance;
        }

        public DbSet<ApplicantEducationPoco> ApplicantEducations { get; set; }
        public DbSet<ApplicantJobApplicationPoco> ApplicantJobApplications { get; set; }
        public DbSet<ApplicantProfilePoco> ApplicantProfiles { get; set; }
        public DbSet<ApplicantResumePoco> ApplicantResumes { get; set; }
        public DbSet<ApplicantSkillPoco> ApplicantSkills { get; set; }
        public DbSet<ApplicantWorkHistoryPoco> ApplicantWorkHistory { get; set; }
        public DbSet<CompanyDescriptionPoco> CompanyDescriptions { get; set; }
        public DbSet<CompanyJobDescriptionPoco> CompanyJobDescriptions { get; set; }
        public DbSet<CompanyJobEducationPoco> CompanyJobEducations { get; set; }
        public DbSet<CompanyJobPoco> CompanyJobs { get; set; }
        public DbSet<CompanyLocationPoco> CompanyLocations { get; set; }
        public DbSet<CompanyProfilePoco> CompanyProfiles { get; set; }
        public DbSet<SecurityLoginPoco> SecurityLogins { get; set; }
        public DbSet<SecurityLoginsLogPoco> SecurityLoginsLogs { get; set; }
        public DbSet<SecurityLoginsRolePoco> SecurityLoginsRoles { get; set; }
        public DbSet<SecurityRolePoco> SecurityRoles { get; set; }
        public DbSet<SystemCountryCodePoco> SystemCountryCodes { get; set; }
        public DbSet<SystemLanguageCodePoco> SystemLanguageCodes { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ApplicantEducationPoco>()
                .Property(e => e.TimeStamp)
                .IsFixedLength();
            modelBuilder.Entity<ApplicantJobApplicationPoco>()
               .Property(e => e.TimeStamp)
               .IsFixedLength();
            modelBuilder.Entity<ApplicantProfilePoco>()
               .Property(e => e.TimeStamp)
               .IsFixedLength();
            modelBuilder.Entity<ApplicantSkillPoco>()
                .Property(e => e.TimeStamp)
                .IsFixedLength();
            modelBuilder.Entity<ApplicantWorkHistoryPoco>()
               .Property(e => e.TimeStamp)
               .IsFixedLength();
            modelBuilder.Entity<CompanyDescriptionPoco>()
               .Property(e => e.TimeStamp)
               .IsFixedLength();
            modelBuilder.Entity<CompanyJobEducationPoco>()
                .Property(e => e.TimeStamp)
                .IsFixedLength();
            modelBuilder.Entity<CompanyJobPoco>()
               .Property(e => e.TimeStamp)
               .IsFixedLength();
            modelBuilder.Entity<CompanyJobSkillPoco>()
               .Property(e => e.TimeStamp)
               .IsFixedLength();
            modelBuilder.Entity<CompanyJobDescriptionPoco>()
                .Property(e => e.TimeStamp)
                .IsFixedLength();
            modelBuilder.Entity<CompanyLocationPoco>()
               .Property(e => e.TimeStamp)
               .IsFixedLength();
            modelBuilder.Entity<CompanyProfilePoco>()
               .Property(e => e.TimeStamp)
               .IsFixedLength();
            modelBuilder.Entity<SecurityLoginPoco>()
                .Property(e => e.TimeStamp)
                .IsFixedLength();
            modelBuilder.Entity<SecurityLoginsRolePoco>()
               .Property(e => e.TimeStamp)
               .IsFixedLength();
            


            modelBuilder.Entity<ApplicantProfilePoco>()
                .HasMany(e => e.ApplicantEducations)
                .WithRequired(e => e.ApplicantProfiles)
                .HasForeignKey(e => e.Applicant)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ApplicantProfilePoco>()
               .HasMany(e => e.ApplicantJobApplications)
               .WithRequired(e => e.ApplicantProfiles)
               .HasForeignKey(e => e.Applicant)
               .WillCascadeOnDelete(false);

            modelBuilder.Entity<ApplicantProfilePoco>()
              .HasMany(e => e.ApplicantResumes)
              .WithRequired(e => e.ApplicantProfiles)
              .HasForeignKey(e => e.Applicant)
              .WillCascadeOnDelete(false);

            modelBuilder.Entity<ApplicantProfilePoco>()
              .HasMany(e => e.ApplicantSkills)
              .WithRequired(e => e.ApplicantProfiles)
              .HasForeignKey(e => e.Applicant)
              .WillCascadeOnDelete(false);

            modelBuilder.Entity<ApplicantProfilePoco>()
             .HasRequired(e => e.SecurityLogins)
             .WithRequiredPrincipal(e=>e.ApplicantProfiles);


            modelBuilder.Entity<ApplicantWorkHistoryPoco>()
              .HasRequired(e => e.SystemCountryCodes)
              .WithRequiredPrincipal();


            modelBuilder.Entity<CompanyProfilePoco>()
            .HasMany(e => e.CompanyDescriptions)
            .WithRequired(e => e.CompanyProfiles)
            .HasForeignKey(e => e.Company)
            .WillCascadeOnDelete(false);

            modelBuilder.Entity<CompanyProfilePoco>()
              .HasMany(e => e.CompanyJobs)
              .WithRequired(e => e.CompanyProfiles)
              .HasForeignKey(e => e.Company)
              .WillCascadeOnDelete(false);

            modelBuilder.Entity<CompanyProfilePoco>()
              .HasMany(e => e.CompanyLocations)
              .WithRequired(e => e.CompanyProfiles)
              .HasForeignKey(e => e.Company)
              .WillCascadeOnDelete(false);




            modelBuilder.Entity<CompanyJobPoco>()
              .HasMany(e => e.ApplicantJobApplications)
              .WithRequired(e => e.CompanyJobs)
              .HasForeignKey(e => e.Job)
              .WillCascadeOnDelete(false);

            modelBuilder.Entity<CompanyJobPoco>()
             .HasMany(e => e.CompanyJobEducations)
             .WithRequired(e => e.CompanyJobs)
             .HasForeignKey(e => e.Job)
             .WillCascadeOnDelete(false);

            modelBuilder.Entity<CompanyJobPoco>()
             .HasMany(e => e.CompanyJobSkills)
             .WithRequired(e => e.CompanyJobs)
             .HasForeignKey(e => e.Job)
             .WillCascadeOnDelete(false);

            modelBuilder.Entity<CompanyJobPoco>()
                .HasRequired(e => e.CompanyJobDescriptions)
                .WithRequiredPrincipal(e=>e.CompanyJobs);



            modelBuilder.Entity<SecurityRolePoco>()
                .HasMany(e => e.SecurityLoginsRoles)
                .WithRequired(e => e.SecurityRoles)
                .HasForeignKey(e => e.Role)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<SystemCountryCodePoco>()
             .HasMany(e => e.ApplicantProfiles)
             .WithRequired(e => e.SystemCountryCodes)
             .HasForeignKey(e => e.Country)
             .WillCascadeOnDelete(false);

            modelBuilder.Entity<SystemCountryCodePoco>()
              .HasMany(e => e.ApplicantWorkHistory)
              .WithRequired(e => e.SystemCountryCodes)
              .HasForeignKey(e => e.CountryCode)
              .WillCascadeOnDelete(false);


        }

    }
}
