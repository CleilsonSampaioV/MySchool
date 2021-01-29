using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MySchool.Infra.Data.Repositories.Map
{
    public class MapSchool : IEntityTypeConfiguration<School>
    {
        public void Configure(EntityTypeBuilder<School> builder)
        {
            builder.ToTable("Schools");

            ////Propriedades
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Name).HasMaxLength(255).IsRequired();
            builder.Property(x => x.Cnpj).HasMaxLength(14).IsRequired();
            builder.Property(x => x.Street).HasMaxLength(255).IsRequired();
            builder.Property(x => x.Number).HasMaxLength(20).IsRequired();
            builder.Property(x => x.Neighborhood).HasMaxLength(255).IsRequired();
            builder.Property(x => x.City).HasMaxLength(255).IsRequired();
            builder.Property(x => x.State).HasMaxLength(100).IsRequired();
            builder.Property(x => x.Country).HasMaxLength(100).IsRequired();
            builder.Property(x => x.ZipCode).HasMaxLength(50);
        }
    }
}