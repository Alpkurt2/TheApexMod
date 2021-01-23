using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;
using System.Collections.Generic;
using Microsoft.Xna.Framework;

namespace TheApexMod.Items.Accessories
{
    public class CozyMirror : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Cozy Mirror");
            Tooltip.SetDefault("'Unfortunately this can't teleport you back home.'\nImmunity to cold debuffs and pertrification.");
        }

        public override void SetDefaults()
        {
            item.CloneDefaults(ItemID.PocketMirror);
            item.width = 34;
            item.height = 34;
            item.rare = ItemRarityID.Pink;
            item.value = Item.sellPrice(gold: 3);
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.buffImmune[BuffID.Chilled] = true;
            player.buffImmune[BuffID.Frozen] = true;
            player.buffImmune[BuffID.Stoned] = true;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.HandWarmer, 1);
            recipe.AddIngredient(ItemID.PocketMirror, 1);
            recipe.AddTile(TileID.TinkerersWorkbench);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
