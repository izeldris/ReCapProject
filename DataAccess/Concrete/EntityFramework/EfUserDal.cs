﻿using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Core.Entities.Concrete;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfUserDal : EfEntityRepositoryBase<User, ReCapCarShopContext>, IUserDal
    {
        public List<OperationClaim> GetClaims(User user)
        {
            using (var context=new ReCapCarShopContext())
            {
                var result = from oc in context.OperationClaims
                             join uoc in context.UserOperationClaims
                             on oc.Id equals uoc.OperationClaimId
                             where uoc.UserId == user.Id
                             select new OperationClaim { Id = oc.Id, Name = oc.Name };
                return result.ToList();
            }
            
        }
    }
}
