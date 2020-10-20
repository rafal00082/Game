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
        private readonly IBussinesComparer<PersonEntity> _bussinesComparer;
        private readonly IMapper _mapper;


        public PersonService(IPlayerRepository<PersonEntity> personRepository, IBussinesComparer<PersonEntity> bussinesComparer, IMapper mapper)
        {
            _presonRepository = personRepository;
            _bussinesComparer = bussinesComparer;
            _mapper = mapper;
        }

        public async Task<List<PlayResponse>> Play()
        {
            _ = new List<PlayResponse>();
            var randomsList = await _presonRepository.GetTwoRandom();
            var index = _bussinesComparer.Compare(randomsList);
            List<PlayResponse> result;
            if (index != -1)
            {
                randomsList[index].Wins++;
                await _presonRepository.Update(randomsList[index]);

                result = _mapper.Map<List<PlayResponse>>(randomsList);
                result[index].IsWinner = true;
            }
            else
            {
                result = _mapper.Map<List<PlayResponse>>(randomsList);
            }

            return result;
        }
    }
}
