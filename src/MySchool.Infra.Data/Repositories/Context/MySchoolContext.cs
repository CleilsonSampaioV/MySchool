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
                optionsBuilder.UseSqlServer("Server=localhost;Database=vemdezap;Uid=root;Pwd=root;");
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
