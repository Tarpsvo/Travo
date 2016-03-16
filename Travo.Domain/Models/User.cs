using Microsoft.AspNet.Identity.EntityFramework;
using System;

namespace Travo.Domain.Models
{
    public class User: IdentityUser
    {
        public DateTime Created { get; set; }

        public User()
        {
            Created = DateTime.UtcNow;
        }
    }
}
