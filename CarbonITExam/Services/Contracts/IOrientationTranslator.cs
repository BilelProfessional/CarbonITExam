using CarbonITExam.Models.Enums;

namespace CarbonITExam.Services.Contracts
{
    public interface IOrientationTranslator
    {
        /// <summary>
        /// Translate orientation from string format to enum format
        /// </summary>
        /// <param name="orientation">Orientation</param>
        /// <returns></returns>
        Orientation Translate(string orientation);

        /// <summary>
        /// Translate orientation from enum format to string format
        /// </summary>
        /// <param name="orientation">Orientation</param>
        /// <returns></returns>
        string Translate(Orientation orientation);
    }
}
