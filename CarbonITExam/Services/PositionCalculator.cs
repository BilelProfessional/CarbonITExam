using CarbonITExam.Models.Contracts;
using CarbonITExam.Models.Enums;
using CarbonITExam.Services.Contracts;

namespace CarbonITExam.Services
{
    public class PositionCalculator : IPositionCalculator
    {
        private static IDictionary<Orientation, IDictionary<Movement, (int IncrementX, int IncrementY, Orientation NextOrientation)>>
            AdventurePositionCalculationMatrix =
            new Dictionary<Orientation, IDictionary<Movement, (int IncrementX, int IncrementY, Orientation NextOrientation)>>
            {
                {
                    Orientation.N, new Dictionary<Movement,(int IncrementX, int IncrementY, Orientation NextOrientation)>
                    {
                        { Movement.A, (0, -1, Orientation.N) },
                        { Movement.D, (0, 0, Orientation.E) },
                        { Movement.G, (0, 0, Orientation.O) }
                    }
                },
                {
                    Orientation.S, new Dictionary<Movement,(int IncrementX, int IncrementY, Orientation NextOrientation)>
                    {
                        { Movement.A, (0, 1, Orientation.S) },
                        { Movement.D, (0, 0, Orientation.O) },
                        { Movement.G, (0, 0, Orientation.E) }
                    }
                },
                {
                    Orientation.E, new Dictionary<Movement,(int IncrementX, int IncrementY, Orientation NextOrientation)>
                    {
                        { Movement.A, (1, 0, Orientation.E) },
                        { Movement.D, (0, 0, Orientation.S) },
                        { Movement.G, (0, 0, Orientation.N) }
                    }
                },
                {
                    Orientation.O, new Dictionary<Movement,(int IncrementX, int IncrementY, Orientation NextOrientation)>
                    {
                        { Movement.A, (-1, 0, Orientation.O) },
                        { Movement.D, (0, 0, Orientation.N) },
                        { Movement.G, (0, 0, Orientation.S) }
                    }
                }
            };

        public (int NextX, int NextY, Orientation NextOrientation) CalculateAdventurerNext(IAdventurer adventurer,
            int movementIndex, 
            out bool changingCell)
        {
            var nextPositionCalculation = AdventurePositionCalculationMatrix[adventurer.Orientation][adventurer.Movements[movementIndex]];

            changingCell = nextPositionCalculation.IncrementX != 0 || nextPositionCalculation.IncrementY != 0;
            return 
                (adventurer.XPosition + nextPositionCalculation.IncrementX, 
                adventurer.YPosition + nextPositionCalculation.IncrementY, 
                nextPositionCalculation.NextOrientation);
        }
    }
}
