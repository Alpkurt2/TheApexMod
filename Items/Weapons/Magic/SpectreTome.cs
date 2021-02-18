using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace TheApexMod.Items.Weapons.Magic
{
    public class SpectreTome : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Spectre Tome");
        }

        public override void SetDefaults()
        {
            item.damage = 65;
            item.magic = true;
            item.Size = new Vector2(120f);
            item.useTime = 16;
            item.useAnimation = 16;
            item.useStyle = ItemUseStyleID.HoldingOut;
            item.knockBack = 6.5f;
            item.value = Item.sellPrice(gold: 5);
            item.rare = ItemRarityID.Yellow;
            item.UseSound = SoundID.Item8;
            item.autoReuse = true;
            item.shoot = mod.ProjectileType("SpectreBolt");
            item.shootSpeed = 11;
            item.noMelee = true;
            item.mana = 16;
        }
        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            float numberProjectiles = 3;
            for (int i = 0; i < numberProjectiles; i++)
            {
                Vector2 spawn = new Vector2(position.X + Main.rand.Next(-200, 200), position.Y + Main.rand.Next(-100, 100));
                Vector2 speed = Main.MouseWorld - spawn;
                speed.Normalize();
                speed *= 15f;
                Projectile.NewProjectile(spawn, speed * 2, ModContent.ProjectileType<Projectiles.MagicProjectiles.SpectreBolt>(), damage, 1f, Main.myPlayer);

            }
            return false;
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.SpellTome, 1);
            recipe.AddIngredient(ItemID.SpectreBar, 10);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
