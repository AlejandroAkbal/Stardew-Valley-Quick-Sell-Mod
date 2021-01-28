using StardewModdingAPI;
using StardewValley;
using StardewValley.Menus;

namespace Quick_Sell
{
    internal class ModPlayer
    {
        private readonly IModHelper Helper;
        private readonly ModConfig Config;
        private readonly IMonitor Monitor;

        private ModUtils Utils;

        public ModPlayer(IModHelper helper, ModConfig config, IMonitor monitor)
        {
            this.Config = config;
            this.Helper = helper;
            this.Monitor = monitor;

            this.Utils = new ModUtils(this.Config);
        }

        public void RemoveItemFromPlayerInventory(Item item)
        {
            Game1.player.removeItemFromInventory(item);
        }

        public void AddItemToPlayerShippingBin(Item item)
        {
            Game1.getFarm().getShippingBin(Game1.player).Add(item);
        }

        public Item GetHeldItem()
        {
            Item heldItem = Game1.player.CurrentItem;

            return heldItem;
        }

        public Item GetHoveredItem()
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

                    this.Utils.SendHUDMessage(message);

                    // currentItem = this.Helper.Reflection.GetField<Item>(currentMenu, "hoveredItem", required: false).GetValue();
                    break;
            }

            return currentItem;
        }
    }
}