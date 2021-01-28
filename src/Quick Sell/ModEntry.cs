using StardewModdingAPI;
using StardewModdingAPI.Events;
using StardewValley;

namespace Quick_Sell
{
    /// <summary>The mod entry point.</summary>
    public class ModEntry : Mod
    {
        /*********
        ** Properties
        *********/

        /// <summary>The mod configuration from the player.</summary>
        private ModConfig Config;

        private ModUtils Utils;
        private ModPlayer Player;

        /*********
        ** Public methods
        *********/

        /// <summary>The mod entry point, called after the mod is first loaded.</summary>
        /// <param name="helper">Provides simplified APIs for writing mods.</param>
        public override void Entry(IModHelper helper)
        {
            this.Config = this.Helper.ReadConfig<ModConfig>();

            this.Utils = new ModUtils(this.Config);
            this.Player = new ModPlayer(helper, this.Config, this.Monitor);

            helper.Events.Input.ButtonPressed += this.OnButtonPressed;
        }

        private void OnButtonPressed(object sender, ButtonPressedEventArgs e)
        {
            if (!Context.IsWorldReady)
                return;

            //if (!Context.IsPlayerFree)
            //    return;

            //if (!Game1.displayHUD)
            //    return;

            if (e.Button == this.Config.SellKey)
                this.OnSellButtonPressed(sender, e);
        }

        private void OnSellButtonPressed(object sender, ButtonPressedEventArgs e)
        {
            var item = Player.GetHoveredItem() as Object;

            if (item == null)
                return;

            this.Monitor.Log($"{Game1.player.Name} pressed {e.Button} and has selected {item}.", LogLevel.Debug);

            if (item.canBeShipped() == false)
                return;

            this.Player.AddItemToPlayerShippingBin(item);

            this.Player.RemoveItemFromPlayerInventory(item);

            this.Utils.SendHUDMessageIfMessagesEnabled($"Sent {item.Stack} {item.DisplayName} to the Shipping Bin!");

            Game1.playSound("Ship");
        }
    }
}