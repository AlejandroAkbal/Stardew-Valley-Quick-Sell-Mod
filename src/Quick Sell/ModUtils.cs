using StardewValley;

namespace Quick_Sell
{
    internal class ModUtils
    {
        public static void SendHUDMessage(string message, int type = HUDMessage.newQuest_type)
        {
            Game1.addHUDMessage(new HUDMessage(message, type));
        }

        public static void SendHUDMessageRespectingConfig(string message, int type = HUDMessage.newQuest_type)
        {
            if (ModEntry.Config.EnableHUDMessages == false)
                return;

            ModUtils.SendHUDMessage(message, type);
        }
    }
}