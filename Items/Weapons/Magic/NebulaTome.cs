using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace TheApexMod.Items.Weapons.Magic
{
    public class NebulaTome : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Nebula Tome");
            Tooltip.SetDefault("A tome made out of the nebula fragments.");
        }

        public override void SetDefaults()
        {
            item.damage = 95;
            item.mana = 20;
            item.UseSound = SoundID.Item43;
            item.useStyle = ItemUseStyleID.HoldingOut;

            item.useAnimation = 10;
            item.useTime = 10;
            item.width = 40;
            item.height = 40;

            item.knockBack = 4f;
            item.magic = true;
            item.autoReuse = true;
            item.value = Item.sellPrice(gold: 2);
            item.rare = ItemRarityID.Red;
            item.noMelee = true;
            item.shoot = mod.ProjectileType("NebulaBolt");
            item.shootSpeed = 10;
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.FragmentNebula, 18);
            recipe.AddTile(TileID.LunarCraftingStation);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            for (int i = 0; i < 3; i++)
            {
                Vector2 spawn = new Vector2(Main.MouseWorld.X - 1000, Main.MouseWorld.Y + Main.rand.Next(-2500, 2500));
                Vector2 speed = Main.MouseWorld - spawn;
                speed.Normalize();
                speed *= 15f;
                Vector2 spawn1 = new Vector2(Main.MouseWorld.X + 1000, Main.MouseWorld.Y + Main.rand.Next(-2500, 2500));
                Vector2 speed1 = Main.MouseWorld - spawn1;
                speed1.Normalize();
                speed1 *= 15f;
                if (Main.rand.Next(2) == 0)
                {
                    Projectile.NewProjectile(spawn, speed * 2, ModContent.ProjectileType<Projectiles.MagicProjectiles.NebulaBolt>(), damage, 1f, Main.myPlayer);
                }
                else
                {
                    Projectile.NewProjectile(spawn1, speed1 * 2, ModContent.ProjectileType<Projectiles.MagicProjectiles.NebulaBolt>(), damage, 1f, Main.myPlayer);
                }
            }
            return false;
        }
    }
}

