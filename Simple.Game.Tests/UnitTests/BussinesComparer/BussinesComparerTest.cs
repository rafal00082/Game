using FluentAssertions;
using Simple.Game.Abstract.Services;
using Simple.Game.Domain.Entities;
using Simple.Game.Services.Services;
using System.Collections.Generic;
using Xunit;

namespace Simple.Game.Tests.UnitTests.BussinesComparer
{
    public class BussinesComparerTest
    {
        [Theory]
        [InlineData(0,10.2,5.3)]
        [InlineData(0, 10, 5)]
        [InlineData(1, 4, 100)]
        [InlineData(1, 2.5, 10.3)]
        [InlineData(-1, 20, 20)]
        public void BussinesComparer_Compare_Persons(int result, double mass1, double mass2)
        {
            //Arrange
            var bussinesComparer = new BussinesComparer<PersonEntity>() as IBussinesComparer<PersonEntity>;
            var personsList = new List<PersonEntity>() { new PersonEntity { Mass = mass1 }, new PersonEntity { Mass = mass2 } };

            //Act
            var index = bussinesComparer.Compare(personsList);

            //Assert
            index.Should().Be(result);
        }

        [Theory]
        [InlineData(0, 10, 5)]
        [InlineData(1, 4, 100)]
        [InlineData(-1, 20, 20)]
        public void BussinesComparer_Compare_StarsShip(int result, int crew1, int crew2)
        {
            //Arrange
            var bussinesComparer = new BussinesComparer<StarsShipEntity>() as IBussinesComparer<StarsShipEntity>;
            var personsList = new List<StarsShipEntity>() { new StarsShipEntity { Crew = crew1 }, new StarsShipEntity { Crew = crew2 } };

            //Act
            var index = bussinesComparer.Compare(personsList);

            //Assert
            index.Should().Be(result);
        }
    }
}
