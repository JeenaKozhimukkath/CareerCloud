﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CareerCloud.Pocos;
using CareerCloud.DataAccessLayer;

namespace CareerCloud.BusinessLogicLayer
{
    public class SecurityLoginsRoleLogic : BaseLogic<SecurityLoginsRolePoco>
    {
        public SecurityLoginsRoleLogic(IDataRepository<SecurityLoginsRolePoco> repository) : base(repository)
        { }

        public override void Add(SecurityLoginsRolePoco[] pocos)
        {
            Verify(pocos);
            base.Add(pocos);
        }

        public override void Update(SecurityLoginsRolePoco[] pocos)
        {
            Verify(pocos);
            base.Update(pocos);
        }
        //public override void Delete(SecurityLoginsRolePoco[] pocos)
        //{
        //    base.Delete(pocos);
        //}
        protected override void Verify(SecurityLoginsRolePoco[] pocos)
        {

        }
    
    }
}
