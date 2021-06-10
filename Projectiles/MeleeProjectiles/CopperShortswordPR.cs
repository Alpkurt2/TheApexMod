using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using TheApexMod.Buffs;

namespace TheApexMod.Projectiles.MeleeProjectiles
{
    public class CopperShortswordPR : ModProjectile
    {

        public override void SetDefaults()
        {
            projectile.Name = "AHeroSwordProjectile";
            projectile.penetrate = 4;
            projectile.width = 40;
            projectile.height = 40;
            projectile.friendly = true;
            projectile.hostile = false;
            projectile.tileCollide = false;
            projectile.timeLeft = 300;
            projectile.ignoreWater = true;
            projectile.melee = true;
            projectile.light = 2;
            projectile.scale = 2.25f;

        }
        public override Color? GetAlpha(Color lightColor)
        {
            return Color.White; // So the projectile's sprite isn't affected by light
        }
        // This gives the projectile an outline that constantly changes color
        public override void AI()
        {
            projectile.rotation = (float)Math.Atan2(projectile.velocity.Y, projectile.velocity.X) + 0.785f;
        }
        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            target.AddBuff(ModContent.BuffType<WhiteFlames>(), 300);
            target.immune[projectile.owner] = 4;
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
                    Projectile.NewProjectile(spawn, speed * 2, ModContent.ProjectileType<CopperShortswordPROJ>(), damage, 1f, Main.myPlayer);
                }
                else
                {
                    Projectile.NewProjectile(spawn1, speed1 * 2, ModContent.ProjectileType<CopperShortswordPROJ>(), damage, 1f, Main.myPlayer);
                }
            }
        }
        public override bool PreDraw(SpriteBatch spriteBatch, Color lightColor)
        {
            Texture2D texture = Main.projectileTexture[projectile.type];
            Vector2 position = projectile.position - Main.screenPosition + new Vector2(projectile.width / 2, projectile.height - texture.Height * 0.5f + 2f);
            for (int i = 0; i < 4; i++)
            {
                Vector2 offsetPositon = Vector2.UnitY.RotatedBy(MathHelper.PiOver2 * i) * 2;
                spriteBatch.Draw(texture, position + offsetPositon, null, Main.DiscoColor, projectile.rotation, texture.Size() * 0.5f, projectile.scale, SpriteEffects.None, 0f);
            }
            return false;
        }

        public override void Kill(int timeLeft)
        {
            Main.PlaySound(SoundID.Item10, projectile.Center);

        }
    }
}