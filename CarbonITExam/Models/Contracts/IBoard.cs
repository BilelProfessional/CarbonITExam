namespace CarbonITExam.Models.Contracts
{
    public interface IBoard
    {
        /// <summary>
        /// Number of total stages that will be runned during all the game
        /// </summary>
        /// <remarks>Since there is no constraint on the equality of movements lists of all adventurers, the maximum runs number should be determined</remarks>
        int TotalStages { get; set; }

        /// <summary>
        /// All adventurers
        /// </summary>
        IList<IAdventurer> Adventurers { get; set; }

        /// <summary>
        /// Indicates whether there are more stage to run or not
        /// </summary>
        /// <param name="currentStage">Current stage</param>
        bool HasMoreStages(int currentStage);
    }
}
