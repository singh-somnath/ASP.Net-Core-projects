namespace ConsoleAppIntermediate.InterfaceWithDependencyInjection
{
    public interface ILoger
    {
        void LogError(string message);
        void LogInfo(string message);
    }
}