using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace TheApexMod.Projectiles.MagicProjectiles
{
    public class ApexBolt : ModProjectile
    {
        public override void SetDefaults()
        {
            projectile.Name = "ApexBolt";
            projectile.width = 16;
            projectile.height = 16;
            projectile.penetrate = 1;
            projectile.timeLeft = 250;
            projectile.aiStyle = 29;
            projectile.friendly = true;
            projectile.hostile = false;
            projectile.tileCollide = true;
            projectile.ignoreWater = true;
            projectile.magic = true;
            projectile.alpha = 255;
        }
        public override void AI()
        {
            projectile.rotation = (float)Math.Atan2((double)projectile.velocity.Y, (double)projectile.velocity.X) + 1.57f;
            for (int num506 = 0; num506 < 2; num506++)
            {
                int num507 = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, DustID.AncientLight, projectile.oldVelocity.X, projectile.oldVelocity.Y, 50, default(Color), 1.2f);
                Main.dust[num507].noGravity = true;
                Dust dust157 = Main.dust[num507];
                Dust dust2 = dust157;
                dust2.scale *= 1.25f;
                dust157 = Main.dust[num507];
                dust2 = dust157;
                dust2.velocity *= 0.5f;
            }
            Lighting.AddLight(projectile.position, 1f,1f,1f);
        }
        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            target.immune[projectile.owner] = 3;
            target.AddBuff(mod.BuffType("WhiteFlames"), 300);
            for (int i = 0; i < 3; i++)
            {
                Vector2 spawn = new Vector2(target.position.X - 1000, target.position.Y + Main.rand.Next(-2500, 2500));
                Vector2 speed = target.position - spawn;
                speed.Normalize();
                speed *= 15f;
                Vector2 spawn1 = new Vector2(target.position.X + 1000, target.position.Y + Main.rand.Next(-2500, 2500));
                Vector2 speed1 = target.position - spawn1;
                speed1.Normalize();
                speed1 *= 15f;
                if (Main.rand.Next(2) == 0)
                {
                    Projectile.NewProjectile(spawn, speed * 2, ModContent.ProjectileType<Projectiles.MagicProjectiles.ApexBolt2>(), damage, 1f, Main.myPlayer);
                }
                else
                {
                    Projectile.NewProjectile(spawn1, speed1 * 2, ModContent.ProjectileType<Projectiles.MagicProjectiles.ApexBolt2>(), damage, 1f, Main.myPlayer);
                }
            }
        }
        public override void Kill(int timeLeft)
        {
            Main.PlaySound(SoundID.Item10, projectile.Center);
        }
    }
}