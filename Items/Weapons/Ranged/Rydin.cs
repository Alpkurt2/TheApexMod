using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace TheApexMod.Items.Weapons.Ranged
{
    public class Rydin : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Rydin");
        }

        public override void SetDefaults()
        {
            item.damage = 100;
            item.noMelee = true;
            item.ranged = true;
            item.Size = new Vector2(120f);
            item.useAnimation = 35;
            item.useTime = 35;
            item.useStyle = ItemUseStyleID.HoldingOut;
            item.knockBack = 7;
            item.value = Item.sellPrice(gold: 4);
            item.rare = ItemRarityID.Pink;
            item.UseSound = SoundID.Item11;
            item.autoReuse = true;
            item.useAmmo = AmmoID.Bullet;
            item.shoot = ProjectileID.Bullet;
            item.shootSpeed = 20;
        }
        public override Vector2? HoldoutOffset()
        {
            return new Vector2(-3.5f, 0);
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.RedRyder, 1);
            recipe.AddIngredient(ModContent.ItemType<Materials.ConcentratedSnow>(), 1);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
