using StardewModdingAPI;

namespace Quick_Sell
{
    internal class ModConfig
    {
        // public KeybindList SellKey { get; set; } = KeybindList.ForSingle(SButton.MouseMiddle);
        public SButton SellKey { get; set; } = SButton.MouseMiddle;

        //public SButton ModifierKey { get; set; } = SButton.LeftShift;

        public bool CheckIfItemsCanBeShipped { get; set; } = true;

        public bool EnableHUDMessages { get; set; } = false;
    }
}