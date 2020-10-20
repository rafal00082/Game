using AutoMapper;
using Simple.Game.Abstract.Repositories;
using Simple.Game.Abstract.Services;
using Simple.Game.Contract.Play;
using Simple.Game.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Simple.Game.Services.Services
{
    public class PersonService : IPersonService
    {
        private readonly IPlayerRepository<PersonEntity> _presonRepository;
        private readonly IMapper _mapper;


        public PersonService(IPlayerRepository<PersonEntity> personRepository, IMapper mapper)
        {
            _presonRepository = personRepository;
            _mapper = mapper;
        }

        public async Task<List<PlayResponse>> Play()
        {
            var result = new List<PlayResponse>();
            var randomsList = await _presonRepository.GetTwoRandom();
            //TODO compare logic
            return result;
        }
    }
}
