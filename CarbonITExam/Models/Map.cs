using CarbonITExam.Models.Contracts;

namespace CarbonITExam.Models
{
    public class Map : IMap
    {
        public int XAxis { get; set; }
        public int YAxis { get; set; }
        public IList<ICell> Cells { get; set; }

        /// <inheritdoc />
        public ICell GetCell(int x, int y)
        {
            var cell = Cells.SingleOrDefault(c => c.XPosition == x && c.YPosition == y);

            return cell;
        }

        /// <inheritdoc />
        public IList<ICell> ListMountainsCells()
        {
            return Cells.Where(c => c.HasMountain).ToList();
        }

        /// <inheritdoc />
        public IList<ICell> ListTreasuresCells()
        {
            return Cells.Where(c => c.HasMoreTreasures()).ToList();
        }
    }
}
