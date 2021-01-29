﻿using StardewValley;

namespace Quick_Sell
{
    internal class ModUtils
    {
        private readonly ModConfig Config;

        public ModUtils(ModConfig config)
        {
            this.Config = config;
        }

        public void SendHUDMessage(string message, int type = HUDMessage.newQuest_type)
        {
            if (this.Config.EnableHUDMessages == true)
                Game1.addHUDMessage(new HUDMessage(message, type));
        }
    }
}