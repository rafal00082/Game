using FluentAssertions;
using Simple.Game.Abstract.Services;
using Simple.Game.Domain.Entities;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace Simple.Game.Tests.IntegrationTests.PlayServiceTest
{
    public class PersonServiceTests: BaseIntegrationTest
    {
        public static PersonEntity p1_mass_10 = new PersonEntity { Id = 1, Name = "TestPerson1", Mass = 10.5, Wins = 1 };
        public static PersonEntity p2_mass_20 = new PersonEntity { Id = 2, Name = "TestPerson2", Mass = 20, Wins = 2 };
        public static PersonEntity p3_mass_30 = new PersonEntity { Id = 3, Name = "TestPerson3", Mass = 30, Wins = 3 };
        public static PersonEntity p4_mass_20 = new PersonEntity { Id = 4, Name = "TestPerson4", Mass = 20, Wins = 4 };




        [Fact]
        public async Task PersonService_Play_Proper_Amount()
        {
            //arrange
            await SeedData(new[] { p1_mass_10, p2_mass_20, p3_mass_30 });
            var personService = GetRequiredService<IPersonService>();

            //act
            var result = await personService.Play();

            //assert
            result.Should().NotBeNull();
            result.Should().NotBeEmpty();
            result.Count.Should().Be(2);
        }

        [Fact]
        public async Task PersonService_Play_Response_Verification_DifferentMass()
        {
            //arrange
            await SeedData(new[] { p1_mass_10, p2_mass_20, });
            var personService = GetRequiredService<IPersonService>();

            //act
            var result = await personService.Play();
            
            //assert
            result.Should().NotBeNull();
            result.Should().NotBeEmpty();
            result.Count.Should().Be(2);
            result.Where(x => x.Id == p2_mass_20.Id).First().IsWinner.Should().BeTrue();
            result.Where(x => x.Id == p2_mass_20.Id).First().Wins.Should().Be(p2_mass_20.Wins++);
        }

        [Fact]
        public async Task PersonService_Play_Response_Verification_TheSameMass()
        {
            //arrange
            await SeedData(new[] { p2_mass_20, p4_mass_20, });
            var personService = GetRequiredService<IPersonService>();

            //act
            var result = await personService.Play();

            //assert
            result.Should().NotBeNull();
            result.Should().NotBeEmpty();
            result.Count.Should().Be(2);
            result.Where(x => x.Id == p2_mass_20.Id).First().IsWinner.Should().BeFalse();
            result.Where(x => x.Id == p4_mass_20.Id).First().IsWinner.Should().BeFalse();
            result.Where(x => x.Id == p2_mass_20.Id).First().Wins.Should().Be(p2_mass_20.Wins);
            result.Where(x => x.Id == p4_mass_20.Id).First().Wins.Should().Be(p4_mass_20.Wins);
        }
    }
}
