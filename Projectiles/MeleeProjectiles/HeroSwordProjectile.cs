using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace TheApexMod.Projectiles.MeleeProjectiles
{
    public class HeroSwordProjectile : ModProjectile
    {
        public override void SetDefaults()
        {
            projectile.Name = "HeroSwordProjectile";
            projectile.penetrate = 3;
            projectile.width = 40;
            projectile.height = 40;
            projectile.friendly = true;
            projectile.hostile = false;
            projectile.tileCollide = true;
            projectile.ignoreWater = true;
            projectile.melee = true;
            projectile.light = 2;

        }
        public override void AI()
        {
            projectile.rotation = (float)Math.Atan2(projectile.velocity.Y, projectile.velocity.X) + 0.785f;

            int num313 = Dust.NewDust(new Vector2(projectile.Center.X - projectile.velocity.X * 4f + 2f, projectile.Center.Y + 2f - projectile.velocity.Y * 4f), 8, 8, 135, projectile.oldVelocity.X, projectile.oldVelocity.Y, 100, default(Color), 1.25f);
            Dust dust53 = Main.dust[num313];
            Main.dust[num313].noGravity = true;
            Dust dust2 = dust53;
            dust2.velocity *= -0.25f;
            num313 = Dust.NewDust(new Vector2(projectile.Center.X - projectile.velocity.X * 4f + 2f, projectile.Center.Y + 2f - projectile.velocity.Y * 4f), 8, 8, 135, projectile.oldVelocity.X, projectile.oldVelocity.Y, 100, default(Color), 1.25f);
            dust53 = Main.dust[num313];
            dust2 = dust53;
            dust2.velocity *= -0.25f;
            dust53 = Main.dust[num313];
            dust2 = dust53;
            dust2.position -= projectile.velocity * 0.5f;
            Main.dust[num313].noGravity = true;
        }

        public override void Kill(int timeLeft)
        {
            Main.PlaySound(SoundID.Item10, projectile.Center);

            for (int i = 0; i < 10; i++)
            {
                int dust = Dust.NewDust(projectile.Center, projectile.width,
                    projectile.height, 135, 0f, 0f, 100, default(Color), 3f);
                Main.dust[dust].noGravity = true;
                Main.dust[dust].velocity *= 7f;
                dust = Dust.NewDust(projectile.Center, projectile.width,
                    projectile.height, 135, 0f, 0f, 100, default(Color), 1f);
                Main.dust[dust].velocity *= 3f;
            }
        }
    }
}