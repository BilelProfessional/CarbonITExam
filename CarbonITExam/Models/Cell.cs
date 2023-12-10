using CarbonITExam.Models.Contracts;

namespace CarbonITExam.Models
{
    public class Cell : ICell
    {
        public int XPosition { get; set; }
        public int YPosition { get; set; }
        public int Treasures { get; set; }
        public bool HasMountain { get; set; }
        public bool HasAdventurer { get; set; }

        /// <inheritdoc />
        public bool HasMoreTreasures()
        {
            return Treasures > 0;
        }

        /// <inheritdoc />
        public void PickTreasure()
        {
            if (HasMoreTreasures()) Treasures--;
        }

        /// <inheritdoc />
        public bool IsAccessible()
        {
            return !HasMountain && !HasAdventurer;
        }

        /// <inheritdoc />
        public void InsertAdventurer()
        {
            HasAdventurer = true;
        }

        /// <inheritdoc />
        public void RemoveAdventurer()
        {
            HasAdventurer = false;
        }
    }
}
