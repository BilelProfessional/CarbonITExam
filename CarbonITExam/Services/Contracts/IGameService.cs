namespace CarbonITExam.Services.Contracts
{
    public interface IGameService
    {
        /// <summary>
        /// Launch a game
        /// </summary>
        /// <param name="inputName">File input name</param>
        void Play(string inputName);
    }
}
