using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Steamworks;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace TheApexMod.Projectiles.RangedProjectiles
{
    public class GalaxyShurikenProjectile : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            ProjectileID.Sets.TrailCacheLength[projectile.type] = 5;
            ProjectileID.Sets.TrailingMode[projectile.type] = 0;        
        }
        public override void SetDefaults()
        {
            projectile.Name = "GalaxyShurikenProjectile";
            projectile.width = 18;
            projectile.height = 26;
            projectile.penetrate = 7;
            projectile.friendly = true;
            projectile.hostile = false;
            projectile.tileCollide = true;
            projectile.ignoreWater = true;
            projectile.aiStyle = 2;
            projectile.ranged = true;
            projectile.rotation += 0.4f * (float)projectile.direction;
        }
        public override void AI()
        {
            if (Main.rand.Next(3) == 0)
                Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, 179);
            Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, 27);
            Lighting.AddLight(projectile.position, 0.128f, 0f, 0.128f);
        }
        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            target.AddBuff(BuffID.ShadowFlame, 300);
            target.immune[projectile.owner] = 8;
            for (int i = 0; i < 4; i++)
            {
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
                    Projectile.NewProjectile(spawn, speed * 2, ModContent.ProjectileType<ShurikenSpirit>(), damage, 1f, Main.myPlayer);
                }
                else
                {
                    Projectile.NewProjectile(spawn1, speed1 * 2, ModContent.ProjectileType<ShurikenSpirit>(), damage, 1f, Main.myPlayer);
                }
            }
        }
        


        public override void Kill(int timeLeft)
        {
            Main.PlaySound(SoundID.Item10, projectile.Center);

            for (int i = 0; i < 10; i++)
            {
                int dust = Dust.NewDust(projectile.position, projectile.width,
                    projectile.height, 179, 0f, 0f, 100, default(Color), 3f);
                Main.dust[dust].noGravity = true;
                Main.dust[dust].velocity *= 4f;
                dust = Dust.NewDust(projectile.position, projectile.width,
                    projectile.height, 27, 0f, 0f, 100, default(Color), 1f);
                Main.dust[dust].velocity *= 2f;
            }
        }
        public override bool PreDraw(SpriteBatch spriteBatch, Color lightColor)
        {
            Vector2 drawOrigin = new Vector2(Main.projectileTexture[projectile.type].Width * 0.5f, projectile.height * 0.5f);
            for (int k = 0; k < projectile.oldPos.Length; k++)
            {
                Vector2 drawPos = projectile.oldPos[k] - Main.screenPosition + drawOrigin + new Vector2(0f, projectile.gfxOffY);
                Color color = projectile.GetAlpha(lightColor) * ((float)(projectile.oldPos.Length - k) / (float)projectile.oldPos.Length);
                spriteBatch.Draw(Main.projectileTexture[projectile.type], drawPos, null, color, projectile.rotation, drawOrigin, projectile.scale, SpriteEffects.None, 0f);
            }
            return true;
        }
    }
}