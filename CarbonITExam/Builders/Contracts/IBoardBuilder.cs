using CarbonITExam.Models.Contracts;

namespace CarbonITExam.Builders.Contracts
{
    public interface IBoardBuilder : IBuilder<IBoard>
    {
        /// <summary>
        /// Add adventurer in the board for the provided details
        /// </summary>
        /// <param name="x">Adventurer's X position</param>
        /// <param name="y">Adventurer's Y position</param>
        /// <param name="name">Adventurer's name</param>
        /// <param name="orientation">Adventurer's orientation</param>
        /// <param name="movements">Adventurer's movements</param>
        /// <returns></returns>
        IBoardBuilder WithAdventurer(int x, int y, string name, string orientation, string movements);
    }
}
