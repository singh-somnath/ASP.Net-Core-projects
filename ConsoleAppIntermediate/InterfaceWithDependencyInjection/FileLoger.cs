using System.IO;

namespace ConsoleAppIntermediate.InterfaceWithDependencyInjection
{
    public class FileLoger : ILoger
    {
        private string Path { get; }
        public FileLoger(string path)
        {
            Path = path;
        }

        public void LogError(string message)
        {
            LogMeggase(message, "Error");
        }

        public void LogInfo(string message)
        {
            LogMeggase(message, "Info");
        }

        private void LogMeggase(string message, string messgaeType)
        {
            using (StreamWriter sw = new StreamWriter(Path, true))
            {
                sw.WriteLine(messgaeType + ": " + message);
                sw.Dispose();
            }
        }
    }
}