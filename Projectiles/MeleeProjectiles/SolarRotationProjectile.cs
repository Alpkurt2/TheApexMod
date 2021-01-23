using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace TheApexMod.Projectiles.MeleeProjectiles
{
    public class SolarRotationProjectile : ModProjectile
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
            Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, DustID.Fire, 0, 0, 0, default(Color), 1.5f);
            Lighting.AddLight(projectile.position, 0.255f, 0.165f, 0f);
            if (projectile.ai[0] == 1)
            {
                projectile.localAI[0] += 0.1f;
                projectile.position += projectile.DirectionTo(Main.player[projectile.owner].Center) * projectile.localAI[0];

                if (projectile.Distance(Main.player[projectile.owner].Center) <= projectile.localAI[0])
                    projectile.Kill();
            }
        }
        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            target.AddBuff(BuffID.Daybreak, 300);
            Projectile.NewProjectile(target.Center.X, target.Center.Y, 0f, 0f, ProjectileID.SolarWhipSwordExplosion, damage, 10f, projectile.owner, 0f, 0.85f + Main.rand.NextFloat() * 1.15f);
        }
    }
}
