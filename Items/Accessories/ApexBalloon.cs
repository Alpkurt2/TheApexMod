using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;
using System.Collections.Generic;
using Microsoft.Xna.Framework;

namespace TheApexMod.Items.Accessories
{
    [AutoloadEquip(EquipType.Balloon)]
    public class ApexBalloon : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Apex Balloon");
            Tooltip.SetDefault("Allows the player to septuple jump.\nReleases Bees when damaged.\nIncreases jump height.\nIncreases your movement speed by 100%");
        }
        public override void ModifyTooltips(List<TooltipLine> list)
        {
            foreach (TooltipLine line2 in list)
            {
                if (line2.mod == "Terraria" && line2.Name == "ItemName")
                {
                    line2.overrideColor = new Color(Main.DiscoR, Main.DiscoG, Main.DiscoB);
                }
            }
        }

        public override void SetDefaults()
        {
            sbyte balloon = item.balloonSlot;
            item.CloneDefaults(ItemID.BundleofBalloons);
            item.width = 14;
            item.height = 28;
            item.rare = ItemRarityID.Purple;
            item.value = Item.sellPrice(gold: 20);
            item.balloonSlot = balloon;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.doubleJumpFart = true;
            player.doubleJumpSail = true;
            player.doubleJumpCloud = true;
            player.doubleJumpBlizzard = true;
            player.doubleJumpSandstorm = true;
            player.doubleJumpUnicorn = true;
            player.jumpBoost = true;
            player.bee = true;
            player.maxRunSpeed += 1f;
            player.runAcceleration += 1f;
            player.moveSpeed += 1f;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.BundleofBalloons, 1);
            recipe.AddIngredient(ModContent.ItemType<BundleOStrange>(), 1);
            recipe.AddIngredient(ItemID.BlessedApple, 1);
            recipe.AddTile(TileID.TinkerersWorkbench);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
