namespace CarbonITExam.Builders.Contracts
{
    public interface IBuilder<T> where T : class
    {
        T Build();
    }
}
