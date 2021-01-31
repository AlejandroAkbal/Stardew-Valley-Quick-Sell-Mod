using StardewModdingAPI;

namespace Quick_Sell
{
    internal class ModLogger
    {
        private static readonly IMonitor Monitor = ModEntry.Instance.Monitor;

        public static void Debug(string message)
        {
            Monitor.Log(message, LogLevel.Debug);
        }

        public static void Warn(string message)
        {
            Monitor.Log(message, LogLevel.Warn);
        }
    }
}