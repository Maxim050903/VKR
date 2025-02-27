using DataBase.Entities;
using Microsoft.EntityFrameworkCore;

namespace DataBase
{
    public class VKRDBContext: DbContext
    {
        public VKRDBContext(DbContextOptions<VKRDBContext> options)
            : base(options)
        {
        }

        public DbSet<UserEntity> Users { get; set; }
        public DbSet<DepartmentEntity> Departments { get; set; }

    }
}
