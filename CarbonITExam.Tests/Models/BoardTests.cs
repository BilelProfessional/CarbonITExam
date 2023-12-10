using CarbonITExam.Models;
using Xunit;

namespace CarbonITExam.Tests.Models
{
    public class BoardTests
    {
        [Fact]
        public void HasMoreStages_ReturnsFalse_WhenInputIsGreaterThanTotalStages()
        {
            var board = new Board
            {
                TotalStages = 3,
            };

            var result = board.HasMoreStages(5);

            Assert.False(result);
        }

        [Fact]
        public void HasMoreStages_ReturnsFalse_WhenInputIsEqualToTotalStages()
        {
            var board = new Board
            {
                TotalStages = 3,
            };

            var result = board.HasMoreStages(3);

            Assert.False(result);
        }

        [Fact]
        public void HasMoreStages_ReturnsTrue_WhenInputIsLessThanTotalStages()
        {
            var board = new Board
            {
                TotalStages = 3,
            };

            var result = board.HasMoreStages(2);

            Assert.True(result);
        }
    }
}
