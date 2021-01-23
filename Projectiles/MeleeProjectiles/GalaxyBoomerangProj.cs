using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace TheApexMod.Projectiles.MeleeProjectiles
{
    public class GalaxyBoomerangProj : ModProjectile
    {
        public override void SetDefaults()
        {
            projectile.Name = "GalaxyBoomerangProjectile";
            projectile.CloneDefaults(ProjectileID.EnchantedBoomerang);
            aiType = ProjectileID.EnchantedBoomerang;
            projectile.width = 18;
            projectile.height = 32;
            projectile.penetrate = -1;
        }
        public override void AI()
        {
            if (Main.rand.Next(3) == 0)
                Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, DustID.Shadowflame);
            Lighting.AddLight(projectile.position, 0.128f, 0f, 0.128f);
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
            target.AddBuff(BuffID.ShadowFlame, 300);
            float numberProjectiles = 2;
            float rotation = MathHelper.ToRadians(5);
            projectile.position += Vector2.Normalize(new Vector2(projectile.velocity.X, projectile.velocity.Y)) * 45f;
            for (int i = 0; i < numberProjectiles; i++)
            {
                Vector2 spawn = new Vector2(projectile.Center.X, projectile.Center.Y);
                Vector2 speed = target.Center - spawn;
                speed.Normalize();
                speed *= 15f;
                Vector2 perturbedSpeed = (speed).RotatedBy(MathHelper.Lerp(-rotation, rotation, i / (numberProjectiles - 1))) * .8f;
                Projectile.NewProjectile(spawn, new Vector2(perturbedSpeed.X, perturbedSpeed.Y), ModContent.ProjectileType<BoomerangSpirit>(), damage, 1f, Main.myPlayer);
            }

        }
    }
}
