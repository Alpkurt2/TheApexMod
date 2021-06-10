using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.DataStructures;
using System.Collections.Generic;
using TheApexMod.Items.Materials;

namespace TheApexMod.Items.Armor
{
    [AutoloadEquip(EquipType.Body)]
    public class ApexBreastplate : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Apex Breastplate");
            Tooltip.SetDefault("The final armor.\nTrue Regeneration.\nIncreases your max number of minions by 3\nIncreases damage by 20%.\nIncreases critical strike chance by 15%.\nEnemies are more likely to target you.");
            Main.RegisterItemAnimation(item.type, new DrawAnimationVertical(4, 7));
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
            item.value = Item.sellPrice(platinum: 1);
            item.width = 34;
            item.height = 24;
            item.rare = ItemRarityID.Purple;
            item.defense = 40;
        }

        public override void UpdateEquip(Player player)
        {
            player.lifeRegen += 50;
            player.maxMinions += 3;
            player.allDamage += 0.2f;
            player.aggro += 400;
            player.magicCrit += 15;
            player.rangedCrit += 15;
            player.meleeCrit += 15;

        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<DivineWoodBreastplate>(), 1);
            recipe.AddIngredient(ItemID.CopperChainmail, 1);
            recipe.AddIngredient(ItemID.SolarFlareBreastplate, 1);
            recipe.AddIngredient(ItemID.NebulaBreastplate, 1);
            recipe.AddIngredient(ItemID.StardustBreastplate, 1);
            recipe.AddIngredient(ItemID.VortexBreastplate, 1);
            recipe.AddIngredient(ModContent.ItemType<ApexEssence>(), 1);
            recipe.AddTile(TileID.LunarCraftingStation);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}