using StardewValley;

namespace Quick_Sell
{
    internal class ModUtils
    {
        private readonly ModConfig Config;

        public ModUtils(ModConfig config)
        {
            this.Config = config;
        }

        public void SendHUDMessage(string message, int type = HUDMessage.error_type)
        {
            Game1.addHUDMessage(new HUDMessage(message, type));
        }

        public void SendHUDMessageIfMessagesEnabled(string message, int type = HUDMessage.screenshot_type)
        {
            if (this.Config.EnableHUDMessages == true)
                SendHUDMessage(message, type);
        }
    }
}