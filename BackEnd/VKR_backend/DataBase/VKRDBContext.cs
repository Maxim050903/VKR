using Core.Models;
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
        public DbSet<ResumeEntity> Resumes { get; set; }
        public DbSet<RequestEntity> Requests { get; set; }
        public DbSet<_TaskEntity> Tasks { get; set; }
        public DbSet<CertificateEntity> Certificates { get; set; }
        public DbSet<OrganizationEntity> Organizations { get; set; }
        public DbSet<ContractsEntity> Contracts { get; set; }
        public DbSet<AgragetesEntity> Agragetes { get; set; }
        public DbSet<Request> AcceptedRequests { get; set; }
    }
}
