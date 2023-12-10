using CarbonITExam.Builders;
using CarbonITExam.Files.Management;
using CarbonITExam.Services;

namespace CarbonITExam
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var basePath = Directory.GetCurrentDirectory().Replace("\\bin\\Debug\\net6.0", "");
            var files = Directory.GetFiles(Path.Combine(basePath, "Files\\Inputs"));

            var fileReader = new TextFileReader();
            var fileWriter = new TextFileWriter();
            var orientationTranslator = new OrientationTranslator();
            var movementTranslator = new MovementTranslator();
            var positionCalculator = new PositionCalculator();

            foreach (var file in files)
            {
                var gameService = new GameService(new MapBuilder(),
                    new BoardBuilder(movementTranslator, orientationTranslator),
                    positionCalculator,
                    orientationTranslator,
                    fileReader,
                    fileWriter);
                gameService.Play(Path.GetFileName(file));
            }
        }
    }
}