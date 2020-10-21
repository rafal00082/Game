using FluentAssertions;
using Simple.Game.Abstract.Repositories;
using Simple.Game.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Simple.Game.Tests.IntegrationTests.PersonServiceTest
{
    public class StarsShipRepositoryTest : BaseIntegrationTest
    {
        public static PersonEntity p1_mass_10 = new PersonEntity { Id = 1, Name = "1TestPerson1", Mass = 10.5, Wins = 1 };
        public static PersonEntity p2_mass_20 = new PersonEntity { Id = 2, Name = "3TestPerson2", Mass = 20, Wins = 20 };
        public static PersonEntity p3_mass_30 = new PersonEntity { Id = 3, Name = "4TestPerson3", Mass = 30, Wins = 3 };
        public static PersonEntity p4_mass_20 = new PersonEntity { Id = 4, Name = "2TestPerson4", Mass = 20, Wins = 40 };


        [Theory]
        [InlineData(1, 2, 2)]
        [InlineData(1, 10, 4)]
        [InlineData(1, 100, 4)]
        [InlineData(4, 1, 1)]
        [InlineData(4, 5, 0)]
        [InlineData(-1, 3, 3)]
        public async Task PersonRepository_Get(int pageNumber, int pageSize, int amount)
        {
            //arrange
            await SeedData(new[] { p1_mass_10, p2_mass_20, p3_mass_30, p4_mass_20 });
            var repository = GetRequiredService<IPlayerRepository<PersonEntity>>();

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
        public async Task PersonRepository_Get_DefaultSort(string sortBy, string order)
        {
            //arrange
            await SeedData(new[] { p1_mass_10, p2_mass_20, p3_mass_30, p4_mass_20 });
            var repository = GetRequiredService<IPlayerRepository<PersonEntity>>();

            //act
            var result = await repository.Get(1,50, sortBy, order);

            //assert
            result.Should().NotBeNull();
            result.Should().NotBeEmpty();
            result.Count.Should().Be(4);
            result.First().Id.Should().Be(p1_mass_10.Id);
            result.Last().Id.Should().Be(p4_mass_20.Id);
        }

        [Theory]
        [InlineData("", "desc")]
        [InlineData("aaa", "desc")]
        [InlineData("Wins", "desc")]
        public async Task PersonRepository_Get_DescendingSort(string sortBy, string order)
        {
            //arrange
            await SeedData(new[] { p1_mass_10, p2_mass_20, p3_mass_30, p4_mass_20 });
            var repository = GetRequiredService<IPlayerRepository<PersonEntity>>();

            //act
            var result = await repository.Get(1, 50, sortBy, order);

            //assert
            result.Should().NotBeNull();
            result.Should().NotBeEmpty();
            result.Count.Should().Be(4);
            result.Last().Id.Should().Be(p1_mass_10.Id);
            result.First().Id.Should().Be(p4_mass_20.Id);
        }

        [Fact]
        public async Task PersonRepository_Get_DescendingSortByName()
        {
            //arrange
            await SeedData(new[] { p1_mass_10, p2_mass_20, p3_mass_30, p4_mass_20 });
            var repository = GetRequiredService<IPlayerRepository<PersonEntity>>();

            //act
            var result = await repository.Get(1, 50, "Name", "desc");

            //assert
            result.Should().NotBeNull();
            result.Should().NotBeEmpty();
            result.Count.Should().Be(4);
            result.Last().Id.Should().Be(p1_mass_10.Id);
            result.First().Id.Should().Be(p3_mass_30.Id);
        }
    }
}
