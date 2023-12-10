using CarbonITExam.Models.Contracts;
using CarbonITExam.Models.Enums;

namespace CarbonITExam.Models
{
    public class Adventurer : IAdventurer
    {
        public int XPosition { get; set; }
        public int YPosition { get; set; }
        public string Name { get; set; }
        public int Treasures { get; set; }
        public Orientation Orientation { get; set; }
        public IList<Movement> Movements { get; set; }

        /// <inheritdoc />
        public void ApplyNewPosition(int x, int y, Orientation orientation)
        {
            XPosition = x;
            YPosition = y;
            Orientation = orientation;
        }

        /// <inheritdoc />
        public void CollectTreasure()
        {
            Treasures++;
        }

        /// <inheritdoc />
        public bool HasMoreMovements(int currentMouvementIndex)
        {
            return currentMouvementIndex < Movements.Count;
        }
    }
}
