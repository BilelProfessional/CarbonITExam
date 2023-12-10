using CarbonITExam.Files.Management.Constants;
using CarbonITExam.Files.Management.Contracts;
using CarbonITExam.Files.Models;

namespace CarbonITExam.Files.Management
{
    public class TextFileReader : IFileReader
    {
        private MapFile _mapFile;
        private readonly IList<MountainFile> _mountains = new List<MountainFile>();
        private readonly IList<TreasureFile> _treasures = new List<TreasureFile>();
        private readonly IList<AdventurerFile> _adventurers = new List<AdventurerFile>();

        /// <inheritdoc />
        public (MapFile Map, IList<MountainFile> Mountains, IList<TreasureFile> Treasures, IList<AdventurerFile> Adventurers) Read(string path)
        {
            if (path == null) throw new ArgumentNullException(nameof(File));
            if (!File.Exists(path)) throw new FileNotFoundException(nameof(path));

            using (var sr = new StreamReader(path))
            {
                while (sr.Peek() >= 0)
                {
                    var line = sr.ReadLine();
                    if (line.StartsWith(TextFileConstants.MapStartLine)) HandleMap(line);
                    else if (line.StartsWith(TextFileConstants.TreasureStartLine)) HandleTreasure(line);
                    else if (line.StartsWith(TextFileConstants.MountainStartLine)) HandleMountain(line);
                    else if (line.StartsWith(TextFileConstants.AdventurerStartLine)) HandleAdventurer(line);
                }
            }

            return (_mapFile, _mountains, _treasures, _adventurers);
        }

        private void HandleMap(string line)
        {
            if (_mapFile != null) throw new InvalidOperationException("Could not set map multiple times");

            var fragments = line.Split(TextFileConstants.Separator);
            if (fragments.Length != 3
                || !int.TryParse(fragments[1], out var x)
                || !int.TryParse(fragments[2], out var y)) 
                throw new InvalidOperationException("Invalid map input");

            _mapFile = new MapFile { XAxis = x, YAxis =  y }; 
        }

        private void HandleMountain(string line)
        {
            var fragments = line.Split(TextFileConstants.Separator);
            if (fragments.Length != 3
                || !int.TryParse(fragments[1], out var x)
                || !int.TryParse(fragments[2], out var y)) 
                throw new InvalidOperationException("Invalid mountain input");

            _mountains.Add(new MountainFile { XPosition = x, YPosition = y });
        }

        private void HandleTreasure(string line)
        {
            var fragments = line.Split(TextFileConstants.Separator);
            if (fragments.Length != 4 
                || !int.TryParse(fragments[1], out var x)
                || !int.TryParse(fragments[2], out var y)
                || !int.TryParse(fragments[3], out var count)) 
                throw new InvalidOperationException("Invalid treasure input");

            _treasures.Add(new TreasureFile
            {
                XPosition = x,
                YPosition = y,
                Count = count
            });
        }

        private void HandleAdventurer(string line)
        {
            var fragments = line.Split(TextFileConstants.Separator);
            if (fragments.Length != 6
                || !int.TryParse(fragments[2], out var x)
                || !int.TryParse(fragments[3], out var y)
                || fragments[4].Length != 1)
                throw new InvalidOperationException("Invalid adventurer input");

            _adventurers.Add(new AdventurerFile
            {
                Name = fragments[1],
                XPosition= x,
                YPosition= y,
                Orientation = fragments[4],
                Movements = fragments[5]
            });
        }
    }
}
