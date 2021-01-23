using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using TheApexMod.Items.Materials;

namespace TheApexMod.Items.Accessories
{
    public class ApexScope : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Apex Scope");
            Tooltip.SetDefault("Increased view range with right click\n50% chance to not consume ammo\n50% increased ranged damage\n15% ranged critical strike chance\nGreatly increases arrow speed");
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
            item.CloneDefaults(ItemID.SniperScope);
            item.width = 30;
            item.height = 30;
            item.rare = ItemRarityID.Purple;
            item.value = Item.sellPrice(gold: 20);
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        { 
            player.rangedDamage += 0.5f;
            player.rangedCrit += 15;
            player.GetModPlayer<ApexPlayer>().ApexScope = true;
            player.magicQuiver = true;
            if (ModContent.GetInstance<ApexConfig>().ApexScope)
            {
                player.scope = true;
            }
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.SniperScope, 1);
            recipe.AddIngredient(ItemID.MagicQuiver, 1);
            recipe.AddIngredient(ItemID.RangerEmblem, 1);
            recipe.AddIngredient(ModContent.ItemType<RainbowFeather>(), 5);
            recipe.AddTile(TileID.TinkerersWorkbench);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
