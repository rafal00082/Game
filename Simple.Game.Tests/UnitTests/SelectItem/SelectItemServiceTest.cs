using FluentAssertions;
using Simple.Game.Abstract.Services;
using Simple.Game.Services.Services;
using System.Linq;
using Xunit;

namespace Simple.Game.Tests.UnitTests.SelectItem
{
    public class SelectItemServiceTest
    {
        [Fact]
        public async void SelectItemService_Get()
        {
            //Arrange
            var selectItemService = new SelectItemService() as ISelectItemService;

            //Act
            var result = await selectItemService.GetPlayersKindEnumAsSelectItems();
            //Assert
            result.Should().NotBeNull();
            result.Should().NotBeEmpty();
            result.Count().Should().Be(2);
            result.Where(x => x.Id == 1 && x.Name == "People").Count().Should().Be(1);
            result.Where(x => x.Id == 2 && x.Name == "StarsShips").Count().Should().Be(1);
        }
    }
}
