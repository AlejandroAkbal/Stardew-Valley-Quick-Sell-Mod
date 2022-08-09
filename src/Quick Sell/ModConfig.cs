using StardewModdingAPI;
using StardewModdingAPI.Utilities;

namespace Quick_Sell
{
    public class ModConfig
    {
        public KeybindList SellKey { get; set; } = KeybindList.Parse("MouseMiddle, LeftStick");

        public bool CheckIfItemsCanBeShipped { get; set; } = true;

        public bool EnableHUDMessages { get; set; } = false;
    }
}