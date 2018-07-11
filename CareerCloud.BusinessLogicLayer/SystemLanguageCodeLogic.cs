using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CareerCloud.Pocos;
using CareerCloud.DataAccessLayer;

namespace CareerCloud.BusinessLogicLayer
{
    public class SystemLanguageCodeLogic
    {

        public SystemLanguageCodeLogic(IDataRepository<SystemLanguageCodePoco> repository) 
        { }
        public void Add(SystemLanguageCodePoco[] pocos)
        {
            Verify(pocos);
            Add(pocos);
        }

        public void Update(SystemLanguageCodePoco[] pocos)
        {
            Verify(pocos);
            Update(pocos);
        }
        protected void Verify(SystemLanguageCodePoco[] pocos)
        {
            List<ValidationException> exceptions = new List<ValidationException>();
            foreach (SystemLanguageCodePoco poco in pocos)
            {
                if (string.IsNullOrEmpty(poco.LanguageID))
                {
                    exceptions.Add(new ValidationException(1000,
                        $"Cannot be empty "));
                }
                if (string.IsNullOrEmpty(poco.Name))
                {
                    exceptions.Add(new ValidationException(1001,
                        $"Cannot be empty "));
                }
                if (string.IsNullOrEmpty(poco.NativeName))
                {
                    exceptions.Add(new ValidationException(1002,
                        $"Cannot be empty "));
                }
            }
            if (exceptions.Count > 0)
            {
                throw new AggregateException(exceptions);
            }
        }
    }
}
