using DataBase.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;


namespace DataBase.Configurations
{
    public class RequestsConfiguration : IEntityTypeConfiguration<RequestEntity>
    {
        public void Configure(EntityTypeBuilder<RequestEntity> builder)
        {
            builder.HasKey(x => x.id);

            builder.Property(b => b.idUser).IsRequired();
        }
    }
}
