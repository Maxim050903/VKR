using DataBase.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataBase.Configurations
{
    public class AgregatesConfigaration: IEntityTypeConfiguration<AgragetesEntity>
    {
        public void Configure(EntityTypeBuilder<AgragetesEntity> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(b => b.Name).IsRequired();
        }
    }
}
