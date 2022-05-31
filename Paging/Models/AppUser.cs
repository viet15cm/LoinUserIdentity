using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Paging.Models
{
    public class AppUser : IdentityUser
    {
        public string Address { get; set; }
       
        public string UrlImage  { get; set; }
    }
}
