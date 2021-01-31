﻿using StardewValley;

namespace Quick_Sell
{
    internal class ModUtils
    {
        public static void SendHUDMessage(string message, int type = HUDMessage.newQuest_type)
        {
            if (ModEntry.Config.EnableHUDMessages == true)
                Game1.addHUDMessage(new HUDMessage(message, type));
        }
    }
}