using CarbonITExam.Builders.Contracts;
using CarbonITExam.Models;
using CarbonITExam.Models.Contracts;
using CarbonITExam.Services.Contracts;

namespace CarbonITExam.Builders
{
    public class BoardBuilder : IBoardBuilder
    {
        private readonly IMovementTranslator _movementTranslator;
        private readonly IOrientationTranslator _orientationTranslator;

        private IList<IAdventurer> _adventurers = new List<IAdventurer>();

        public BoardBuilder(IMovementTranslator movementTranslator, IOrientationTranslator orientationTranslator)
        {
            _movementTranslator = movementTranslator;
            _orientationTranslator = orientationTranslator;
        }

        /// <inheritdoc />
        public IBoardBuilder WithAdventurer(int x, int y, string name, string orientation, string movements)
        {
            _adventurers.Add(new Adventurer
            {
                XPosition = x,
                YPosition = y,
                Name = name,
                Treasures = 0,
                Movements = _movementTranslator.Translate(movements),
                Orientation = _orientationTranslator.Translate(orientation),
            });

            return this;
        }

        /// <inheritdoc />
        public IBoard Build()
        {
            return new Board
            {
                Adventurers = _adventurers,
                TotalStages = _adventurers.Select(a => a.Movements).Max(m => m.Count),
            };
        }
    }
}
