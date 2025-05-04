using Core.Models;
using DataBase.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace DataBase.Repositories
{
    public class ResumesRepository : IResumesRepository
    {
        private readonly VKRDBContext _context;

        public ResumesRepository(VKRDBContext context)
        {
            _context = context;
        }

        public async Task<Guid> CreateResume(Resume resume)
        {
            var ResumeEntity = new ResumeEntity
            {
                Id = resume.id,
                IdUser = resume.IdUser,
                DateStart = resume.DateStart,
                JobTitle = resume.JobTitle,
                idDepartment = resume.idDepartment,
                Experience = resume.Experience,
                ExperienceOnCompany = resume.ExperienceOnCompany,
                IdSertificates = resume.IdSertificates
            };

            await _context.AddAsync(ResumeEntity);

            await _context.SaveChangesAsync();

            return resume.id;
        }

        public async Task<Resume> GetUserResume(Guid id)
        {
            var ResumeEntity = await _context.Resumes.Where(x => x.IdUser == id).FirstOrDefaultAsync();

            var resume = Resume.CreateResume(ResumeEntity.Id,
                ResumeEntity.IdUser, ResumeEntity.DateStart,
                ResumeEntity.JobTitle, ResumeEntity.idDepartment,
                ResumeEntity.Experience, ResumeEntity.ExperienceOnCompany,
                ResumeEntity.IdSertificates);
            if (resume.error == "None")
            {
                return resume.resume;
            }
            else
            {
                throw new Exception(resume.error);
            }
        }

        public async Task<Guid> UpdateResume(Resume resume)
        {
            var resumeEntity = new ResumeEntity
            {
                Id = resume.id,
                IdUser = resume.IdUser,
                DateStart = resume.DateStart,
                JobTitle = resume.JobTitle,
                idDepartment = resume.idDepartment,
                Experience = resume.Experience,
                ExperienceOnCompany = resume.ExperienceOnCompany,
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
