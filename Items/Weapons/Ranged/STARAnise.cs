using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace TheApexMod.Items.Weapons.Ranged
{
    public class STARAnise : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("STAR Anise");
        }

        public override void SetDefaults()
        {
            item.damage = 28;
            item.ranged = true;
            item.Size = new Vector2(120f);
            item.noMelee = true;
            item.useTime = 16;
            item.useAnimation = 16;
            item.noUseGraphic = true;
            item.useStyle = ItemUseStyleID.SwingThrow;
            item.knockBack = 0;
            item.value = Item.sellPrice(0, 1, 50, 0);
            item.rare = ItemRarityID.Pink;
            item.UseSound = SoundID.Item1;
            item.autoReuse = true;
            item.shoot = mod.ProjectileType("StarAProj");
            item.shootSpeed = 15f;
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.StarAnise, 200);
            recipe.AddIngredient(ItemID.FallenStar, 10);
            recipe.AddIngredient(ModContent.ItemType<Materials.ConcentratedSnow>(), 1);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
