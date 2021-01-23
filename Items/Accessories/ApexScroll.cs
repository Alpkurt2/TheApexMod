using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using TheApexMod.Items.Materials;

namespace TheApexMod.Items.Accessories
{
    public class ApexScroll : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Apex Scroll");
            Tooltip.SetDefault("Increases maximum minions by 5.\nIncreases minion knobkback by 3\n50% increased summon damage");
        }

        public override void SetDefaults()
        {
            item.CloneDefaults(ItemID.PapyrusScarab);
            item.width = 36;
            item.height = 36;
            item.rare = ItemRarityID.Purple;
            item.value = Item.sellPrice(gold: 20);
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

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.maxMinions += 5;
            player.minionKB += 3;
            player.minionDamage += 0.5f;
            player.GetModPlayer<ApexPlayer>().ApexScroll = true;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.PapyrusScarab, 1);
            recipe.AddIngredient(ItemID.PygmyNecklace, 1);
            recipe.AddIngredient(ItemID.SummonerEmblem, 1);
            recipe.AddIngredient(ModContent.ItemType<RainbowFeather>(), 5);
            recipe.AddTile(TileID.TinkerersWorkbench);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
