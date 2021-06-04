using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace Domain.Models
{
    public class CustomIdentityUser : IdentityUser
    {
        public CustomIdentityUser()
        {
            
        }
        public CustomIdentityUser(string username) : base(username)
        {

        }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
