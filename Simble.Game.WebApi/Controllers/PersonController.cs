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
    public class PersonController : ControllerBase
    {
        private readonly ILogger<PersonController> _logger;
        private readonly IPersonService _personService;
        
        public PersonController(IPersonService personService, ILogger<PersonController> logger)
        {
            _logger = logger;
            _personService = personService;
        }

        [HttpGet]
        public async Task<IActionResult> Get(int pageNumber, int pageSize, string sortBy, string order)
        {
            try
            {
                var result = await _personService.Get(pageNumber, pageSize, sortBy,order);
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
                var result = await _personService.Get(pagingInfoRequest);
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
