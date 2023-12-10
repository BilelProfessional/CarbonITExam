using CarbonITExam.Models;
using Xunit;

namespace CarbonITExam.Tests.Models
{
    public class CellTests
    {
        [Fact]
        public void HasMoreTreasures_ReturnsTrue_WhenCellTreasuresCountIsGreaterThan0()
        {
            var cell = new Cell { Treasures = 3 };

            var result = cell.HasMoreTreasures();

            Assert.True(result);
        }

        [Fact]
        public void HasMoreTreasures_ReturnsFalse_WhenCellTreasuresCountIs0()
        {
            var cell = new Cell { Treasures = 0 };

            var result = cell.HasMoreTreasures();

            Assert.False(result);
        }

        [Fact]
        public void PickTreasure_DecrementTreasuresCount_WhenTreasuresAreStillAvailable()
        {
            var cell = new Cell { Treasures = 2 };

            cell.PickTreasure();

            Assert.Equal(1, cell.Treasures);
        }

        [Fact]
        public void PickTreasure_DoesNothing_WhenTreasuresAreNoMoreAvailable()
        {
            var cell = new Cell { Treasures = 0 };

            cell.PickTreasure();

            Assert.Equal(0, cell.Treasures);
        }

        [Fact]
        public void IsAccessible_ReturnsTrue_WhenNoAdventurerOrMountainInCell()
        {
            var cell = new Cell { XPosition = 2, YPosition = 3 };

            var result = cell.IsAccessible();

            Assert.True(result);
        }

        [Fact]
        public void IsAccessible_ReturnsFalse_WhenAdventurerIsInCell()
        {
            var cell = new Cell { XPosition = 2, YPosition = 3, HasAdventurer = true };

            var result = cell.IsAccessible();

            Assert.False(result);
        }

        [Fact]
        public void IsAccessible_ReturnsFalse_WhenMountainIsInCell()
        {
            var cell = new Cell { XPosition = 2, YPosition = 3, HasMountain = true };

            var result = cell.IsAccessible();

            Assert.False(result);
        }

        [Fact]
        public void InsertAdventurer_MakesHasAdventurerToTrue()
        {
            var cell = new Cell { XPosition = 2, YPosition = 3 };

            cell.InsertAdventurer();

            Assert.True(cell.HasAdventurer);
        }

        [Fact]
        public void RemoveAdventurer_MakesHasAdventurerToFalse()
        {
            var cell = new Cell { XPosition = 2, YPosition = 3, HasAdventurer = true };

            cell.RemoveAdventurer();

            Assert.False(cell.HasAdventurer);
        }
    }
}
