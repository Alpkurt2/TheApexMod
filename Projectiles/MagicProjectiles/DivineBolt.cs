using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace TheApexMod.Projectiles.MagicProjectiles
{
    public class DivineBolt : ModProjectile
    {
        public override void SetDefaults()
        {
            projectile.Name = "WrathBolt";
            projectile.width = 16;
            projectile.height = 16;
            projectile.penetrate = 4;
            projectile.aiStyle = 29;
            projectile.timeLeft = 250;
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
                int num507 = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, DustID.PinkFlame, projectile.oldVelocity.X, projectile.oldVelocity.Y, 50, default(Color), 1.2f);
                Main.dust[num507].noGravity = true;
                Dust dust157 = Main.dust[num507];
                Dust dust2 = dust157;
                dust2.scale *= 1.25f;
                dust157 = Main.dust[num507];
                dust2 = dust157;
                dust2.velocity *= 0.5f;
            }
            Lighting.AddLight(projectile.position, 0.72f,0.60f,0.69f);
        }
        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            target.AddBuff(BuffID.ShadowFlame, 300);
            Vector2 spawn = new Vector2(target.Center.X + Main.rand.Next(-150, 151), target.Center.Y - Main.rand.Next(600, 801));
            Vector2 speed = target.Center - spawn;
            speed.Normalize();
            speed *= 9f;
            if (Main.rand.Next(3) == 0)
                Projectile.NewProjectile(spawn, speed * 2, ModContent.ProjectileType<DivineStar>(), damage / 2, 1f, Main.myPlayer);
        }
        public override void Kill(int timeLeft)
        {
            Main.PlaySound(SoundID.Item10, projectile.Center);
        }
    }
}