using DataBase.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBase.Configurations
{
    public class ContractsConfiguration : IEntityTypeConfiguration<ContractsEntity>
    {
        public void Configure(EntityTypeBuilder<ContractsEntity> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(b => b.Name).IsRequired();
        }
    }
}
