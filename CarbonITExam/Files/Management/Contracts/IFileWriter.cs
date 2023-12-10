using CarbonITExam.Files.Models;

namespace CarbonITExam.Files.Management.Contracts
{
    public interface IFileWriter
    {
        /// <summary>
        /// Write file with provided map, mountains, treasures and adventurers
        /// </summary>
        /// <param name="path">File's path to be written</param>
        /// <param name="map">Map details</param>
        /// <param name="mountains">Mounatains details</param>
        /// <param name="treasures">Treasures details</param>
        /// <param name="adventurers">Adventurers details</param>
        void Write(string path, MapFile map, IList<MountainFile> mountains, IList<TreasureFile> treasures, IList<AdventurerFile> adventurers);
    }
}
