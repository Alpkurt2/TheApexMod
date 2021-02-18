using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace TheApexMod.Projectiles.MeleeProjectiles
{
    public class AHeroSwordProjectile : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            Main.projFrames[projectile.type] = 12;
        }
        public override void SetDefaults()
        {
            projectile.Name = "AHeroSwordProjectile";
            projectile.penetrate = 4;
            projectile.width = 40;
            projectile.height = 40;
            projectile.friendly = true;
            projectile.hostile = false;
            projectile.tileCollide = true;
            projectile.ignoreWater = true;
            projectile.melee = true;
            projectile.light = 2;
            projectile.scale = 1.5f;

        }
        public override void AI()
        {
            projectile.rotation = (float)Math.Atan2(projectile.velocity.Y, projectile.velocity.X) + 0.785f;

            int num313 = Dust.NewDust(new Vector2(projectile.Center.X - projectile.velocity.X * 4f + 2f, projectile.Center.Y + 2f - projectile.velocity.Y * 4f), projectile.width / 4, projectile.height / 4, 135, projectile.oldVelocity.X, projectile.oldVelocity.Y, 100, default(Color), 1.25f);
            Dust dust53 = Main.dust[num313];
            Main.dust[num313].noGravity = true;
            Dust dust2 = dust53;
            dust2.velocity *= -0.25f;
            num313 = Dust.NewDust(new Vector2(projectile.Center.X - projectile.velocity.X * 4f + 2f, projectile.Center.Y + 2f - projectile.velocity.Y * 4f), projectile.width / 4, projectile.height / 4, DustID.AmberBolt, projectile.oldVelocity.X, projectile.oldVelocity.Y, 100, default(Color), 1.25f);
            dust53 = Main.dust[num313];
            dust2 = dust53;
            dust2.velocity *= -0.25f;
            dust53 = Main.dust[num313];
            dust2 = dust53;
            dust2.position -= projectile.velocity * 0.5f;
            Main.dust[num313].noGravity = true;
        }
        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            target.AddBuff(BuffID.Daybreak, 300);
            float x = target.position.X + -1000;
            float y = target.position.Y;
            float velY = 0;
            float velX = 50;
            Projectile.NewProjectile(new Vector2(x, y), new Vector2(velX, velY), mod.ProjectileType("EArthursProjectile"), damage, 0, projectile.owner);
            float x2 = target.position.X + 1000;
            float velX2 = -50;
            Projectile.NewProjectile(new Vector2(x2, y), new Vector2(velX2, velY), mod.ProjectileType("EArthursProjectile"), damage, 0, projectile.owner);
        }
        public override bool PreDraw(SpriteBatch spriteBatch, Color lightColor)
        {
            projectile.frameCounter++;
            if (projectile.frameCounter >= Main.projFrames[projectile.type] - 1)
            {
                projectile.frame++;
                projectile.frameCounter = 0;
                if (projectile.frame > Main.projFrames[projectile.type] - 1)
                    projectile.frame = 0;
            }
            return true;
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
                    projectile.height, DustID.AmberBolt, 0f, 0f, 100, default(Color), 1f);
                Main.dust[dust].velocity *= 3f;
            }
        }
    }
}