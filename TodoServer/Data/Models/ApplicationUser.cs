using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TodoServer.Data.Models
{
    public class ApplicationUser : IdentityUser
    {
        public IEnumerable<Todo> Todos { get; set; }
    }
}
