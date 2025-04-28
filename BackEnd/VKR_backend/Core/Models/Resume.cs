using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Models
{
    public class Resume
    {
        public Guid id { get; set; }
        public Guid IdUser { get; set; }
        public DateOnly DateStart { get; set; }
        public string JobTitle { get; set; } = string.Empty;
        public Guid idDepartment { get; set; }
        public DateOnly Experience { get; set; }
        public DateOnly ExperienceOnCompany { get; set; }
        public List<Guid> IdSertificates { get; set; } = new List<Guid>();


        private Resume(Guid id,Guid IdUser, DateOnly DateStart, string JobTitle, Guid IdDpartment, DateOnly Experience, DateOnly ExperienceOnCompany, List<Guid> IdSertificates)
        {
            this.id = id;
            this.IdUser = IdUser;
            this.DateStart = DateStart;
            this.JobTitle = JobTitle;
            this.idDepartment = idDepartment;
            this.Experience = Experience;
            this.ExperienceOnCompany = ExperienceOnCompany;
            this.IdSertificates = IdSertificates;
        }

        public static (string error, Resume resume) CreateResume(Guid id,Guid IdUser, DateOnly DateStart, string JobTitle, Guid IdDpartment, DateOnly Experience, DateOnly ExperienceOnCompany, List<Guid> IdSertificates)
        {
            string error = string.Empty;

            error = Utils.CheckValidData(JobTitle);

            if (error == "None")
            {
                var resume = new Resume(id,IdUser, DateStart, JobTitle, IdDpartment, Experience, ExperienceOnCompany, IdSertificates);
                return (error, resume);
            }
            else
            {
                return (error, null);
            }
            
        }
    }
}
