using Core.Models;
using DataBase.Entities;
using Microsoft.EntityFrameworkCore;

namespace DataBase.Repositories
{
    public class ResumesRepository : IResumesRepository
    {
        private readonly VKRDBContext _context;

        public ResumesRepository(VKRDBContext context)
        {
            _context = context;
        }

        public async Task<Guid> AddResume(Resume resume)
        {
            var ResumeEntity = new ResumeEntity
            {
                Id = resume.id,
                IdUser = resume.IdUser,
                DateStart = DateTime.UtcNow.Date,
                JobTitle = resume.JobTitle,
                idDepartment = resume.idDepartment,
                Experience = DateTime.UtcNow.Date,
                ExperienceOnCompany = DateTime.UtcNow.Date,
                IdSertificates = resume.IdSertificates
            };

            await _context.AddAsync(ResumeEntity);

            await _context.SaveChangesAsync();

            return resume.id;
        }

        //public async Task<Resume> GetResumeForUserId(Guid Id)
        //{
        //    var resumeEntity = await _context.Resumes.FirstOrDefaultAsync(x => x.IdUser == Id);

        //    var resume = Resume.CreateResume(resumeEntity.Id,
        //        resumeEntity.IdUser,resumeEntity.DateStart,resumeEntity.JobTitle,
        //        resumeEntity.idDepartment, resumeEntity.Experience,resumeEntity.ExperienceOnCompany,
        //        resumeEntity.IdSertificates);
        //}

        public async Task<Guid> UpdateResume(Resume resume)
        {
            var resumeEntity = new ResumeEntity
            {
                Id = resume.id,
                IdUser = resume.IdUser,
                DateStart = DateTime.UtcNow.Date,
                JobTitle = resume.JobTitle,
                idDepartment = resume.idDepartment,
                Experience = DateTime.UtcNow.Date,
                ExperienceOnCompany = DateTime.UtcNow.Date,
                IdSertificates = resume.IdSertificates
            };
            await _context.Resumes
                .Where(x => x.IdUser == resume.IdUser)
                .ExecuteUpdateAsync(s => s
                .SetProperty(b => b.IdSertificates, b => resume.IdSertificates));

            await _context.SaveChangesAsync();

            return resume.id;
        }

        public async Task<Guid> DeleteForUserId(Guid userId)
        {
            await _context.Resumes.Where(x => x.IdUser == userId).ExecuteDeleteAsync();

            await _context.SaveChangesAsync();

            return userId;
        }
    }
}
