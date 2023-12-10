using CarbonITExam.Models;
using CarbonITExam.Models.Enums;
using Xunit;

namespace CarbonITExam.Tests.Models
{
    public class AdventurerTests
    {
        [Fact]
        public void ApplyNewPosition_UpdateXAndYAndOrientation()
        {
            var adventurer = new Adventurer
            {
                XPosition = 2,
                YPosition = 1,
                Orientation = Orientation.S
            };

            adventurer.ApplyNewPosition(3, 0, Orientation.N);

            Assert.Equal(3, adventurer.XPosition);
            Assert.Equal(0, adventurer.YPosition);
            Assert.Equal(Orientation.N, adventurer.Orientation);
        }

        [Fact]
        public void CollectTreasure_IncrementAdventurerTreasuresCount()
        {
            var adventurer = new Adventurer
            {
                XPosition = 1,
                YPosition = 1,
                Treasures = 3
            };

            adventurer.CollectTreasure();

            Assert.Equal(4, adventurer.Treasures);
        }

        [Fact]
        public void HasMoreMovements_ReturnsTrue_WhenCurrentIndexIsLessThanMovementsCount()
        {
            var adventurer = new Adventurer
            {
                XPosition = 1,
                YPosition = 1,
                Movements = new List<Movement> { Movement.A, Movement.D, Movement.A, Movement.G }
            };

            var result = adventurer.HasMoreMovements(2);

            Assert.True(result);
        }

        [Fact]
        public void HasMoreMovements_ReturnsFalse_WhenCurrentIndexIsGreaterThanMovementsCount()
        {
            var adventurer = new Adventurer
            {
                XPosition = 1,
                YPosition = 1,
                Movements = new List<Movement> { Movement.A, Movement.D, Movement.A, Movement.G }
            };

            var result = adventurer.HasMoreMovements(5);

            Assert.False(result);
        }

        [Fact]
        public void HasMoreMovements_ReturnsFalse_WhenCurrentIndexIsEqualToMovementsCount()
        {
            var adventurer = new Adventurer
            {
                XPosition = 1,
                YPosition = 1,
                Movements = new List<Movement> { Movement.A, Movement.D, Movement.A, Movement.G }
            };

            var result = adventurer.HasMoreMovements(4);

            Assert.False(result);
        }
    }
}
