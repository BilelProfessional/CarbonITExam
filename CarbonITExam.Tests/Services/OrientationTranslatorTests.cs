using CarbonITExam.Models.Enums;
using CarbonITExam.Services;
using Xunit;

namespace CarbonITExam.Tests.Services
{
    public class OrientationTranslatorTests
    {
        [Fact]
        public void TranslateFromStringToEnum_TranslatesN()
        {
            var translator = new OrientationTranslator();

            var result = translator.Translate("N");

            Assert.Equal(Orientation.N, result);
        }

        [Fact]
        public void TranslateFromStringToEnum_TranslatesS()
        {
            var translator = new OrientationTranslator();

            var result = translator.Translate("S");

            Assert.Equal(Orientation.S, result);
        }

        [Fact]
        public void TranslateFromStringToEnum_TranslatesE()
        {
            var translator = new OrientationTranslator();

            var result = translator.Translate("E");

            Assert.Equal(Orientation.E, result);
        }

        [Fact]
        public void TranslateFromStringToEnum_TranslatesO()
        {
            var translator = new OrientationTranslator();

            var result = translator.Translate("O");

            Assert.Equal(Orientation.O, result);
        }

        [Fact]
        public void TranslateFromStringToEnum_ThrowsException_WhenProvidedOrientationIsNotSupported()
        {
            var translator = new OrientationTranslator();

            var exception = Assert.Throws<NotSupportedException>(() => translator.Translate("X"));
            Assert.Equal("The provided orientation X is not supported", exception.Message);  
        }

        [Fact]
        public void TranslateFromEnumToString_ReturnsOrientationInStringFormat()
        {
            var translator = new OrientationTranslator();

            var result = translator.Translate(Orientation.N);

            Assert.Equal("N", result);
        }
    }
}
