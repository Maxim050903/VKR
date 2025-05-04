using Api.Interfaces.Services;
using Core.Models;
using DataBase.Repositories;
using Microsoft.AspNetCore.Http.HttpResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Services
{
    public class AgrigatesService : IAgrigatesService
    {
        private readonly IAgrigatesRepository _agrigatesRepository;

        public AgrigatesService(IAgrigatesRepository agrigatesRepository)
        {
            _agrigatesRepository = agrigatesRepository;
        }

        public async Task<Guid> CreateAgrigate(string Name, Guid IdManafacturer)
        {
            var id = new Guid();

            var agregate = Agragetes.CreateAgregate(id, Name, IdManafacturer);

            if (agregate.error == "None")
            {
                return await _agrigatesRepository.CreateAgrigate(agregate.agregate);
            }
            else
            {
                throw new Exception(agregate.error);
            }
        }

        public async Task<List<Agragetes>> GetAgragetes()
        {
            var Agrigates = await GetAgragetes();
            return Agrigates;
        }

        public async Task<Guid> UpdateAgregate(Agragetes agregate)
        {
            var Agregate = await UpdateAgregate(agregate);
            return Agregate;
        }

        public async Task<Guid> DeleteAgregate(Guid id)
        {
            return await DeleteAgregate(id);
        }
    }
}
