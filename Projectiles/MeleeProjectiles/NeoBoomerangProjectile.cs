using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace TheApexMod.Projectiles.MeleeProjectiles
{
    public class NeoBoomerangProjectile : ModProjectile
    {
        public override void SetDefaults()
        {
            projectile.Name = "NeoBoomerangProjectile";
            projectile.CloneDefaults(ProjectileID.EnchantedBoomerang);
            aiType = ProjectileID.EnchantedBoomerang;
            projectile.width = 18;
            projectile.height = 32;
            projectile.penetrate = -1;
        }
        public override void AI()
        {
            if (Main.rand.Next(3) == 0)
                Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, DustID.Fire);
            Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, 135);
            Lighting.AddLight(projectile.position, 0f, 0.255f, 0.255f);
            Lighting.AddLight(projectile.position, 0.255f, 0.165f, 0f);
        }
        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            target.AddBuff(BuffID.Frostburn, 300);
            target.AddBuff(BuffID.OnFire, 300);
        }
    }
}
