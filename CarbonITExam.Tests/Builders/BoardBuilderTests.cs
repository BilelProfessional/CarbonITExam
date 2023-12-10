using CarbonITExam.Builders;
using CarbonITExam.Models.Enums;
using CarbonITExam.Services.Contracts;
using FakeItEasy;
using Xunit;

namespace CarbonITExam.Tests.Builders
{
    public class BoardBuilderTests
    {
        private readonly IMovementTranslator _movementTranslator;
        private readonly IOrientationTranslator _orientationTranslator;
        private readonly BoardBuilder _builder;

        public BoardBuilderTests()
        {
            _orientationTranslator = A.Fake<IOrientationTranslator>();
            _movementTranslator = A.Fake<IMovementTranslator>();
        }

        [Fact]
        public void Build_DefinesAllBoard()
        {
            var adventurer1Orientation = "N";
            var adventurer2Orientation = "S";
            var adventurer1Movements = "ADG";
            var adventurer2Movements = "DG";

            A.CallTo(() => _orientationTranslator.Translate(adventurer1Orientation)).Returns(Orientation.N);
            A.CallTo(() => _orientationTranslator.Translate(adventurer2Orientation)).Returns(Orientation.S);
            A.CallTo(() => _movementTranslator.Translate(adventurer1Movements)).Returns(new List<Movement> { Movement.A, Movement.D, Movement.G });
            A.CallTo(() => _movementTranslator.Translate(adventurer2Movements)).Returns(new List<Movement> { Movement.D, Movement.G });

            var builder = new BoardBuilder(_movementTranslator, _orientationTranslator);

            builder
                .WithAdventurer(1, 1, "a1", adventurer1Orientation, adventurer1Movements)
                .WithAdventurer(2, 2, "a2", adventurer2Orientation, adventurer2Movements);

            var board = builder.Build();

            Assert.Equal(3, board.TotalStages);
            Assert.Equal(2, board.Adventurers.Count);
            Assert.Equal("a1", board.Adventurers[0].Name);
            Assert.Equal(Orientation.N, board.Adventurers[0].Orientation);
            Assert.Equal("a2", board.Adventurers[1].Name);
            Assert.Equal(Orientation.S, board.Adventurers[1].Orientation);
        }
    }
}
