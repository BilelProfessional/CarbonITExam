using CarbonITExam.Models;
using CarbonITExam.Models.Enums;
using CarbonITExam.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace CarbonITExam.Tests.Services
{
    public class PositionCalculatorTests
    {
        [Fact]
        public void CalculateAdventurerNext_WhenCurrentOrientationIsNAndMovementIsA()
        {
            var calculator = new PositionCalculator();
            var adventurer = new Adventurer
            {

                Orientation = Orientation.N,
                Movements = new List<Movement> { Movement.A },
                XPosition = 1,
                YPosition = 1
            };

            var result = calculator.CalculateAdventurerNext(adventurer, 0, out var changingCell);

            Assert.True(changingCell);
            Assert.Equal(1, result.NextX);
            Assert.Equal(0, result.NextY);
            Assert.Equal(Orientation.N, result.NextOrientation);
        }

        [Fact]
        public void CalculateAdventurerNext_WhenCurrentOrientationIsNAndMovementIsD()
        {
            var calculator = new PositionCalculator();
            var adventurer = new Adventurer
            {

                Orientation = Orientation.N,
                Movements = new List<Movement> { Movement.D },
                XPosition = 1,
                YPosition = 1
            };

            var result = calculator.CalculateAdventurerNext(adventurer, 0, out var changingCell);

            Assert.False(changingCell);
            Assert.Equal(1, result.NextX);
            Assert.Equal(1, result.NextY);
            Assert.Equal(Orientation.E, result.NextOrientation);
        }

        [Fact]
        public void CalculateAdventurerNext_WhenCurrentOrientationIsNAndMovementIsG()
        {
            var calculator = new PositionCalculator();
            var adventurer = new Adventurer
            {

                Orientation = Orientation.N,
                Movements = new List<Movement> { Movement.G },
                XPosition = 1,
                YPosition = 1
            };

            var result = calculator.CalculateAdventurerNext(adventurer, 0, out var changingCell);

            Assert.False(changingCell);
            Assert.Equal(1, result.NextX);
            Assert.Equal(1, result.NextY);
            Assert.Equal(Orientation.O, result.NextOrientation);
        }

        [Fact]
        public void CalculateAdventurerNext_WhenCurrentOrientationIsSAndMovementIsA()
        {
            var calculator = new PositionCalculator();
            var adventurer = new Adventurer
            {

                Orientation = Orientation.S,
                Movements = new List<Movement> { Movement.A },
                XPosition = 1,
                YPosition = 1
            };

            var result = calculator.CalculateAdventurerNext(adventurer, 0, out var changingCell);

            Assert.True(changingCell);
            Assert.Equal(1, result.NextX);
            Assert.Equal(2, result.NextY);
            Assert.Equal(Orientation.S, result.NextOrientation);
        }

        [Fact]
        public void CalculateAdventurerNext_WhenCurrentOrientationIsSAndMovementIsD()
        {
            var calculator = new PositionCalculator();
            var adventurer = new Adventurer
            {

                Orientation = Orientation.S,
                Movements = new List<Movement> { Movement.D },
                XPosition = 1,
                YPosition = 1
            };

            var result = calculator.CalculateAdventurerNext(adventurer, 0, out var changingCell);

            Assert.False(changingCell);
            Assert.Equal(1, result.NextX);
            Assert.Equal(1, result.NextY);
            Assert.Equal(Orientation.O, result.NextOrientation);
        }

        [Fact]
        public void CalculateAdventurerNext_WhenCurrentOrientationIsSAndMovementIsG()
        {
            var calculator = new PositionCalculator();
            var adventurer = new Adventurer
            {

                Orientation = Orientation.S,
                Movements = new List<Movement> { Movement.G },
                XPosition = 1,
                YPosition = 1
            };

            var result = calculator.CalculateAdventurerNext(adventurer, 0, out var changingCell);

            Assert.False(changingCell);
            Assert.Equal(1, result.NextX);
            Assert.Equal(1, result.NextY);
            Assert.Equal(Orientation.E, result.NextOrientation);
        }

        [Fact]
        public void CalculateAdventurerNext_WhenCurrentOrientationIsEAndMovementIsA()
        {
            var calculator = new PositionCalculator();
            var adventurer = new Adventurer
            {

                Orientation = Orientation.E,
                Movements = new List<Movement> { Movement.A },
                XPosition = 1,
                YPosition = 1
            };

            var result = calculator.CalculateAdventurerNext(adventurer, 0, out var changingCell);

            Assert.True(changingCell);
            Assert.Equal(2, result.NextX);
            Assert.Equal(1, result.NextY);
            Assert.Equal(Orientation.E, result.NextOrientation);
        }

        [Fact]
        public void CalculateAdventurerNext_WhenCurrentOrientationIsEAndMovementIsD()
        {
            var calculator = new PositionCalculator();
            var adventurer = new Adventurer
            {

                Orientation = Orientation.E,
                Movements = new List<Movement> { Movement.D },
                XPosition = 1,
                YPosition = 1
            };

            var result = calculator.CalculateAdventurerNext(adventurer, 0, out var changingCell);

            Assert.False(changingCell);
            Assert.Equal(1, result.NextX);
            Assert.Equal(1, result.NextY);
            Assert.Equal(Orientation.S, result.NextOrientation);
        }

        [Fact]
        public void CalculateAdventurerNext_WhenCurrentOrientationIsEAndMovementIsG()
        {
            var calculator = new PositionCalculator();
            var adventurer = new Adventurer
            {

                Orientation = Orientation.E,
                Movements = new List<Movement> { Movement.G },
                XPosition = 1,
                YPosition = 1
            };

            var result = calculator.CalculateAdventurerNext(adventurer, 0, out var changingCell);

            Assert.False(changingCell);
            Assert.Equal(1, result.NextX);
            Assert.Equal(1, result.NextY);
            Assert.Equal(Orientation.N, result.NextOrientation);
        }

        [Fact]
        public void CalculateAdventurerNext_WhenCurrentOrientationIsOAndMovementIsA()
        {
            var calculator = new PositionCalculator();
            var adventurer = new Adventurer
            {

                Orientation = Orientation.O,
                Movements = new List<Movement> { Movement.A },
                XPosition = 1,
                YPosition = 1
            };

            var result = calculator.CalculateAdventurerNext(adventurer, 0, out var changingCell);

            Assert.True(changingCell);
            Assert.Equal(0, result.NextX);
            Assert.Equal(1, result.NextY);
            Assert.Equal(Orientation.O, result.NextOrientation);
        }

        [Fact]
        public void CalculateAdventurerNext_WhenCurrentOrientationIsOAndMovementIsD()
        {
            var calculator = new PositionCalculator();
            var adventurer = new Adventurer
            {

                Orientation = Orientation.O,
                Movements = new List<Movement> { Movement.D },
                XPosition = 1,
                YPosition = 1
            };

            var result = calculator.CalculateAdventurerNext(adventurer, 0, out var changingCell);

            Assert.False(changingCell);
            Assert.Equal(1, result.NextX);
            Assert.Equal(1, result.NextY);
            Assert.Equal(Orientation.N, result.NextOrientation);
        }

        [Fact]
        public void CalculateAdventurerNext_WhenCurrentOrientationIsOAndMovementIsG()
        {
            var calculator = new PositionCalculator();
            var adventurer = new Adventurer
            {

                Orientation = Orientation.O,
                Movements = new List<Movement> { Movement.G },
                XPosition = 1,
                YPosition = 1
            };

            var result = calculator.CalculateAdventurerNext(adventurer, 0, out var changingCell);

            Assert.False(changingCell);
            Assert.Equal(1, result.NextX);
            Assert.Equal(1, result.NextY);
            Assert.Equal(Orientation.S, result.NextOrientation);
        }
    }
}
