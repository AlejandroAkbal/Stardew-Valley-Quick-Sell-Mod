using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StardewModdingAPI;
using StardewModdingAPI.Events;
using StardewModdingAPI.Utilities;
using StardewValley;

namespace Quick_Sell
{
    internal class ModConfig
    {
        // public KeybindList SellKey { get; set; } = KeybindList.ForSingle(SButton.MouseMiddle);
        public SButton SellKey { get; set; } = SButton.MouseMiddle;

        public ModConfig()
        {
        }
    }
}