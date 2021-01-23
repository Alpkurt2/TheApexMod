using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace TheApexMod.Items.Tools
{
    public class CanePickaxe : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Cane Pickaxe");
        }
        public override void SetDefaults()
        {
            item.CloneDefaults(ItemID.CnadyCanePickaxe);
            item.damage = 24;
            item.pick = 165;
            item.useTime = 7;
            item.useAnimation = 19;
            item.tileBoost += 1;
            item.scale = 1.25f;
            item.rare = ItemRarityID.Pink;
            item.value = Item.sellPrice(gold: 1);

            item.width = 20;
            item.height = 20;
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.CnadyCanePickaxe, 1);
            recipe.AddIngredient(ModContent.ItemType<Materials.ConcentratedSnow>(), 1);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
