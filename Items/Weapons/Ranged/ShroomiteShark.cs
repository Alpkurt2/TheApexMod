using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace TheApexMod.Items.Weapons.Ranged
{
    public class ShroomiteShark : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Shroomite Shark");
            Tooltip.SetDefault("50% chance to not consume ammo\nHas a chance to fire a laser that does 3x damage\n'Megasharks long gone brother'");
        }

        public override void SetDefaults()
        {
            item.damage = 32;
            item.noMelee = true;
            item.ranged = true;
            item.Size = new Vector2(120f);
            item.useAnimation = 6;
            item.useTime = 6;
            item.useStyle = ItemUseStyleID.HoldingOut;
            item.knockBack = 1.25f;
            item.value = Item.sellPrice(gold: 10);
            item.rare = ItemRarityID.Yellow;
            item.UseSound = SoundID.Item11;
            item.autoReuse = true;
            item.useAmmo = AmmoID.Bullet;
            item.shoot = ProjectileID.Bullet;
            item.shootSpeed = 12f;
        }
        public override Vector2? HoldoutOffset()
        {
            return new Vector2(-3.5f, 1);
        }
        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            if (Main.rand.Next(5) == 0)
            {
                Projectile.NewProjectile(position.X, position.Y, speedX, speedY, ProjectileID.LaserMachinegunLaser, damage * 3, knockBack, player.whoAmI);
                item.UseSound = SoundID.Item12;
                return false;
            }
            else
            {
                item.UseSound = SoundID.Item11;
            }
            return true;
        }
        public override bool ConsumeAmmo(Player player)
        {
            return Main.rand.Next(2) == 0;
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.Megashark, 1);
            recipe.AddIngredient(ItemID.ShroomiteBar, 10);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
