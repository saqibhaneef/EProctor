
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EProctor.Models
{
    public class AppDbContext:IdentityDbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) 
            : base(options)
        {

        }

        public object Course { get; internal set; }
        public DbSet<Course> Courses { get; set; }
    }
}
