using JobPortal.Data.Configurations;
using JobPortal.Data.Entities;
using JobPortal.Data.Extensions;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace JobPortal.Data.DataContext
{

    // inherit from IdentityDbContext<AppUser, AppRole, Guid> to use Identity
    public partial class DataDbContext : IdentityDbContext<AppUser, AppRole, Guid>
    {

        // constructor with no parameter - options
        public DataDbContext()
        {
        }

        //  passing configuration options when creating an instance of DataDbContext.
        public DataDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);



            // Set delete behavior for entities to Restrict
            // in order to prevent cascade delete
            // when deleting an entity that has a relationship with another entity


            // get all entities in the model ..
            // get all foreign keys for each entity ..
            // set delete behavior to Restrict ..
            foreach (var foreignKey in modelBuilder.Model.GetEntityTypes()
                .SelectMany(e => e.GetForeignKeys()))
            {
                foreignKey.DeleteBehavior = DeleteBehavior.Restrict;
            }

            // 27-7-2024
            //.OnDelete(DeleteBehavior.Restrict); Fluent API
            // [InverseProperty("Jobs")] // public Company Company { get; set; }  // DataAnnotations



            //Configure using Fluent API
            modelBuilder.ApplyConfiguration(new AppUserConfiguration());
            modelBuilder.ApplyConfiguration(new AppRoleConfiguration());
            modelBuilder.ApplyConfiguration(new BlogConfiguration());
            modelBuilder.ApplyConfiguration(new CategoryConfiguration());
            modelBuilder.ApplyConfiguration(new CVConfiguration());
            modelBuilder.ApplyConfiguration(new JobConfiguration());
            modelBuilder.ApplyConfiguration(new ProvinceConfiguration());
            modelBuilder.ApplyConfiguration(new SkillConfiguration());
            modelBuilder.ApplyConfiguration(new TimeConfiguration());
            modelBuilder.ApplyConfiguration(new TitleConfiguration());
            modelBuilder.ApplyConfiguration(new CountryConfiguration());

            modelBuilder.Entity<IdentityUserClaim<Guid>>().ToTable("AppUserClaims");
            modelBuilder.Entity<IdentityUserRole<Guid>>().ToTable("AppUserRoles").HasKey(x => new { x.UserId, x.RoleId });
            modelBuilder.Entity<IdentityUserLogin<Guid>>().ToTable("AppUserLogins").HasKey(x => x.UserId);
            modelBuilder.Entity<IdentityRoleClaim<Guid>>().ToTable("AppRoleClaims");
            modelBuilder.Entity<IdentityUserToken<Guid>>().ToTable("AppUserTokens").HasKey(x => x.UserId);


            //


            //Data seeding
            modelBuilder.Seed();
        }
        public DbSet<AppRole> AppRoles { get; set; }
        public DbSet<AppUser> AppUsers { get; set; }
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<CV> CVs { get; set; }
        public DbSet<Job> Jobs { get; set; }
        public DbSet<Province> Provinces { get; set; }
        public DbSet<Skill> Skills { get; set; }
        public DbSet<Time> Times { get; set; }
        public DbSet<Title> Titles { get; set; }
        public DbSet<Country> Countries { get; set; }
    }
}
