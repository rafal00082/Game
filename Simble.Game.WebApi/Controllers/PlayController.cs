using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Simble.Game.WebApi;
using Simple.Game.Abstract.Repositories;
using Simple.Game.Abstract.Services;
using Simple.Game.Contract.Play;
using Simple.Game.Domain.Entities;
using Simple.Game.Utils.Enums;

namespace Simple.Game.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PlayController : ControllerBase
    {
        private readonly ILogger<PlayController> _logger;
        private readonly IPlayService _playService;
        
        public PlayController(IPlayService playService, ILogger<PlayController> logger)
        {
            _logger = logger;
            _playService = playService;
        }

        [HttpGet("{kind}")]
        public async Task<IActionResult> Get(int kind)
        {
            try
            {
                var result = await _playService.Play((PlayersKindEnum)kind);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            

        }
    }
}
