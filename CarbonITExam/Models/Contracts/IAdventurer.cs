using CarbonITExam.Models.Enums;

namespace CarbonITExam.Models.Contracts
{
    public interface IAdventurer
    {
        /// <summary>
        /// Adventurer's position in the map's X axis
        /// </summary>
        int XPosition { get; set; }

        /// <summary>
        /// Adventurer's position in the map's Y axis
        /// </summary>
        int YPosition { get; set; }

        /// <summary>
        /// Adenturer's position
        /// </summary>
        string Name { get; set; }

        /// <summary>
        /// Number of treasures collected by the current adventurer
        /// </summary>
        int Treasures { get; set; }

        /// <summary>
        /// Adventurer orientation
        /// </summary>
        Orientation Orientation { get; set; }

        /// <summary>
        /// Adventurer movements
        /// </summary>
        IList<Movement> Movements { get; set; }

        /// <summary>
        /// Indicates whether the adventurer has more movements or not
        /// </summary>
        /// <returns></returns>
        bool HasMoreMovements(int currentMouvementIndex);

        /// <summary>
        /// Increment treasures number
        /// </summary>
        void CollectTreasure();

        /// <summary>
        /// Apply new position to the adventurer
        /// </summary>
        /// <param name="x">Adventurer's new X position</param>
        /// <param name="y">Adventurer's new Y position</param>
        /// <param name="orientation">Adventurer's new orientation</param>
        void ApplyNewPosition(int x, int y, Orientation orientation);
    }
}
