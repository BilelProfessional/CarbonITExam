using CarbonITExam.Models.Contracts;

namespace CarbonITExam.Models
{
    public class Board : IBoard
    {
        public int TotalStages { get; set; }
        public IList<IAdventurer> Adventurers { get; set; }

        /// <inheritdoc />
        public bool HasMoreStages(int currentStage)
        {
            return currentStage < TotalStages;
        }
    }
}
