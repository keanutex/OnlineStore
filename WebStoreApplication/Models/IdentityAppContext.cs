using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebStoreApplication.Models
{
    public class IdentityAppContext:IdentityDbContext<UserModel , UserRole , int>
    {
        public IdentityAppContext(DbContextOptions<IdentityAppContext>options):base(options)
        {

        }
    }
}
