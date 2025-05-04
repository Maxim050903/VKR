using Api.Interfaces.Services;
using Core.Models;
using DataBase.Repositories;
using System.Collections.Generic;

namespace Api.Services
{
    public class ResumeService : IResumeService
    {
        private readonly IResumesRepository _resumesRepository;

        public ResumeService(IResumesRepository resumesRepository)
        {
            _resumesRepository = resumesRepository;
        }

        public async Task<Guid> CreateResume(Guid IdUser, 
            DateOnly DateStart, string JobTitle, 
            Guid IdDpartment, DateOnly Experience, 
            DateOnly ExperienceOnCompany, List<Guid> IdSertificates)
        {
            var Id = Guid.NewGuid();

            var resume = Resume.CreateResume(Id, IdUser, DateStart, JobTitle, IdDpartment, Experience, ExperienceOnCompany, IdSertificates);

            if (resume.error == "None")
            {
                return await _resumesRepository.CreateResume(resume.resume);
            }
            else
            {
                throw new Exception(resume.error);
            }
        }

        public async Task<Resume> GetUserResume(Guid Id)
        {
            return await _resumesRepository.GetUserResume(Id);
        }


        public async Task<Guid> UpdateResume(Resume resume)
        {
            return await UpdateResume(resume);
        }

        public async Task<Guid> DeleteResume(Guid id)
        {
            return await DeleteResume(id);
        }
    }
}
