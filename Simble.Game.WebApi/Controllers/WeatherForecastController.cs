﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Simble.Game.WebApi;
using Simple.Game.Abstract.Repositories;
using Simple.Game.Abstract.Services;
using Simple.Game.Domain.Entities;
using Simple.Game.Utils.Enums;

namespace Simple.Game.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;
        private readonly IPlayService _playService;
        private readonly IPlayerRepository<PersonEntity> _personRepository;

        public WeatherForecastController(IPlayService playService, IPlayerRepository<PersonEntity> personRepository,  ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
            _playService = playService;
            _personRepository = personRepository;
        }

        [HttpGet]
        public async Task<IEnumerable<WeatherForecast>> Get()
        {
            var rng = new Random();
            var result = await _personRepository.Get(1,50,"Name","desc");
            var test = await _playService.Play(PlayersKindEnum.StarsShips);
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            })
            .ToArray();
        }
    }
}
