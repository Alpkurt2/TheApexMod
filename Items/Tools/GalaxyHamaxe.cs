using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace TheApexMod.Items.Tools
{
    public class GalaxyHamaxe : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Galaxy Hamaxe");
        }
        public override void SetDefaults()
        {
            item.CloneDefaults(ItemID.MoltenHamaxe);
            item.damage = 38;
            item.useTime = 14;
            item.useAnimation = 14;
            item.axe = 175 / 5;
            item.hammer = 125;
            item.tileBoost += 2;
            item.rare = ItemRarityID.Red;
            item.value = Item.sellPrice(gold: 10);

            item.width = 20;
            item.height = 20;
        }
        public override void MeleeEffects(Player player, Rectangle hitbox)
        {
            if (Main.rand.Next(2) == 0)
                Dust.NewDust(new Vector2(hitbox.X, hitbox.Y), hitbox.Width, hitbox.Height, DustID.Shadowflame);
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<NeoHamaxe>(), 1);
            recipe.AddIngredient(ModContent.ItemType<Materials.DivineFragment>(), 10);
            recipe.AddTile(TileID.LunarCraftingStation);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
