using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace MySchool.Infra.Data.Repositories.Context
{
    public class MySchoolContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Data Source=SQL5101.site4now.net;Initial Catalog=DB_A6E9D7_MySchoolProject;User Id=DB_A6E9D7_MySchoolProject_admin;Password=senha@senha123");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //ignorar classes
            //modelBuilder.Ignore<Notification>();

            //aplicar configurações
            //modelBuilder.ApplyConfiguration(new MapUsuario());

            base.OnModelCreating(modelBuilder);
        }
    }
}
