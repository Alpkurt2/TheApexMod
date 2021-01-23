using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

using System.Collections.Generic;

namespace TheApexMod.Projectiles.MeleeProjectiles
{
    public class RBreaker : ModProjectile
    {
        public override void SetDefaults()
        {
            projectile.Name = "RBreaker";
            projectile.width = 18;
            projectile.height = 26;
            projectile.timeLeft = 60;
            projectile.penetrate = -1;
            projectile.friendly = true;
            projectile.hostile = false;
            projectile.tileCollide = true;
            projectile.ignoreWater = true;
            projectile.melee = true;
            projectile.light = 2;

        }
        public override void AI()
        {
            if (Main.rand.Next(3) == 0)
                Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, DustID.AncientLight);
        }
        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            target.immune[projectile.owner] = 6;
            target.AddBuff(ModContent.BuffType<Buffs.WhiteFlames>(), 60);

            Vector2 spawn = new Vector2(target.Center.X - 1000, target.Center.Y + Main.rand.Next(-2500, 2500));
            Vector2 speed = target.Center - spawn;
            speed.Normalize();
            speed *= 30f;
            Vector2 spawn1 = new Vector2(target.Center.X + 1000, target.Center.Y + Main.rand.Next(-2500, 2500));
            Vector2 speed1 = target.Center - spawn1;
            speed1.Normalize();
            speed1 *= 30f;
            if (Main.rand.Next(2) == 0)
            {
                Projectile.NewProjectile(spawn, speed * 2, ModContent.ProjectileType<RbrE>(), damage, 1f, Main.myPlayer);
            }
            else
            {
                Projectile.NewProjectile(spawn1, speed1 * 2, ModContent.ProjectileType<RbrE>(), damage, 1f, Main.myPlayer);
            }
        }


        public override void Kill(int timeLeft)
        {
            Main.PlaySound(SoundID.Item10, projectile.Center);

            for (int i = 0; i < 10; i++)
            {
                int dust = Dust.NewDust(projectile.position, projectile.width,
                    projectile.height, DustID.AncientLight, 0f, 0f, 100, default(Color), 1.5f);
                Main.dust[dust].noGravity = true;
                Main.dust[dust].velocity *= 7f;
            }
        }
    }
}
