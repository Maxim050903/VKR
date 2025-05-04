using DataBase.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace DataBase.Configurations
{
    public class CertificatesConfiguration : IEntityTypeConfiguration<CertificateEntity>
    {
        public void Configure(EntityTypeBuilder<CertificateEntity> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(b => b.Name).IsRequired();
        }
    }
}
