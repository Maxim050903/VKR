using DataBase.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace DataBase.Configurations
{
    public class OrganizationsConfiguration : IEntityTypeConfiguration<OrganizationEntity>
    {
        public void Configure(EntityTypeBuilder<OrganizationEntity> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(b => b.Name).IsRequired();
        }
    }
}
