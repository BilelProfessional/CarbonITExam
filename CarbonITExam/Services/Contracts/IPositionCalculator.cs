using CarbonITExam.Models.Contracts;
using CarbonITExam.Models.Enums;

namespace CarbonITExam.Services.Contracts
{
    public interface IPositionCalculator
    {
        /// <summary>
        /// Calculate next estimated adventurer's position in the map
        /// </summary>
        /// <param name="adventurer">Adventurer details</param>
        /// <param name="movementIndex">Index of movement to be done</param>
        /// <param name="changingCell">Indicates whether the adventurer will change cell or not when applying movement</param>
        /// <returns></returns>
        (int NextX, int NextY, Orientation NextOrientation) CalculateAdventurerNext(IAdventurer adventurer, int movementIndex, out bool changingCell);
    }
}
