using CarbonITExam.Models.Contracts;

namespace CarbonITExam.Builders.Contracts
{
    public interface IMapBuilder : IBuilder<IMap>
    {
        /// <summary>
        /// Define map dimensions
        /// </summary>
        /// <param name="x">Length of the map's X axis</param>
        /// <param name="y">Length of the map's Y axis</param>
        /// <returns></returns>
        IMapBuilder WithDimensions(int x, int y);

        /// <summary>
        /// Add mountain in the map for the provided position
        /// </summary>
        /// <param name="x">Mountain's X position</param>
        /// <param name="y">Mountain's Y position</param>
        /// <returns></returns>
        /// <remarks>Could not be executed if <see cref="WithDimensions(int, int)"/> is not already executed</remarks>
        IMapBuilder WithMountain(int x, int y);

        /// <summary>
        /// Add treasures in the map for the provided position
        /// </summary>
        /// <param name="x">Treasures X position</param>
        /// <param name="y">Treasures Y position</param>
        /// <param name="count">Treasures count</param>
        /// <returns></returns>
        /// <remarks>Could not be executed if <see cref="WithDimensions(int, int)"/> is not already executed</remarks>
        IMapBuilder WithTreasure(int x, int y, int count);

        /// <summary>
        /// Add adventurer in the map for the provided position
        /// </summary>
        /// <param name="x">Adventurer's X position</param>
        /// <param name="y">Adventurer's Y position</param>
        /// <returns></returns>
        /// <remarks>Could not be executed if <see cref="WithDimensions(int, int)"/> is not already executed</remarks>
        IMapBuilder WithAdventurer(int x, int y);
    }
}
