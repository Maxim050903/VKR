using DataBase.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace DataBase.Configurations
{
    public class ManufacturesConfiguration : IEntityTypeConfiguration<ManafacturerEntity>
    {
        public void Configure(EntityTypeBuilder<ManafacturerEntity> builder)
        {
            builder.HasKey(x => x.id);

            builder.Property(b => b.Name).IsRequired();
        }
    }
}
