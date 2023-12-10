using CarbonITExam.Models;
using CarbonITExam.Models.Contracts;
using Xunit;

namespace CarbonITExam.Tests.Models
{
    public class MapTests
    {
        [Fact]
        public void GetCell_ReturnsTheCell_WhenItExists()
        {
            var map = new Map
            {
                XAxis = 2,
                YAxis = 2,
                Cells = new List<ICell>
                {
                    new Cell { XPosition = 0, YPosition = 0 },
                    new Cell { XPosition = 1, YPosition = 0 },
                    new Cell { XPosition = 0, YPosition = 1 },
                    new Cell { XPosition = 1, YPosition = 1 },
                }
            };

            var result = map.GetCell(1, 0);

            Assert.NotNull(result);
        }

        [Fact]
        public void GetCell_ReturnsNull_WhenCellIsNotFound()
        {
            var map = new Map
            {
                XAxis = 2,
                YAxis = 2,
                Cells = new List<ICell>
                {
                    new Cell { XPosition = 0, YPosition = 0 },
                    new Cell { XPosition = 1, YPosition = 0 },
                    new Cell { XPosition = 0, YPosition = 1 },
                    new Cell { XPosition = 1, YPosition = 1 },
                }
            };

            var result = map.GetCell(3, 4);

            Assert.Null(result);
        }

        [Fact]
        public void ListMountainsCells_ReturnsMountains_WhenMapContainsSomeOfThem()
        {
            var map = new Map
            {
                XAxis = 2,
                YAxis = 2,
                Cells = new List<ICell>
                {
                    new Cell { XPosition = 0, YPosition = 0 },
                    new Cell { XPosition = 1, YPosition = 0 },
                    new Cell { XPosition = 0, YPosition = 1, HasMountain = true },
                    new Cell { XPosition = 1, YPosition = 1 },
                }
            };

            var result = map.ListMountainsCells();

            Assert.Equal(1, result.Count);
            Assert.Equal(0, result[0].XPosition);
            Assert.Equal(1, result[0].YPosition);
        }

        [Fact]
        public void ListMountainsCells_ReturnsEmptyList_WhenNoMountainInTheMap()
        {
            var map = new Map
            {
                XAxis = 2,
                YAxis = 2,
                Cells = new List<ICell>
                {
                    new Cell { XPosition = 0, YPosition = 0 },
                    new Cell { XPosition = 1, YPosition = 0 },
                    new Cell { XPosition = 0, YPosition = 1 },
                    new Cell { XPosition = 1, YPosition = 1 },
                }
            };

            var result = map.ListMountainsCells();

            Assert.Empty(result);
        }

        [Fact]
        public void ListTreasuresCells_ReturnsTreasures_WhenMapContainsSomeOfThem()
        {
            var map = new Map
            {
                XAxis = 2,
                YAxis = 2,
                Cells = new List<ICell>
                {
                    new Cell { XPosition = 0, YPosition = 0 },
                    new Cell { XPosition = 1, YPosition = 0 },
                    new Cell { XPosition = 0, YPosition = 1, Treasures = 2 },
                    new Cell { XPosition = 1, YPosition = 1 },
                }
            };

            var result = map.ListTreasuresCells();

            Assert.Equal(1, result.Count);
            Assert.Equal(0, result[0].XPosition);
            Assert.Equal(1, result[0].YPosition);
            Assert.Equal(2, result[0].Treasures);
        }

        [Fact]
        public void ListTreasuresCells_ReturnsEmptyList_WhenNoTreasuresInTheMap()
        {
            var map = new Map
            {
                XAxis = 2,
                YAxis = 2,
                Cells = new List<ICell>
                {
                    new Cell { XPosition = 0, YPosition = 0 },
                    new Cell { XPosition = 1, YPosition = 0 },
                    new Cell { XPosition = 0, YPosition = 1 },
                    new Cell { XPosition = 1, YPosition = 1 },
                }
            };

            var result = map.ListTreasuresCells();

            Assert.Empty(result);
        }
    }
}
