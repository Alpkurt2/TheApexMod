using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace TheApexMod.Items.Weapons.Melee
{
    public class TheCane : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("The Cane");
        }

        public override void SetDefaults()
        {
            item.damage = 50;
            item.melee = true;
            item.Size = new Vector2(120f);
            item.useTime = 16;
            item.useAnimation = 16;
            item.useStyle = ItemUseStyleID.SwingThrow;
            item.knockBack = 8;
            item.value = Item.sellPrice(gold: 2);
            item.rare = ItemRarityID.Pink;
            item.UseSound = SoundID.Item1;
            item.autoReuse = true;
            item.shoot = ModContent.ProjectileType<Projectiles.MeleeProjectiles.CaneProj>();
            item.shootSpeed = 15;
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.CandyCaneSword, 1);
            recipe.AddIngredient(mod.ItemType("ConcentratedSnow"), 1);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
