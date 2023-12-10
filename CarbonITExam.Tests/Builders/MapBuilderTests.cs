using CarbonITExam.Builders;
using CarbonITExam.Services.Contracts;
using FakeItEasy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace CarbonITExam.Tests.Builders
{
    public class MapBuilderTests
    {
        [Fact]
        public void WithDimensions_SetXAndYDimensions()
        {
            var builder = new MapBuilder();

            var result = builder.WithDimensions(3, 3);

            Assert.Equal(builder, result);
        }

        [Fact]
        public void WithDimensions_ThrowsException_WhenXIsLessThan0()
        {
            var builder = new MapBuilder();

            var exception  = Assert.Throws<ArgumentOutOfRangeException>(() => builder.WithDimensions(-2, 3));
            Assert.Equal("Length of map's X axis should be positive (Parameter 'x')", exception.Message);
        }

        [Fact]
        public void WithDimensions_ThrowsException_WhenYIsLessThan0()
        {
            var builder = new MapBuilder();

            var exception = Assert.Throws<ArgumentOutOfRangeException>(() => builder.WithDimensions(3, -3));
            Assert.Equal("Length of map's Y axis should be positive (Parameter 'y')", exception.Message);
        }

        [Fact]
        public void WithAdventurer_AddAdventurerInTheMap()
        {
            var builder = new MapBuilder();

            var result = builder
                .WithDimensions(3, 3)
                .WithAdventurer(1, 1);

            Assert.Equal(builder, result);
        }

        [Fact]
        public void WithAdventurer_ThrowsException_WhenDimensionsAreNotSet()
        {
            var builder = new MapBuilder();

            var exception = Assert.Throws<InvalidOperationException>(() => builder.WithAdventurer(2, 2));
            Assert.Equal("Map's dimensions are not already defined", exception.Message);
        }

        [Fact]
        public void WithAdventurer_ThrowsException_WhenAdventurerXIsLessThan0()
        {
            var builder = new MapBuilder();

            builder.WithDimensions(3, 3);

            var exception = Assert.Throws<ArgumentOutOfRangeException>(() => builder.WithAdventurer(-2, 2));
            Assert.Equal("Adventurer's X position is out of map's border (Parameter 'x')", exception.Message);
        }

        [Fact]
        public void WithAdventurer_ThrowsException_WhenAdventurerXIsGreaterThanMapX()
        {
            var builder = new MapBuilder();

            builder.WithDimensions(3, 3);

            var exception = Assert.Throws<ArgumentOutOfRangeException>(() => builder.WithAdventurer(4, 2));
            Assert.Equal("Adventurer's X position is out of map's border (Parameter 'x')", exception.Message);
        }

        [Fact]
        public void WithAdventurer_ThrowsException_WhenAdventurerXIsEqualToMapX()
        {
            var builder = new MapBuilder();

            builder.WithDimensions(3, 3);

            var exception = Assert.Throws<ArgumentOutOfRangeException>(() => builder.WithAdventurer(3, 2));
            Assert.Equal("Adventurer's X position is out of map's border (Parameter 'x')", exception.Message);
        }

        [Fact]
        public void WithAdventurer_ThrowsException_WhenAdventurerYIsLessThan0()
        {
            var builder = new MapBuilder();

            builder.WithDimensions(3, 3);

            var exception = Assert.Throws<ArgumentOutOfRangeException>(() => builder.WithAdventurer(2, -2));
            Assert.Equal("Adventurer's Y position is out of map's border (Parameter 'y')", exception.Message);
        }

        [Fact]
        public void WithAdventurer_ThrowsException_WhenAdventurerYIsGreaterThanMapY()
        {
            var builder = new MapBuilder();

            builder.WithDimensions(3, 3);

            var exception = Assert.Throws<ArgumentOutOfRangeException>(() => builder.WithAdventurer(2, 4));
            Assert.Equal("Adventurer's Y position is out of map's border (Parameter 'y')", exception.Message);
        }

        [Fact]
        public void WithAdventurer_ThrowsException_WhenAdventurerYIsEqualToMapY()
        {
            var builder = new MapBuilder();

            builder.WithDimensions(3, 3);

            var exception = Assert.Throws<ArgumentOutOfRangeException>(() => builder.WithAdventurer(2, 3));
            Assert.Equal("Adventurer's Y position is out of map's border (Parameter 'y')", exception.Message);
        }

        [Fact]
        public void WithAdventurer_ThrowsException_WhenAnotherAdventurerAlreadyExistsInTheCell()
        {
            var builder = new MapBuilder();

            builder
                .WithDimensions(3, 3)
                .WithAdventurer(1, 2);

            var exception = Assert.Throws<InvalidOperationException>(() => builder.WithAdventurer(1, 2));
            Assert.Equal("An adventurer is already presented in the cell with x 1 and y 2", exception.Message);
        }

        [Fact]
        public void WithMountain_AddMountainInTheMap()
        {
            var builder = new MapBuilder();

            var result = builder
                .WithDimensions(3, 3)
                .WithMountain(1, 1);

            Assert.Equal(builder, result);
        }

        [Fact]
        public void WithMountain_ThrowsException_WhenDimensionsAreNotSet()
        {
            var builder = new MapBuilder();

            var exception = Assert.Throws<InvalidOperationException>(() => builder.WithMountain(2, 2));
            Assert.Equal("Map's dimensions are not already defined", exception.Message);
        }

        [Fact]
        public void WithMountain_ThrowsException_WhenMountainXIsLessThan0()
        {
            var builder = new MapBuilder();

            builder.WithDimensions(3, 3);

            var exception = Assert.Throws<ArgumentOutOfRangeException>(() => builder.WithMountain(-2, 2));
            Assert.Equal("Mountain's X position is out of map's border (Parameter 'x')", exception.Message);
        }

        [Fact]
        public void WithMountain_ThrowsException_WhenMountainXIsGreaterThanMapX()
        {
            var builder = new MapBuilder();

            builder.WithDimensions(3, 3);

            var exception = Assert.Throws<ArgumentOutOfRangeException>(() => builder.WithMountain(4, 2));
            Assert.Equal("Mountain's X position is out of map's border (Parameter 'x')", exception.Message);
        }

        [Fact]
        public void WithMountain_ThrowsException_WhenMountainXIsEqualToMapX()
        {
            var builder = new MapBuilder();

            builder.WithDimensions(3, 3);

            var exception = Assert.Throws<ArgumentOutOfRangeException>(() => builder.WithMountain(3, 2));
            Assert.Equal("Mountain's X position is out of map's border (Parameter 'x')", exception.Message);
        }

        [Fact]
        public void WithMountain_ThrowsException_WhenMountainYIsLessThan0()
        {
            var builder = new MapBuilder();

            builder.WithDimensions(3, 3);

            var exception = Assert.Throws<ArgumentOutOfRangeException>(() => builder.WithMountain(2, -2));
            Assert.Equal("Mountain's Y position is out of map's border (Parameter 'y')", exception.Message);
        }

        [Fact]
        public void WithMountain_ThrowsException_WhenMountainYIsGreaterThanMapY()
        {
            var builder = new MapBuilder();

            builder.WithDimensions(3, 3);

            var exception = Assert.Throws<ArgumentOutOfRangeException>(() => builder.WithMountain(2, 4));
            Assert.Equal("Mountain's Y position is out of map's border (Parameter 'y')", exception.Message);
        }

        [Fact]
        public void WithMountain_ThrowsException_WhenMountainYIsEqualToMapY()
        {
            var builder = new MapBuilder();

            builder.WithDimensions(3, 3);

            var exception = Assert.Throws<ArgumentOutOfRangeException>(() => builder.WithMountain(2, 3));
            Assert.Equal("Mountain's Y position is out of map's border (Parameter 'y')", exception.Message);
        }

        [Fact]
        public void WithMountain_ThrowsException_WhenAnotherMountainAlreadyExistsInTheCell()
        {
            var builder = new MapBuilder();

            builder
                .WithDimensions(3, 3)
                .WithMountain(1, 2);

            var exception = Assert.Throws<InvalidOperationException>(() => builder.WithMountain(1, 2));
            Assert.Equal("A mountain is already presented in the cell with x 1 and y 2", exception.Message);
        }

        [Fact]
        public void WithTreasure_AddMountainInTheMap()
        {
            var builder = new MapBuilder();

            var result = builder
                .WithDimensions(3, 3)
                .WithTreasure(1, 1, 1);

            Assert.Equal(builder, result);
        }

        [Fact]
        public void WithTreasure_ThrowsException_WhenDimensionsAreNotSet()
        {
            var builder = new MapBuilder();

            var exception = Assert.Throws<InvalidOperationException>(() => builder.WithTreasure(2, 2, 1));
            Assert.Equal("Map's dimensions are not already defined", exception.Message);
        }

        [Fact]
        public void WithTreasure_ThrowsException_WhenTreasureXIsLessThan0()
        {
            var builder = new MapBuilder();

            builder.WithDimensions(3, 3);

            var exception = Assert.Throws<ArgumentOutOfRangeException>(() => builder.WithTreasure(-2, 2, 1));
            Assert.Equal("Treasure's X position is out of map's border (Parameter 'x')", exception.Message);
        }

        [Fact]
        public void WithTreasure_ThrowsException_WhenTreasureXIsGreaterThanMapX()
        {
            var builder = new MapBuilder();

            builder.WithDimensions(3, 3);

            var exception = Assert.Throws<ArgumentOutOfRangeException>(() => builder.WithTreasure(4, 2, 1));
            Assert.Equal("Treasure's X position is out of map's border (Parameter 'x')", exception.Message);
        }

        [Fact]
        public void WithTreasure_ThrowsException_WhenTreasureXIsEqualToMapX()
        {
            var builder = new MapBuilder();

            builder.WithDimensions(3, 3);

            var exception = Assert.Throws<ArgumentOutOfRangeException>(() => builder.WithTreasure(3, 2, 1));
            Assert.Equal("Treasure's X position is out of map's border (Parameter 'x')", exception.Message);
        }

        [Fact]
        public void WithTreasure_ThrowsException_WhenTreasureYIsLessThan0()
        {
            var builder = new MapBuilder();

            builder.WithDimensions(3, 3);

            var exception = Assert.Throws<ArgumentOutOfRangeException>(() => builder.WithTreasure(2, -2, 1));
            Assert.Equal("Treasure's Y position is out of map's border (Parameter 'y')", exception.Message);
        }

        [Fact]
        public void WithTreasure_ThrowsException_WhenTreasureYIsGreaterThanMapY()
        {
            var builder = new MapBuilder();

            builder.WithDimensions(3, 3);

            var exception = Assert.Throws<ArgumentOutOfRangeException>(() => builder.WithTreasure(2, 4, 1));
            Assert.Equal("Treasure's Y position is out of map's border (Parameter 'y')", exception.Message);
        }

        [Fact]
        public void WithTreasure_ThrowsException_WhenTreasureYIsEqualToMapY()
        {
            var builder = new MapBuilder();

            builder.WithDimensions(3, 3);

            var exception = Assert.Throws<ArgumentOutOfRangeException>(() => builder.WithTreasure(2, 3, 1));
            Assert.Equal("Treasure's Y position is out of map's border (Parameter 'y')", exception.Message);
        }

        [Fact]
        public void WithTreasure_ThrowsException_WhenCountIsLessThan0()
        {
            var builder = new MapBuilder();

            builder.WithDimensions(3, 3);

            var exception = Assert.Throws<ArgumentOutOfRangeException>(() => builder.WithTreasure(1, 2, -2));
            Assert.Equal("Number of treasures could not be less than 0 (Parameter 'count')", exception.Message);
        }

        [Fact]
        public void WithTreasure_ThrowsException_WhenAnotherTreasureAlreadyExistsInTheCell()
        {
            var builder = new MapBuilder();

            builder
                .WithDimensions(3, 3)
                .WithTreasure(1, 2, 2);

            var exception = Assert.Throws<InvalidOperationException>(() => builder.WithTreasure(1, 2, 1));
            Assert.Equal("A treasure is already presented in the cell with x 1 and y 2", exception.Message);
        }

        [Fact]
        public void Build_DefinesAllMap()
        {
            var builder = new MapBuilder();

            builder
                .WithDimensions(2, 2)
                .WithMountain(0, 1)
                .WithAdventurer(1, 0)
                .WithTreasure(0, 0, 2);

            var map = builder.Build();

            Assert.Equal(2, map.XAxis);
            Assert.Equal(2, map.YAxis);
            Assert.Equal(4, map.Cells.Count);
            Assert.True(map.GetCell(0, 1).HasMountain);
            Assert.True(map.GetCell(1, 0).HasAdventurer);
            Assert.Equal(2, map.GetCell(0, 0).Treasures);
        }

        [Fact]
        public void Build_ThrowsException_WhenMountainAndAdventurerArePresentedInTheSameCell()
        {
            var builder = new MapBuilder();

            builder
                .WithDimensions(2, 2)
                .WithMountain(0, 1)
                .WithAdventurer(0, 1)
                .WithTreasure(0, 0, 2);

            var exception = Assert.Throws<InvalidOperationException>(() =>  builder.Build());
            Assert.Equal("Cell with x 0 and y 1 could not have mountain and an adventurer at the same time", exception.Message);
        }

        [Fact]
        public void Build_ThrowsException_WhenMountainAndTreasuresArePresentedInTheSameCell()
        {
            var builder = new MapBuilder();

            builder
                .WithDimensions(2, 2)
                .WithMountain(0, 0)
                .WithAdventurer(0, 1)
                .WithTreasure(0, 0, 2);

            var exception = Assert.Throws<InvalidOperationException>(() => builder.Build());
            Assert.Equal("Cell with x 0 and y 0 could not have mountain and treasures at the same time", exception.Message);
        }
    }
}
