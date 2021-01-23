using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace TheApexMod.Projectiles.RangedProjectiles
{
    public class BGalaxyBlast : ModProjectile
    {
        public override void SetDefaults()
        {
            projectile.Name = "Galaxy Blast";
            projectile.width = 34;
            projectile.height = 82;
            projectile.timeLeft = 300;
            projectile.penetrate = 6;
            projectile.friendly = true;
            projectile.hostile = false;
            projectile.tileCollide = true;
            projectile.ignoreWater = true;
            projectile.melee = true;
            projectile.light = 1;
        }
        public override void AI()
        {
            projectile.rotation = (float)Math.Atan2((double)projectile.velocity.Y, (double)projectile.velocity.X) + 1.57f;
            if (Main.rand.Next(3) == 0)
                Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, DustID.Shadowflame);



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
                    int proj =Projectile.NewProjectile(spawn, speed, ModContent.ProjectileType<GalaxyArrow>(), damage, 1f, Main.myPlayer);
                    Main.projectile[proj].tileCollide = false;
                }
                else
                {
                    int proj1 = Projectile.NewProjectile(spawn1, speed1, ModContent.ProjectileType<GalaxyArrow>(), damage, 1f, Main.myPlayer);
                    Main.projectile[proj1].tileCollide = false;
                }
            }
        }



        public override void Kill(int timeLeft)
        {
            Main.PlaySound(SoundID.Item10, projectile.Center);

            for (int i = 0; i < 10; i++)
            {
                int dust = Dust.NewDust(projectile.position, projectile.width,
                    projectile.height, DustID.Shadowflame, 0f, 0f, 100, default(Color), 1f);
                Main.dust[dust].noGravity = true;
                Main.dust[dust].velocity *= 3f;
                dust = Dust.NewDust(projectile.position, projectile.width,
                    projectile.height, DustID.Shadowflame, 0f, 0f, 100, default(Color), 1f);
                Main.dust[dust].velocity *= 3f;
            }
        }
    }
}