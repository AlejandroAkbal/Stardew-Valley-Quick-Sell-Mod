using StardewModdingAPI;
using StardewModdingAPI.Utilities;

namespace Quick_Sell
{
    public class ModConfig
    {
        public KeybindList SellKey { get; set; } = KeybindList.Parse("MouseMiddle, LeftStick");

        //public SButton ModifierKey { get; set; } = SButton.LeftShift;

        public bool CheckIfItemsCanBeShipped { get; set; } = true;

        public bool EnableHUDMessages { get; set; } = false;
    }
}