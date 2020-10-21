using FluentAssertions;
using Simple.Game.Abstract.Repositories;
using Simple.Game.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Simple.Game.Tests.IntegrationTests.StarsShipTest
{
    public class StarsShipRepositoryTest : BaseIntegrationTest
    {
        public static StarsShipEntity s1_crew_10 = new StarsShipEntity { Id = 1, Name = "1TestStarShip1", Crew = 10, Wins = 1 };
        public static StarsShipEntity s2_crew_20 = new StarsShipEntity { Id = 2, Name = "3TestStarShip2", Crew = 20, Wins = 20 };
        public static StarsShipEntity s3_crew_30 = new StarsShipEntity { Id = 3, Name = "4TestStarShip3", Crew = 30, Wins = 3 };
        public static StarsShipEntity s4_crew_20 = new StarsShipEntity { Id = 4, Name = "2TestStarShip4", Crew = 20, Wins = 40 };


        [Theory]
        [InlineData(1, 2, 2)]
        [InlineData(1, 10, 4)]
        [InlineData(1, 100, 4)]
        [InlineData(4, 1, 1)]
        [InlineData(4, 5, 0)]
        [InlineData(-1, 3, 3)]
        public async Task StarsSipRepository_Get(int pageNumber, int pageSize, int amount)
        {
            //arrange
            await SeedData(new[] { s1_crew_10, s2_crew_20, s3_crew_30, s4_crew_20 });
            var repository = GetRequiredService<IPlayerRepository<StarsShipEntity>>();

            //act
            var result = await repository.Get(pageNumber, pageSize, "", "");

            //assert
            result.Should().NotBeNull();
            result.Count.Should().Be(amount);
        }

        [Theory]
        [InlineData("","")]
        [InlineData("aaa", "")]
        [InlineData("aaa", "werwer")]
        [InlineData("", "werwer")]
        public async Task StarsSipRepository_Get_DefaultSort(string sortBy, string order)
        {
            //arrange
            await SeedData(new[] { s1_crew_10, s2_crew_20, s3_crew_30, s4_crew_20 });
            var repository = GetRequiredService<IPlayerRepository<StarsShipEntity>>();

            //act
            var result = await repository.Get(1,50, sortBy, order);

            //assert
            result.Should().NotBeNull();
            result.Should().NotBeEmpty();
            result.Count.Should().Be(4);
            result.First().Id.Should().Be(s1_crew_10.Id);
            result.Last().Id.Should().Be(s4_crew_20.Id);
        }

        [Theory]
        [InlineData("", "desc")]
        [InlineData("aaa", "desc")]
        [InlineData("Wins", "desc")]
        public async Task StarsSipRepository_Get_DescendingSort(string sortBy, string order)
        {
            //arrange
            await SeedData(new[] { s1_crew_10, s2_crew_20, s3_crew_30, s4_crew_20 });
            var repository = GetRequiredService<IPlayerRepository<StarsShipEntity>>();

            //act
            var result = await repository.Get(1, 50, sortBy, order);

            //assert
            result.Should().NotBeNull();
            result.Should().NotBeEmpty();
            result.Count.Should().Be(4);
            result.Last().Id.Should().Be(s1_crew_10.Id);
            result.First().Id.Should().Be(s4_crew_20.Id);
        }

        [Fact]
        public async Task StarsSipRepository_Get_DescendingSortByName()
        {
            //arrange
            await SeedData(new[] { s1_crew_10, s2_crew_20, s3_crew_30, s4_crew_20 });
            var repository = GetRequiredService<IPlayerRepository<StarsShipEntity>>();

            //act
            var result = await repository.Get(1, 50, "Name", "desc");

            //assert
            result.Should().NotBeNull();
            result.Should().NotBeEmpty();
            result.Count.Should().Be(4);
            result.Last().Id.Should().Be(s1_crew_10.Id);
            result.First().Id.Should().Be(s3_crew_30.Id);
        }
    }
}
