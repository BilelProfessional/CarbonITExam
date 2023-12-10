using CarbonITExam.Models.Enums;
using CarbonITExam.Services;
using Xunit;

namespace CarbonITExam.Tests.Services
{
    public class MovementTranslatorTests
    {
        [Fact]
        public void Translate_ReturnsMovementsInEnumFormat()
        {
            var translator = new MovementTranslator();

            var result = translator.Translate("ADG");

            Assert.Equal(3, result.Count);
            Assert.Equal(Movement.A, result[0]);
            Assert.Equal(Movement.D, result[1]);
            Assert.Equal(Movement.G, result[2]);
        }

        [Fact]
        public void Translate_ThrowsException_WhenMovementsIsNull()
        {
            var translator = new MovementTranslator();

            var exception = Assert.Throws<ArgumentNullException>(() =>  translator.Translate(null));
        }

        [Fact]
        public void Translate_ThrowsException_WhenAnyMovementIsNotSupported()
        {
            var translator = new MovementTranslator();

            var exception = Assert.Throws<NotSupportedException>(() => translator.Translate("AXG"));
            Assert.Equal("The provided movement X is not supported", exception.Message);
        }
    }
}
