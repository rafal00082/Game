using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Simple.Game.Abstract.Services;

namespace Simple.Game.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SelectItemController : ControllerBase
    {
        private readonly ILogger<SelectItemController> _logger;
        private readonly ISelectItemService _selectItemService;
        
        public SelectItemController(ISelectItemService selectItemService, ILogger<SelectItemController> logger)
        {
            _logger = logger;
            _selectItemService = selectItemService;
        }

        [HttpGet("getPlayersKindEnumAsSelectItems")]
        public async Task<IActionResult> GetPlayersKindEnumAsSelectItems()
        {
            try
            {
                var result = await _selectItemService.GetPlayersKindEnumAsSelectItems();
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
