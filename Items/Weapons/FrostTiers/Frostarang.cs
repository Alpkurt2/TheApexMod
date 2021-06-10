using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using TheApexMod.Items.Materials;
using TheApexMod.Projectiles.MeleeProjectiles;

namespace TheApexMod.Items.Weapons.FrostTiers
{
    public class Frostarang : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Frostarang");
            item.damage = 28;
        }

        public override void SetDefaults()
        {
            item.CloneDefaults(ItemID.Flamarang);
            item.shoot = ModContent.ProjectileType<FrostarangProjectile>();
        }
        public override bool CanUseItem(Player player)
        {
            return player.ownedProjectileCounts[item.shoot] < 1;
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<FroststoneBar>(), 10);
            recipe.AddIngredient(ItemID.IceBoomerang, 1);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
