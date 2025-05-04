using Api.Interfaces.Services;
using Core.Models;
using DataBase.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Services
{
    public class CertificatesService : ICertificatesService
    {
        private readonly ICertificatesRepository _certificatesRepository;

        public CertificatesService(ICertificatesRepository certificatesRepository)
        {
            _certificatesRepository = certificatesRepository;
        }

        public async Task<Guid> CertificateCreate(string Name, Guid IdOrganization,string Description)
        {
            var id = Guid.NewGuid();
            
            var certificate = Certificate.CreateCertificate(id,Name,IdOrganization,Description);
        
            if (certificate.error == "None")
            {
                return await _certificatesRepository.CreateCertificate(certificate.certificate);
            }
            else
            {
                throw new Exception(certificate.error);
            }
        }

        public async Task<List<Certificate>> GetCertificates(List<Guid> IdCertificates)
        {
            return await _certificatesRepository.GetCertificates(IdCertificates);
        }

        public async Task<Guid> UpdateCertificate(Certificate certificate)
        {
            return await UpdateCertificate(certificate);
        }

        public async Task<Guid> DeleteCertificate(Guid id)
        {
            return await DeleteCertificate(id);
        }
    }
}
