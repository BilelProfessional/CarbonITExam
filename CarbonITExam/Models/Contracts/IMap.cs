namespace CarbonITExam.Models.Contracts
{
    public interface IMap
    {
        /// <summary>
        /// Length of the map's X axis
        /// </summary>
        int XAxis { get; set; }

        /// <summary>
        /// Length of the map's Y axis
        /// </summary>
        int YAxis { get; set; }

        /// <summary>
        /// Map's cells
        /// </summary>
        IList<ICell> Cells { get; set; }

        /// <summary>
        /// Get cell by its X and Y position
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        ICell GetCell(int x, int y);

        /// <summary>
        /// List all cells that contain mountain
        /// </summary>
        /// <returns></returns>
        IList<ICell> ListMountainsCells();

        /// <summary>
        /// List all cells that contain treasure
        /// </summary>
        /// <returns></returns>
        IList<ICell> ListTreasuresCells();
    }
}
