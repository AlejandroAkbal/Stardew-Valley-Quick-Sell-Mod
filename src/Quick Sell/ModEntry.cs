using StardewModdingAPI;
using StardewModdingAPI.Events;
using StardewValley;

namespace Quick_Sell
{
    public class ModEntry : Mod
    {
        public static Mod Instance;

        public static IModHelper CustomHelper;

        public static ModConfig Config;

        public override void Entry(IModHelper helper)
        {
            Instance = this;

            CustomHelper = helper;

            Config = CustomHelper.ReadConfig<ModConfig>();

            helper.Events.Input.ButtonPressed += OnButtonPressed;
        }

        private void OnButtonPressed(object sender, ButtonPressedEventArgs e)
        {
            if (!Context.IsWorldReady)
                return;

            //if (!Context.IsPlayerFree)
            //    return;

            //if (!Game1.displayHUD)
            //    return;

            if (Config.SellKey.JustPressed())
                OnSellButtonPressed(sender, e);
        }

        private void OnSellButtonPressed(object sender, ButtonPressedEventArgs e)
        {
            Item item = ModPlayer.GetHoveredItem();

            if (item == null)
            {
                ModLogger.Trace("Item was null.");
                return;
            }

            ModLogger.Trace($"{Game1.player.Name} pressed {e.Button} and has selected {item}.");

            if (Config.CheckIfItemsCanBeShipped == true && ModPlayer.CheckIfItemCanBeShipped(item) == false)
            {
                ModLogger.Info("Item can't be shipped.");
                return;
            }

            ModPlayer.AddItemToShippingBin(item);

            ModPlayer.OrganizeShippingBin();

            ModPlayer.RemoveItemFromPlayerInventory(item);

            ModUtils.SendHUDMessageRespectingConfig($"Sent {item.Stack} {item.DisplayName} to the Shipping Bin!");

            Game1.playSound("Ship");
        }
    }
}