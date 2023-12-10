using CarbonITExam.Builders.Contracts;
using CarbonITExam.Files.Management.Contracts;
using CarbonITExam.Files.Models;
using CarbonITExam.Models.Contracts;
using CarbonITExam.Services.Contracts;

namespace CarbonITExam.Services
{
    internal class GameService : IGameService
    {
        private readonly IMapBuilder _mapBuilder;
        private readonly IBoardBuilder _boardBuilder;
        private readonly IPositionCalculator _positionCalculator;
        private readonly IOrientationTranslator _orientationTranslator;
        private readonly IFileReader _fileReader;
        private readonly IFileWriter _fileWriter;

        public GameService(IMapBuilder mapBuilder, 
            IBoardBuilder boardBuilder, 
            IPositionCalculator positionCalculator,
            IOrientationTranslator orientationTranslator,
            IFileReader fileReader, 
            IFileWriter fileWriter)
        {
            _mapBuilder = mapBuilder;
            _boardBuilder = boardBuilder;
            _positionCalculator = positionCalculator;
            _orientationTranslator = orientationTranslator;
            _fileReader = fileReader;
            _fileWriter = fileWriter;
        }

        /// <inheritdoc />
        public void Play(string inputName)
        {
            var basePath = Directory.GetCurrentDirectory().Replace("\\bin\\Debug\\net6.0", "");

            // Reading file
            var (mapInput, mountainsInput, treasuresInput, adventurersInput) = _fileReader.Read(Path.Combine(basePath, "Files\\Inputs", inputName));

            // Build Map and Board
            var map = BuildMap(mapInput, mountainsInput, treasuresInput, adventurersInput);
            var board = BuildBoard(adventurersInput);

            // Game execution
            var i = 0;
            while (board.HasMoreStages(i))
            {
                foreach (var adventurer in board.Adventurers)
                {
                    if (!adventurer.HasMoreMovements(i))
                    {
                        continue; // The adventurer has completed all his movements
                    }

                    var nextPosition = _positionCalculator.CalculateAdventurerNext(adventurer, i, out var changingCell);

                    if (!changingCell)
                    {
                        // only change orientation, nothing to do else because adventurer has only changed orientation
                        adventurer.ApplyNewPosition(nextPosition.NextX, nextPosition.NextY, nextPosition.NextOrientation);
                        continue;
                    }

                    var currentCell = map.GetCell(adventurer.XPosition, adventurer.YPosition);
                    var nextCell = map.GetCell(nextPosition.NextX, nextPosition.NextY);

                    if (nextCell is null || !nextCell.IsAccessible())
                    {
                        // Nothing to do because adventurer riched map board or the next cell is not accessible
                        continue; 
                    }

                    adventurer.ApplyNewPosition(nextPosition.NextX, nextPosition.NextY, nextPosition.NextOrientation);
                    currentCell.RemoveAdventurer();
                    nextCell.InsertAdventurer();
                    if (nextCell.HasMoreTreasures())
                    {
                        nextCell.PickTreasure();
                        adventurer.CollectTreasure();
                    }
                }

                i++;
            }

            // Preparing and writing output file
            var mapOutput = new MapFile { XAxis = map.XAxis, YAxis = map.YAxis };
            var mountainsOutput = map.ListMountainsCells()
                .Select(c => new MountainFile { XPosition  = c.XPosition, YPosition = c.YPosition })
                .ToList();
            var treasuresOutput = map.ListTreasuresCells()
                .Select(c => new TreasureFile { XPosition = c.XPosition, YPosition = c.YPosition, Count = c.Treasures })
                .ToList();
            var adventurersOutput = board
                .Adventurers
                .Select(a => new AdventurerFile
                {
                    Name = a.Name,
                    Orientation = _orientationTranslator.Translate(a.Orientation),
                    XPosition = a.XPosition,
                    YPosition = a.YPosition,
                    Treasures = a.Treasures
                })
                .ToList();
            var outputName = $"Result execution {DateTimeAsString(DateTime.Now)} {inputName}";

            _fileWriter.Write(Path.Combine(basePath, "Files\\Outputs", outputName),
                mapOutput,
                mountainsOutput,
                treasuresOutput,
                adventurersOutput);
            Console.WriteLine($"Please find your execution result of '{inputName}' file in '{outputName}' file");
        }

        private IMap BuildMap(MapFile mapInput, 
            IList<MountainFile> mountainsInput, 
            IList<TreasureFile> treasuresInput, 
            IList<AdventurerFile> adventurersInput)
        {
            _mapBuilder.WithDimensions(mapInput.XAxis, mapInput.YAxis);

            foreach (var mountainInput in mountainsInput)
            {
                _mapBuilder.WithMountain(mountainInput.XPosition, mountainInput.YPosition);
            }

            foreach (var treasureInput in treasuresInput)
            {
                _mapBuilder.WithTreasure(treasureInput.XPosition, treasureInput.YPosition, treasureInput.Count);
            }

            foreach (var adventurerInput in adventurersInput)
            {
                _mapBuilder.WithAdventurer(adventurerInput.XPosition, adventurerInput.YPosition);
            }

            return _mapBuilder.Build();
        }

        private IBoard BuildBoard(IList<AdventurerFile> adventurersInput)
        {
            foreach (var adventurerInput in adventurersInput)
            {
                _boardBuilder.WithAdventurer(adventurerInput.XPosition,
                    adventurerInput.YPosition,
                    adventurerInput.Name,
                    adventurerInput.Orientation,
                    adventurerInput.Movements);
            }

            return _boardBuilder.Build();
        }

        private string DateTimeAsString(DateTime dateTime)
        {
            return dateTime.ToString("yyyy MM dd HH mm ss ff").Replace(" ", "");
        }
    }
}
