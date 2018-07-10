using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CareerCloud.Pocos;
using CareerCloud.DataAccessLayer;
using System.Text.RegularExpressions;

namespace CareerCloud.BusinessLogicLayer
{
    public class CompanyProfileLogic : BaseLogic<CompanyProfilePoco>
    {
        public CompanyProfileLogic(IDataRepository<CompanyProfilePoco> repository) : base(repository)
        { }

        public override void Add(CompanyProfilePoco[] pocos)
        {
            Verify(pocos);
            base.Add(pocos);
        }

        public override void Update(CompanyProfilePoco[] pocos)
        {
            Verify(pocos);
            base.Update(pocos);
        }
        protected override void Verify(CompanyProfilePoco[] pocos)
        {
            List<ValidationException> exceptions = new List<ValidationException>();
            foreach (CompanyProfilePoco poco in pocos)
            {
                Regex reWebsite = new Regex(@"^\d{3}\-\d{3}\-\d{4}$");
                if (!reWebsite.IsMatch(poco.CompanyWebsite))
                {
                    exceptions.Add(new ValidationException(600,
                        $"Valid websites must end with the following extensions – .ca, .com, .biz - {poco.Id}"));
                }
                Regex rePhone = new Regex(@"^\d{3}\-\d{3}\-\d{4}$");
                if (!rePhone.IsMatch(poco.ContactPhone))
                {
                    exceptions.Add(new ValidationException(601,
                        $"Must correspond to a valid phone number (e.g. 416-555-1234) - {poco.Id}"));
                }
            }
            if (exceptions.Count > 0)
            {
                throw new AggregateException(exceptions);
            }
        }
    }
}
