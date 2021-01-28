using StardewModdingAPI;
using StardewModdingAPI.Events;
using StardewValley;
using StardewValley.Menus;

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

        /*********
        ** Public methods
        *********/

        /// <summary>The mod entry point, called after the mod is first loaded.</summary>
        /// <param name="helper">Provides simplified APIs for writing mods.</param>
        public override void Entry(IModHelper helper)
        {
            this.Config = this.Helper.ReadConfig<ModConfig>();

            helper.Events.Input.ButtonPressed += this.OnButtonPressed;
        }

        /// <summary>Raised after the player presses a button on the keyboard, controller, or mouse.</summary>
        /// <param name="sender">The event sender.</param>
        /// <param name="e">The event data.</param>
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
            Item item = GetHoveredItem();

            if (item == null)
                return;

            this.Monitor.Log($"{Game1.player.Name} pressed {e.Button} and has selected {item}.", LogLevel.Debug);

        private static Item GetHeldItem()
        {
            Item heldItem = Game1.player.CurrentItem;

            return heldItem;
        }

        private Item GetHoveredItem()
        {
            IClickableMenu currentMenu = (Game1.activeClickableMenu as GameMenu)?.GetCurrentPage() ?? Game1.activeClickableMenu;
            Item currentItem = null;

            switch (currentMenu)
            {
                // Chests
                case MenuWithInventory menu:
                    currentItem = Game1.player.CursorSlotItem ?? menu.heldItem ?? menu.hoveredItem;
                    break;

                case InventoryPage menu:
                    currentItem = Game1.player.CursorSlotItem ?? this.Helper.Reflection.GetField<Item>(menu, "hoveredItem").GetValue();
                    break;

                case ProfileMenu menu:
                    currentItem = menu.hoveredItem;
                    break;

                default:
                    string message = "No menu available!";

                    this.Monitor.Log(message, LogLevel.Debug);

                    SendHUDMessage(message);

                    // currentItem = this.Helper.Reflection.GetField<Item>(currentMenu, "hoveredItem", required: false).GetValue();
                    break;
            }

            return currentItem;
        }

        private void SendHUDMessageIfMessagesEnabled(string message, int type = HUDMessage.achievement_type)
        {
            if (this.Config.MessagesEnabled == true)
                SendHUDMessage(message, type);
        }

        private static void SendHUDMessage(string message, int type = HUDMessage.error_type)
        {
            Game1.addHUDMessage(new HUDMessage(message, type));
        }
    }
}