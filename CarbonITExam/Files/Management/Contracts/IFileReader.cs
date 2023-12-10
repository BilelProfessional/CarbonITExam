using CarbonITExam.Files.Models;

namespace CarbonITExam.Files.Management.Contracts
{
    public interface IFileReader
    {
        /// <summary>
        /// Read the file to extract map, mountains, treasures and adventurers
        /// </summary>
        /// <param name="path">File's path to be read</param>
        /// <returns></returns>
        (MapFile Map, IList<MountainFile> Mountains, IList<TreasureFile> Treasures, IList<AdventurerFile> Adventurers) Read(string path);
    }
}
