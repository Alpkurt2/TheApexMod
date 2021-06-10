using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace TheApexMod.Projectiles.RangedProjectiles
{
    public class ApexArrow : ModProjectile
    {
        public override void SetDefaults()
        {
            projectile.CloneDefaults(ProjectileID.MoonlordArrow);
            projectile.Name = "ApexArrow";
            projectile.penetrate = -1;
            projectile.alpha = 0;
            projectile.timeLeft = 420;
        }
        public override void AI()
        {
            projectile.rotation = (float)Math.Atan2((double)projectile.velocity.Y, (double)projectile.velocity.X) + 1.57f;
            for (int num479 = 0; num479 < 2; num479++)
            {
                int dust2 = Dust.NewDust(projectile.position, projectile.width, projectile.height, DustID.AncientLight, projectile.velocity.X * 0.1f, projectile.velocity.Y * 0.1f, 150, default(Color), 1.2f);
                Main.dust[dust2].noGravity = true;
            }
        }
        public override bool OnTileCollide(Vector2 oldVelocity)
        {
            projectile.velocity.X = 0f - projectile.velocity.X;
            projectile.velocity.Y = 0f - projectile.velocity.Y;
            return false;
        }


        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            target.immune[projectile.owner] = 6;
            target.AddBuff(mod.BuffType("WhiteFlames"), 300);
            Vector2 spawn = new Vector2(target.Center.X + Main.rand.Next(-150, 151), target.Center.Y - Main.rand.Next(600, 801));
            Vector2 speed = target.Center - spawn;
            speed.Normalize();
            speed *= 9f;
            Projectile.NewProjectile(spawn, speed * 2, ModContent.ProjectileType<ApexStar>(), damage, 1f, Main.myPlayer);
            for (int i = 0; i < 200; i++)
            {
                projectile.localNPCImmunity[i] = -1;
                Main.npc[i].immune[projectile.owner] = 0;
                damage = (int)((double)damage * 0.96);
            }
        }
    

        public override void Kill(int timeLeft)
        {
            Main.PlaySound(SoundID.Item10, projectile.Center);
            int num271 = Main.rand.Next(5, 10);
            for (int num272 = 0; num272 < num271; num272++)
            {
                int num273 = Dust.NewDust(projectile.Center, 0, 0, DustID.AncientLight, 0f, 0f, 100, default(Color), 0.5f);
                Dust dust98 = Main.dust[num273];
                Dust dust2 = dust98;
                dust2.velocity *= 1.6f;
                Main.dust[num273].velocity.Y -= 1f;
                Main.dust[num273].position = Vector2.Lerp(Main.dust[num273].position, projectile.Center, 0.5f);
                Main.dust[num273].noGravity = true;
            }
            Vector2 spawn = new Vector2(projectile.Center.X + Main.rand.Next(-150, 151), projectile.Center.Y - Main.rand.Next(600, 801));
            Vector2 speed = projectile.Center - spawn;
            speed.Normalize();
            speed *= 9f;
            Projectile.NewProjectile(spawn, speed * 2, ModContent.ProjectileType<ApexStar>(), projectile.damage, 1f, Main.myPlayer);
            
        }
    }
}
