using CarbonITExam.Models.Enums;

namespace CarbonITExam.Services.Contracts
{
    public interface IMovementTranslator
    {
        /// <summary>
        /// Translate movements from string format to enum format
        /// </summary>
        /// <param name="movements">Movements in string format</param>
        /// <returns></returns>
        IList<Movement> Translate(string movements);
    }
}
