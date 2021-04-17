
using EProctor.Models.UserModels;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EProctor.ViewModels;

namespace EProctor.Models
{
    public class AppDbContext:IdentityDbContext<ApplicationUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) 
            : base(options)
        {

        }

        public object Course { get; internal set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //this will be used to dont delete entitis with foreign key
            foreach (var foreignKey in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            {
                foreignKey.DeleteBehavior = DeleteBehavior.Restrict;
            }

        }
        public DbSet<EProctor.ViewModels.ContactCreateViewModel> ContactCreateViewModel { get; set; }
        public DbSet<EProctor.ViewModels.ContactDeleteViewModel> ContactDeleteViewModel { get; set; }
    }
}
