using AutoMapper;
using Simple.Game.Abstract.Repositories;
using Simple.Game.Abstract.Services;
using Simple.Game.Contract.Play;
using Simple.Game.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Simple.Game.Services.Services
{
    public class StarsShipService: IStarsShipService
    {
        private readonly IPlayerRepository<StarsShipEntity> _starsShipRepository;
        private readonly IMapper _mapper;


        public StarsShipService(IPlayerRepository<StarsShipEntity> starsShipRepository, IMapper mapper)
        {
            _starsShipRepository = starsShipRepository;
            _mapper = mapper;
        }

        public async Task<List<PlayResponse>> Play()
        {
            throw new System.NotImplementedException();
        }
    }
}
