using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using TheApexMod.Buffs;

namespace TheApexMod.Projectiles.MeleeProjectiles
{
    public class CopperShortswordPROJ : ModProjectile
    {
        public static Color OverrideColor = new Color(Main.DiscoR, Main.DiscoG, Main.DiscoB);
        public override void SetDefaults()
        {
            projectile.Name = "Copper Shortsword";
            projectile.penetrate = 1;
            projectile.width = 32;
            projectile.height = 32;
            projectile.friendly = true;
            projectile.hostile = false;
            projectile.tileCollide = false;
            projectile.timeLeft = 300;
            projectile.ignoreWater = true;
            projectile.melee = true;
            projectile.light = 2;
            projectile.scale = 1.5f;

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