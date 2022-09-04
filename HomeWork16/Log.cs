namespace HomeWork16
{
    public class Log
    {
        public static List<string> LogInfo { get; set; } = new();
        public static void LogEntry(string message)
        {
            LogInfo.Add(message);
        }
    }
}
