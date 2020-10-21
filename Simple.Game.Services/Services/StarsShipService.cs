using AutoMapper;
using Simple.Game.Abstract.Repositories;
using Simple.Game.Abstract.Services;
using Simple.Game.Contract;
using Simple.Game.Contract.Play;
using Simple.Game.Contract.StarsShip;
using Simple.Game.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Simple.Game.Services.Services
{
    public class StarsShipService: IStarsShipService
    {
        private readonly IPlayerRepository<StarsShipEntity> _starsShipRepository;
        private readonly IBussinesComparer<StarsShipEntity> _bussinesComparer;
        private readonly IMapper _mapper;


        public StarsShipService(IPlayerRepository<StarsShipEntity> starsShipRepository, IBussinesComparer<StarsShipEntity> bussinesComparer, IMapper mapper)
        {
            _starsShipRepository = starsShipRepository;
            _bussinesComparer = bussinesComparer;
            _mapper = mapper;
        }

        public async Task<PagingListResponse<StarsShipResponse>> Get(int pageNumber, int pageSize, string sortBy, string order)
        {
            var entriesList = await _starsShipRepository.Get(pageNumber, pageSize, sortBy, order);
            var amount = await _starsShipRepository.GetAmount();
            var result = new PagingListResponse<StarsShipResponse>
            {
                Items = _mapper.Map<List<StarsShipResponse>>(entriesList),
                PagingInfo = new PagingInfoResponse(pageSize, pageNumber, amount)
            };
            return result;
        }

        public async Task<List<PlayResponse>> Play()
        {
            _ = new List<PlayResponse>();
            var randomsList = await _starsShipRepository.GetTwoRandom();
            var index = _bussinesComparer.Compare(randomsList);
            List<PlayResponse> result;
            if (index != -1)
            {
                randomsList[index].Wins++;
                await _starsShipRepository.Update(randomsList[index]);

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
