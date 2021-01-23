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
            projectile.penetrate = 3;
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
            for (int num506 = 0; num506 < 15; num506++)
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
            target.immune[projectile.owner] = 6;
            target.AddBuff(mod.BuffType("WhiteFlames"), 300);
            for (int i = 0; i < 3; i++)
            {
                float x = projectile.position.X + (float)Main.rand.Next(-50, 50);
                float y = projectile.position.Y - (float)Main.rand.Next(600, 900);
                float velY = (float)Main.rand.Next(20, 40);
                Projectile.NewProjectile(new Vector2(x, y), new Vector2(0, velY), mod.ProjectileType("ApexSwordRain"), projectile.damage, projectile.knockBack, projectile.owner);
            }
        }
        public override void Kill(int timeLeft)
        {
            Main.PlaySound(SoundID.Item10, projectile.Center);
        }
    }
}