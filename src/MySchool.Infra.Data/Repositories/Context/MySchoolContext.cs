﻿using Flunt.Notifications;
using Microsoft.EntityFrameworkCore;
using MySchool.Domain.Entities;
using MySchool.Infra.Data.Repositories.Map;

namespace MySchool.Infra.Data.Repositories.Context
{
    public class MySchoolContext : DbContext
    {
        public DbSet<School> School { get; set; }
        public DbSet<Class> Class { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Data Source=SQL5101.site4now.net;Initial Catalog=DB_A6E9D7_MySchoolProject;User Id=DB_A6E9D7_MySchoolProject_admin;Password=*******");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // ignorar classes
            modelBuilder.Ignore<Notification>();

            //aplicar configurações
            modelBuilder.ApplyConfiguration(new MapSchool());
            modelBuilder.ApplyConfiguration(new MapClass());

            base.OnModelCreating(modelBuilder);
        }
    }
}
