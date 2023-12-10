namespace CarbonITExam.Models.Contracts
{
    public interface ICell
    {
        /// <summary>
        /// Cell's position in the map's X axis 
        /// </summary>
        int XPosition { get; set; }

        /// <summary>
        /// Cell's position in the map's Y axis
        /// </summary>
        int YPosition { get; set; }

        /// <summary>
        /// Number of available treasures in the current cell
        /// </summary>
        int Treasures { get; set; }

        /// <summary>
        /// Indicates whether if the current has mountain or not
        /// </summary>
        bool HasMountain { get; set; }

        /// <summary>
        /// Indicates whether if the current cell is taken by an adventurer or not
        /// </summary>
        bool HasAdventurer { get; set; }

        /// <summary>
        /// Indicates whether the cell is accessible or not
        /// </summary>
        /// <returns></returns>
        bool IsAccessible();

        /// <summary>
        /// Indicates whether the cell has more treasures or not
        /// </summary>
        /// <returns></returns>
        bool HasMoreTreasures();

        /// <summary>
        /// Decrement number of treasures
        /// </summary>
        void PickTreasure();

        /// <summary>
        /// Insert adventurer in cell
        /// </summary>
        void InsertAdventurer();

        /// <summary>
        /// Remove adventurer from cell
        /// </summary>
        void RemoveAdventurer();
    }
}
