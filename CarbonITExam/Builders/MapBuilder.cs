using CarbonITExam.Builders.Contracts;
using CarbonITExam.Models;
using CarbonITExam.Models.Contracts;

namespace CarbonITExam.Builders
{
    public class MapBuilder : IMapBuilder
    {
        private bool _areDimensionsDefined;
        private int _x;
        private int _y;
        private IList<(int X, int Y)> _adventurers = new List<(int X, int Y)>();
        private IList<(int X, int Y)> _mountains = new List<(int X, int Y)>();
        private IList<(int X, int Y, int Count)> _treasures = new List<(int X, int Y, int Count)>();

        /// <inheritdoc />
        public IMapBuilder WithDimensions(int x, int y)
        {
            if (x < 0) throw new ArgumentOutOfRangeException(nameof(x), "Length of map's X axis should be positive");
            if (y < 0) throw new ArgumentOutOfRangeException(nameof(y), "Length of map's Y axis should be positive");

            _x = x;
            _y = y;
            _areDimensionsDefined = true;

            return this;
        }

        /// <inheritdoc />
        public IMapBuilder WithAdventurer(int x, int y)
        {
            if (!_areDimensionsDefined) throw new InvalidOperationException("Map's dimensions are not already defined");
            if (x < 0 || x >= _x) throw new ArgumentOutOfRangeException(nameof(x), "Adventurer's X position is out of map's border");
            if (y < 0 || y >= _y) throw new ArgumentOutOfRangeException(nameof(y), "Adventurer's Y position is out of map's border");
            if (_adventurers.Any(a => a.X == x && a.Y == y)) 
                throw new InvalidOperationException($"An adventurer is already presented in the cell with x {x} and y {y}");

            _adventurers.Add((x, y));

            return this;
        }

        /// <inheritdoc />
        public IMapBuilder WithMountain(int x, int y)
        {
            if (!_areDimensionsDefined) throw new InvalidOperationException("Map's dimensions are not already defined");
            if (x < 0 || x >= _x) throw new ArgumentOutOfRangeException(nameof(x), "Mountain's X position is out of map's border");
            if (y < 0 || y >= _y) throw new ArgumentOutOfRangeException(nameof(y), "Mountain's Y position is out of map's border");
            if (_mountains.Any(m => m.X == x && m.Y == y))
                throw new InvalidOperationException($"A mountain is already presented in the cell with x {x} and y {y}");
            _mountains.Add((x, y));

            return this;
        }

        /// <inheritdoc />
        public IMapBuilder WithTreasure(int x, int y, int count)
        {
            if (!_areDimensionsDefined) throw new InvalidOperationException("Map's dimensions are not already defined");
            if (x < 0 || x >= _x) throw new ArgumentOutOfRangeException(nameof(x), "Treasure's X position is out of map's border");
            if (y < 0 || y >= _y) throw new ArgumentOutOfRangeException(nameof(y), "Treasure's Y position is out of map's border");
            if (count < 0) throw new ArgumentOutOfRangeException(nameof(count), "Number of treasures could not be less than 0");
            if (_treasures.Any(t => t.X == x && t.Y == y))
                throw new InvalidOperationException($"A treasure is already presented in the cell with x {x} and y {y}");

            if (count > 0) _treasures.Add((x, y, count));

            return this;
        }

        /// <inheritdoc />
        public IMap Build()
        {
            var map = new Map
            {
                XAxis = _x,
                YAxis = _y,
                Cells = new List<ICell>()
            };

            for (var i = 0; i < map.XAxis; i++)
            {
                for (var j =  0; j < map.YAxis; j++)
                {
                    var cell = new Cell
                    {
                        XPosition = i,
                        YPosition = j,
                        HasAdventurer = _adventurers.Any(a => a.X == i && a.Y == j),
                        HasMountain = _mountains.Any(m => m.X == i && m.Y == j),
                        Treasures = _treasures.FirstOrDefault(t => t.X == i && t.Y == j).Count
                    };

                    if (cell.HasMountain && cell.HasAdventurer)
                        throw new InvalidOperationException($"Cell with x {i} and y {j} could not have mountain and an adventurer at the same time");

                    if (cell.HasMountain && cell.Treasures > 0)
                        throw new InvalidOperationException($"Cell with x {i} and y {j} could not have mountain and treasures at the same time");

                    map.Cells.Add(cell);
                }
            }

            return map;
        }
    }
}
