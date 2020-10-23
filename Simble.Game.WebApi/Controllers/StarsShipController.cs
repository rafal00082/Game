using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Simple.Game.Abstract.Services;
using Simple.Game.Contract;

namespace Simple.Game.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class StarsShipController : ControllerBase
    {
        private readonly ILogger<StarsShipController> _logger;
        private readonly IStarsShipService _starsShipService;
        
        public StarsShipController(IStarsShipService startsShipService, ILogger<StarsShipController> logger)
        {
            _logger = logger;
            _starsShipService = startsShipService;
        }

        [HttpGet]
        public async Task<IActionResult> Get(int pageNumber, int pageSize, string sortBy, string order)
        {
            try
            {
                var result = await _starsShipService.Get(pageNumber, pageSize, sortBy,order);
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Get([FromBody] PagingInfoRequest pagingInfoRequest)
        {
            try
            {
                var result = await _starsShipService.Get(pagingInfoRequest);
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return BadRequest(ex.Message);
            }
        }
    }
}
