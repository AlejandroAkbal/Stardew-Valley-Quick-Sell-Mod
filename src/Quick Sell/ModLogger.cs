using StardewModdingAPI;

namespace Quick_Sell
{
    internal class ModLogger
    {
        private static readonly IMonitor Monitor = ModEntry.Instance.Monitor;

        public static void Trace(string message)
        {
            Monitor.Log(message, LogLevel.Trace);
        }

        public static void Info(string message)
        {
            Monitor.Log(message, LogLevel.Info);
        }
    }
}