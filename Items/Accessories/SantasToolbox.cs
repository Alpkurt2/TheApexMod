using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;
using System.Collections.Generic;
using Microsoft.Xna.Framework;

namespace TheApexMod.Items.Accessories
{
    public class SantasToolbox : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Santa's Toolbox");
            Tooltip.SetDefault("Increases block placement & tool range by 2");
        }

        public override void SetDefaults()
        {
            item.CloneDefaults(ItemID.Toolbox);
            item.width = 40;
            item.height = 24;
            item.rare = ItemRarityID.Pink;
            item.value = Item.sellPrice(gold: 2);
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            Player.tileRangeX += 2;
            Player.tileRangeY += 2;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.Toolbox, 1);
            recipe.AddIngredient(ModContent.ItemType<Materials.ConcentratedSnow>(), 1);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
