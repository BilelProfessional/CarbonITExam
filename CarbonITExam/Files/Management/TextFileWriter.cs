using CarbonITExam.Files.Management.Constants;
using CarbonITExam.Files.Management.Contracts;
using CarbonITExam.Files.Models;

namespace CarbonITExam.Files.Management
{
    public class TextFileWriter : IFileWriter
    {
        /// <inheritdoc />
        public void Write(string path, MapFile map, IList<MountainFile> mountains, IList<TreasureFile> treasures, IList<AdventurerFile> adventurers)
        {
            if (path == null) throw new ArgumentNullException(nameof(path));

            using (var sw = new StreamWriter(path))
            {
                sw.WriteLine($"{TextFileConstants.MapStartLine}" +
                    $"{TextFileConstants.Separator}" +
                    $"{map.XAxis}" +
                    $"{TextFileConstants.Separator}" +
                    $"{map.YAxis}");

                foreach (var mountain in mountains)
                {
                    sw.WriteLine($"{TextFileConstants.MountainStartLine}" +
                        $"{TextFileConstants.Separator}" +
                        $"{mountain.XPosition}" +
                        $"{TextFileConstants.Separator}" +
                        $"{mountain.YPosition}");
                }

                foreach (var treasure in treasures)
                {
                    sw.WriteLine($"{TextFileConstants.TreasureStartLine}" +
                        $"{TextFileConstants.Separator}" +
                        $"{treasure.XPosition}" +
                        $"{TextFileConstants.Separator}" +
                        $"{treasure.YPosition}" +
                        $"{TextFileConstants.Separator}" +
                        $"{treasure.Count}");
                }

                foreach (var adventurer in adventurers)
                {
                    sw.WriteLine($"{TextFileConstants.AdventurerStartLine}" +
                        $"{TextFileConstants.Separator}" +
                        $"{adventurer.Name}" +
                        $"{TextFileConstants.Separator}" +
                        $"{adventurer.XPosition}" +
                        $"{TextFileConstants.Separator}" +
                        $"{adventurer.YPosition}" +
                        $"{TextFileConstants.Separator}" +
                        $"{adventurer.Orientation}" +
                        $"{TextFileConstants.Separator}" +
                        $"{adventurer.Treasures}");
                }
            }
        }
    }
}
