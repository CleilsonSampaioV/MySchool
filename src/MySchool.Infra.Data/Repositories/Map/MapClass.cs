using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MySchool.Domain.Entities;

namespace MySchool.Infra.Data.Repositories.Map
{
    public class MapClass : IEntityTypeConfiguration<Class>
    {
        public void Configure(EntityTypeBuilder<Class> builder)
        {
            builder.ToTable("Classes");

            ////Propriedades
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Name).HasMaxLength(255).IsRequired();
            builder.Property(x => x.Shift).HasMaxLength(255).IsRequired();
            builder.Property(x => x.Degree).HasMaxLength(255).IsRequired();
            builder.Property(x => x.SchoolId).IsRequired();
            
            builder.HasOne(x => x.School).WithMany(x => x.Classes).HasForeignKey(x => x.SchoolId).OnDelete(DeleteBehavior.Restrict);
        }
    }
}