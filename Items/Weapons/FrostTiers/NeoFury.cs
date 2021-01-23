using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using TheApexMod.Items.Materials;

namespace TheApexMod.Items.Weapons.FrostTiers
{
    public class NeoFury : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Neo Fury");
            Tooltip.SetDefault("Converts Wooden, Flaming and Frostburn Arrows into Frostflame Arrows.");
        }

        public override void SetDefaults()
        {
            item.CloneDefaults(ItemID.MoltenFury);
            item.damage = 42;
            item.useTime = 18;
            item.useAnimation = 18;
            item.shootSpeed = 12f;
            item.autoReuse = true;
        }
        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {

            if (type == ProjectileID.WoodenArrowFriendly || type == ProjectileID.FrostburnArrow || type == ProjectileID.FlamingArrow)
            {
                Projectile.NewProjectile(position.X, position.Y, speedX, speedY, ModContent.ProjectileType<Projectiles.RangedProjectiles.FrostfireArrow>(), damage, knockBack, player.whoAmI);
                return false;
            }
            return true;
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.MoltenFury, 1);
            recipe.AddIngredient(ModContent.ItemType<FrozenFury>(), 1);
            recipe.AddIngredient(ItemID.SoulofLight, 12);
            recipe.AddIngredient(ItemID.SoulofNight, 12);
            recipe.AddIngredient(ItemID.DarkShard, 1);
            recipe.AddIngredient(ItemID.LightShard, 1);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
