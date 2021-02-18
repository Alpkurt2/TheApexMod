using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;
using System.Collections.Generic;
using Microsoft.Xna.Framework;

namespace TheApexMod.Items.Accessories
{
    [AutoloadEquip(EquipType.HandsOn)]
    public class BandOfNature : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Band of Nature");
            Tooltip.SetDefault("Gives an insane boost in life regen and reduces the cooldown of healing potions by 25%");
        }

        public override void ModifyTooltips(List<TooltipLine> list)
        {
            foreach (TooltipLine tooltipLine in list)
            {
                if (tooltipLine.mod == "Terraria" && tooltipLine.Name == "ItemName")
                {
                    tooltipLine.overrideColor = new Color(0, 255, 0);
                }
            }
        }

        public override void SetDefaults()
        {
            sbyte handOn = item.handOnSlot;
            item.CloneDefaults(ItemID.BandofRegeneration);
            item.width = 30;
            item.height = 24;
            item.rare = ItemRarityID.Red;
            item.value = Item.sellPrice(gold: 10);
            item.handOnSlot = handOn;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.lifeRegen += 40;
            player.pStone = true;
            player.GetModPlayer<ApexPlayer>().NatureBand = true;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.CharmofMyths, 1);
            recipe.AddIngredient(ItemID.Vine, 5);
            recipe.AddIngredient(ItemID.LifeFruit, 5);
            recipe.AddIngredient(ItemID.FragmentVortex, 10);
            recipe.AddIngredient(ItemID.LunarBar, 5);
            recipe.AddTile(TileID.LunarCraftingStation);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
