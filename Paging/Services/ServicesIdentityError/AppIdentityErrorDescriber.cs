using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Paging.Services.ServicesIdentityError
{

    public class AppIdentityErrorDescriber : IdentityErrorDescriber
    {

        public override IdentityError DuplicateRoleName(string role)
        {
            var error =  base.DuplicateRoleName(role);
            return new IdentityError
            {
                Code = error.Code,
                Description = $"Lỗi tên {role} bị trùng"
            };
              
        }
    }
}
