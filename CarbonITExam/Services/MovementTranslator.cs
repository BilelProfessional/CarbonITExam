using CarbonITExam.Models.Enums;
using CarbonITExam.Services.Contracts;

namespace CarbonITExam.Services
{
    public class MovementTranslator : IMovementTranslator
    {
        /// <inheritdoc />
        public IList<Movement> Translate(string movements)
        {
            if (movements is null) throw new ArgumentNullException(nameof(movements));

            return movements
                .Select(m =>
                {
                    if (Enum.TryParse<Movement>(m.ToString(), out var mouvement))
                    {
                        return mouvement;
                    }

                    throw new NotSupportedException($"The provided movement {m} is not supported");
                })
                .ToList();
        }
    }
}
