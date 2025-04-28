using Core.Models;
using DataBase.Entities;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.Contracts;

namespace DataBase.Repositories
{
    public class CertificatesRepository : ICertificatesRepository
    {
        private readonly VKRDBContext _context;

        public CertificatesRepository(VKRDBContext context)
        {
            _context = context;
        }

        public async Task<Guid> CreateCertificate(Certificate certificate)
        {
            var CertificateEntity = new CertificateEntity
            {
                Id = certificate.Id,
                Name = certificate.Name,
                Organization = certificate.Organization,
                Description = certificate.Description
            };

            await _context.Certificates.AddAsync(CertificateEntity);

            await _context.SaveChangesAsync();

            return certificate.Id;
        }

        public async Task<List<Certificate>> GetCertificates()
        {
            var CertificateEntity = await _context.Certificates.AsNoTracking().ToArrayAsync();

            var Certificates = CertificateEntity.Select(x => Certificate.CreateCertificate(x.Id, x.Name, x.Organization, x.Description).certificate).ToList();

            return Certificates;
        }

        public async Task<Guid> UpdateCertificate(Certificate certificate)
        {
            await _context.Certificates
               .Where(x => x.Id == certificate.Id)
               .ExecuteUpdateAsync(s => s
               .SetProperty(b => b.Name, b => certificate.Name)
               .SetProperty(b => b.Description, b => certificate.Description)
               .SetProperty(b => b.Organization, b => certificate.Organization));

            await _context.SaveChangesAsync();

            return certificate.Id;
        }

        public async Task<Guid> DeleteCertificate(Guid Id)
        {
            await _context.Certificates.Where(x => x.Id == Id).ExecuteDeleteAsync();

            await _context.SaveChangesAsync();

            return Id;
        }
    }
}
