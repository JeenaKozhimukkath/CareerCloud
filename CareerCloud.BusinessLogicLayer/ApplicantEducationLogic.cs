using CareerCloud.Pocos;
using CareerCloud.DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CareerCloud.BusinessLogicLayer
{
    public class ApplicantEducationLogic : BaseLogic<ApplicantEducationPoco>
    {
        public ApplicantEducationLogic(IDataRepository<ApplicantEducationPoco> repository) : base (repository)
        { }

        public override void Add(ApplicantEducationPoco[] pocos)
        {
            Verify(pocos);
            base.Add(pocos);
        }

        public override void Update(ApplicantEducationPoco[] pocos)
        {
            Verify(pocos);
            base.Update(pocos); 
        }

        //public override void Delete(ApplicantEducationPoco[] pocos)
        //{
        //    base.Delete(pocos); 
        //}
        protected override void Verify(ApplicantEducationPoco[] pocos)
        {
            List<ValidationException> exceptions = new List<ValidationException>();
            foreach (ApplicantEducationPoco poco in pocos)
            {
                if (string.IsNullOrEmpty(poco.Major) || poco.Major.Length<3)
                {
                    exceptions.Add(new ValidationException(107,
                        $"Cannot be empty or less than 3 characters - {poco.Id}"));
                }
                if (poco.StartDate>DateTime.Now)
                {
                    exceptions.Add(new ValidationException(108,
                        $"Cannot be greater than today - {poco.Id}"));
                }
                if (poco.CompletionDate < poco.StartDate)
                {
                    exceptions.Add(new ValidationException(109,
                        $"CompletionDate cannot be earlier than StartDate - {poco.Id}"));
                }
            }
            if (exceptions.Count>0)
            {
                throw new AggregateException(exceptions);
            }
        }
    }
}
