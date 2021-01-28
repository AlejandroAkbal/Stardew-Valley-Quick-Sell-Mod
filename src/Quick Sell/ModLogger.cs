using StardewModdingAPI;

namespace Quick_Sell
{
    internal class ModLogger
    {
        private readonly IMonitor Monitor;

        public ModLogger(IMonitor monitor)
        {
            this.Monitor = monitor;
        }

        public void Debug(string message)
        {
            this.Monitor.Log(message, LogLevel.Debug);
        }

        public void Warn(string message)
        {
            this.Monitor.Log(message, LogLevel.Warn);
        }
    }
}