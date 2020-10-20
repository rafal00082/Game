using FluentAssertions;
using Simple.Game.Abstract.Services;
using Simple.Game.Domain.Entities;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace Simple.Game.Tests.IntegrationTests.PlayServiceTest
{
    public class StartsShipServiceTest: BaseIntegrationTest
    {
        public static StarsShipEntity s1_crew_10 = new StarsShipEntity { Id = 1, Name = "TestStarShip1", Crew = 10, Wins = 1 };
        public static StarsShipEntity s2_crew_20 = new StarsShipEntity { Id = 2, Name = "TestStarShip2", Crew = 20, Wins = 2 };
        public static StarsShipEntity s3_crew_30 = new StarsShipEntity { Id = 3, Name = "TestStarShip3", Crew = 30, Wins = 3 };
        public static StarsShipEntity s4_crew_20 = new StarsShipEntity { Id = 4, Name = "TestStarShip4", Crew = 20, Wins = 4 };



        [Fact]
        public async Task StarsShipService_Play_Proper_Amount()
        {
            //arrange
            await SeedData(new[] { s1_crew_10, s2_crew_20, s3_crew_30 });
            var starsShipService = GetRequiredService<IStarsShipService>();

            //act
            var result = await starsShipService.Play();

            //assert
            result.Should().NotBeNull();
            result.Should().NotBeEmpty();
            result.Count.Should().Be(2);
        }

        [Fact]
        public async Task StarsShipService_Play_Response_Verification_DifferentCrew()
        {
            //arrange
            await SeedData(new[] { s1_crew_10, s2_crew_20, });
            var starsShipService = GetRequiredService<IStarsShipService>();

            //act
            var result = await starsShipService.Play();
            
            //assert
            result.Should().NotBeNull();
            result.Should().NotBeEmpty();
            result.Count.Should().Be(2);
            result.Where(x => x.Id == s2_crew_20.Id).First().IsWinner.Should().BeTrue();
            result.Where(x => x.Id == s2_crew_20.Id).First().Wins.Should().Be(s2_crew_20.Wins++);
        }

        [Fact]
        public async Task StarsShipService_Play_Response_Verification_TheSameCrew()
        {
            //arrange
            await SeedData(new[] { s2_crew_20, s4_crew_20, });
            var starsShipService = GetRequiredService<IStarsShipService>();

            //act
            var result = await starsShipService.Play();

            //assert
            result.Should().NotBeNull();
            result.Should().NotBeEmpty();
            result.Count.Should().Be(2);
            result.Where(x => x.Id == s2_crew_20.Id).First().IsWinner.Should().BeFalse();
            result.Where(x => x.Id == s4_crew_20.Id).First().IsWinner.Should().BeFalse();
            result.Where(x => x.Id == s2_crew_20.Id).First().Wins.Should().Be(s2_crew_20.Wins);
            result.Where(x => x.Id == s4_crew_20.Id).First().Wins.Should().Be(s4_crew_20.Wins);
        }
    }
}
