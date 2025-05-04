using DataBase.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace DataBase.Configurations
{
    public class DepartmentsConfiguration : IEntityTypeConfiguration<DepartmentEntity>
    {
        public void Configure(EntityTypeBuilder<DepartmentEntity> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(b => b.Name).IsRequired();
        }
    }
}

    
