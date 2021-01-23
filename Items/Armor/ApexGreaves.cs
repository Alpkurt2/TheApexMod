using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.DataStructures;
using System.Collections.Generic;

namespace TheApexMod.Items.Armor
{
    [AutoloadEquip(EquipType.Legs)]
    public class ApexGreaves : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Apex Greaves");
            Tooltip.SetDefault("The final armor.\n150% increased movement speed.\nIncreases your max number of minions by 2.\nIncreases damage and melee speed by 20%\nEnemies are more likely to target you.");
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
            item.width = 26;
            item.height = 22;
            item.rare = ItemRarityID.Purple;
            item.defense = 30;
        }

        public override void UpdateEquip(Player player)
        {
            player.moveSpeed += 1.5f;
            player.maxRunSpeed += 1.5f;
            player.runAcceleration += 1.5f;
            player.maxMinions += 2;
            player.allDamage += 0.2f;
            player.meleeSpeed += 0.2f;
            player.aggro += 400;

        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<DivineWoodGreaves>(), 1);
            recipe.AddIngredient(ItemID.CopperGreaves, 1);
            recipe.AddIngredient(ItemID.SolarFlareLeggings, 1);
            recipe.AddIngredient(ItemID.NebulaLeggings, 1);
            recipe.AddIngredient(ItemID.StardustLeggings, 1);
            recipe.AddIngredient(ItemID.VortexLeggings, 1);
            recipe.AddIngredient(mod.ItemType("RainbowFeather"), 5);
            recipe.AddTile(TileID.LunarCraftingStation);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}