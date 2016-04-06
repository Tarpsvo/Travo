using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.ComponentModel.DataAnnotations;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Travo.Domain.Models
{
    public class User: IdentityUser
    {
        [StringLength(30, MinimumLength = 3)]
        public string DisplayName { get; set; }
        public DateTime Created { get; set; }

        public User()
        {
            Created = DateTime.UtcNow;
        }
    }
}
