using DataAccessLayer.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccessLayer.Context
{
    public class MardaniContext:DbContext
    {
        public MardaniContext(DbContextOptions<MardaniContext> options):base(options)
        {

        }


        public DbSet<Role> Roles { get; set; }

        public DbSet<Permission> Permissions { get; set; }

        public DbSet<RolePermission> RolePermissions { get; set; }

        public DbSet<User> Users { get; set; }

        public DbSet<Degree> Degrees { get; set; }

        public DbSet<SpentMoney> SpentMoney { get; set; }

        public DbSet<Test> Tests { get; set; }

        public DbSet<Language > Languages { get; set; }

        public DbSet<Country> Countries { get; set; }

        public DbSet<DegreeCountry> DegreeCountries { get; set; }

        public DbSet<LangCountry> LangCountries { get; set; }

        public DbSet<CountryTest> CountryTests { get; set; }

        //public DbSet<TestCountry> TestCountries { get; set; }


        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<Test>()
        //        .HasMany(x => x.TestCountries)
        //        .WithOne()
        //        .HasForeignKey(x => x.UserId);



        //    modelBuilder.Entity<Country>()
        //        .HasMany(x => x.TestCountries)
        //        .WithOne()
        //        .HasForeignKey(x => x.CountryId);
                



        //    base.OnModelCreating(modelBuilder);
        //}

    }


}
