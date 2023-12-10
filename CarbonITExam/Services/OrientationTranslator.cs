using CarbonITExam.Models.Enums;
using CarbonITExam.Services.Contracts;

namespace CarbonITExam.Services
{
    public class OrientationTranslator : IOrientationTranslator
    {
        /// <inheritdoc />
        public Orientation Translate(string orientation)
        {
            if (Enum.TryParse<Orientation>(orientation, out var result))
            {
                return result;
            }

            throw new NotSupportedException($"The provided orientation {orientation} is not supported");
        }

        /// <inheritdoc />
        public string Translate(Orientation orientation)
        {
            return orientation.ToString();
        }
    }
}
