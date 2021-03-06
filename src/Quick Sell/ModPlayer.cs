﻿using StardewModdingAPI;
using StardewValley;
using StardewValley.Menus;

namespace Quick_Sell
{
    internal class ModPlayer
    {
        public static void RemoveItemFromPlayerInventory(Item item)
        {
            Game1.player.removeItemFromInventory(item);
        }

        public static void AddItemToShippingBin(Item item)
        {
            Game1.getFarm().getShippingBin(Game1.player).Add(item);
        }

        public static void OrganizeShippingBin()
        {
            var shippingBinItems = Game1.getFarm().getShippingBin(Game1.player);

            ItemGrabMenu.organizeItemsInList(shippingBinItems);
        }

        public static Item GetHoveredItem()
        {
            IClickableMenu currentMenu = (Game1.activeClickableMenu as GameMenu)?.GetCurrentPage() ?? Game1.activeClickableMenu;
            Item currentItem = null;

            switch (currentMenu)
            {
                // Chests
                //case MenuWithInventory menu:
                //    currentItem = Game1.player.CursorSlotItem ?? menu.heldItem ?? menu.hoveredItem;
                //    break;

                //case ProfileMenu menu:
                //    currentItem = menu.hoveredItem;
                //    break;

                case InventoryPage menu:
                    currentItem = Game1.player.CursorSlotItem ?? ModEntry.Helper.Reflection.GetField<Item>(menu, "hoveredItem").GetValue();
                    break;

                default:
                    string message = "You are not in the inventory!";

                    ModLogger.Trace(message);
                    ModUtils.SendHUDMessage(message, HUDMessage.error_type);
                    break;
            }

            return currentItem;
        }

        public static bool CheckIfItemCanBeShipped(Item item)
        {
            Object itemAsObject = item as Object;

            if (itemAsObject == null || itemAsObject.canBeShipped() == false)
            {
                return false;
            }

            return true;
        }
    }
}