using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

using System.Collections.Generic;

namespace TheApexMod.Projectiles.MeleeProjectiles
{
    public class GalaxyGP : ModProjectile
    {
        public override void SetDefaults()
        {
            projectile.Name = "GalaxyGP";
            projectile.width = 48;
            projectile.height = 48;
            projectile.penetrate = 5;
            projectile.timeLeft = 250;
            projectile.aiStyle = 27;
            projectile.friendly = true;
            projectile.hostile = false;
            projectile.tileCollide = true;
            projectile.ignoreWater = true;
            projectile.melee = true;
        }
        public override void AI()
        {
            Lighting.AddLight(projectile.position, 0.128f, 0f, 0.128f);
        }
        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            target.AddBuff(BuffID.ShadowFlame, 300);
            for (int i = 0; i < 3; i++)
            {
                Vector2 spawn = new Vector2(target.Center.X - 500, target.Center.Y + Main.rand.Next(-2500, 2500));
                Vector2 speed = target.Center - spawn;
                speed.Normalize();
                speed *= 30f;
                Vector2 spawn1 = new Vector2(target.Center.X + 500, target.Center.Y + Main.rand.Next(-2500, 2500));
                Vector2 speed1 = target.Center - spawn1;
                speed1.Normalize();
                speed1 *= 30f;
                if (Main.rand.Next(2) == 0)
                {
                    Projectile.NewProjectile(spawn, speed, ModContent.ProjectileType<MGalaxyGP>(), damage, 1f, Main.myPlayer);
                }
                else
                {
                    Projectile.NewProjectile(spawn1, speed1, ModContent.ProjectileType<MGalaxyGP>(), damage, 1f, Main.myPlayer);
                }
            }
        }

        public override void Kill(int timeLeft)
        {
            Main.PlaySound(SoundID.Item10, projectile.Center);
            for (int i = 0; i < 10; i++)
            {
                int dust = Dust.NewDust(projectile.position, projectile.width,
                    projectile.height, DustID.Shadowflame, 0f, 0f, 100, default(Color), 2f);
                Main.dust[dust].noGravity = true;
                Main.dust[dust].velocity *= 7f;
            }
        }
    }
}
