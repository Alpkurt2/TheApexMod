using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;
using System.Collections.Generic;
using Microsoft.Xna.Framework;

namespace TheApexMod.Items.Accessories
{
    [AutoloadEquip(EquipType.Balloon)]
    public class BundleOStrange : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Bundle of Strange Balloons");
            Tooltip.SetDefault("Allows the player to triple jump.\nReleases Bees when damaged.\nIncreases jump height");
        }

        public override void SetDefaults()
        {
            sbyte balloon = item.balloonSlot;
            item.CloneDefaults(ItemID.BundleofBalloons);
            item.width = 30;
            item.height = 28;
            item.rare = ItemRarityID.Yellow;
            item.value = Item.sellPrice(gold: 3);
            item.balloonSlot = balloon;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.doubleJumpFart = true;
            player.doubleJumpSail = true;
            player.jumpBoost = true;
            player.bee = true;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.FartInABalloon, 1);
            recipe.AddIngredient(ItemID.HoneyBalloon, 1);
            recipe.AddIngredient(ItemID.SharkronBalloon, 1);
            recipe.AddTile(TileID.TinkerersWorkbench);
            recipe.SetResult(this);
            recipe.AddRecipe();
            ModRecipe recipe2 = new ModRecipe(mod);
            recipe2.AddIngredient(ItemID.BalloonHorseshoeFart, 1);
            recipe2.AddIngredient(ItemID.BalloonHorseshoeHoney, 1);
            recipe2.AddIngredient(ItemID.BalloonHorseshoeSharkron, 1);
            recipe2.AddTile(TileID.TinkerersWorkbench);
            recipe2.SetResult(this);
            recipe2.AddRecipe();
        }
    }
}
