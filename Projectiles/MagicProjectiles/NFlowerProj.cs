using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace TheApexMod.Projectiles.MagicProjectiles
{
    public class NFlowerProj : ModProjectile
    {
        public override void SetDefaults()
        {
            projectile.Name = "NFlowerProj";
            projectile.width = 16;
            projectile.height = 16;
            projectile.penetrate = 1;
            projectile.friendly = true;
            projectile.hostile = false;
            projectile.tileCollide = true;
            projectile.ignoreWater = true;
            projectile.magic = true;
            projectile.light = 0.8f;
            projectile.rotation = 6f;
            projectile.alpha = 100;
            projectile.aiStyle = 8;
        }
        public void Kill()
        { }
        public override void AI()
        {
            int num102 = Dust.NewDust(new Vector2(projectile.position.X + projectile.velocity.X, projectile.position.Y + projectile.velocity.Y), projectile.width, projectile.height, 135, projectile.velocity.X, projectile.velocity.Y, 100, default(Color), 3f * projectile.scale);
            Main.dust[num102].noGravity = true;
        }
    
        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            target.AddBuff(BuffID.OnFire, 300);
            target.AddBuff(BuffID.Frostburn, 300);
        }
        public override void Kill(int timeLeft)
        {
            Main.PlaySound(SoundID.Item10, projectile.Center);
            for (int i = 0; i < 20; i++)
            {
                int num584 = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, 135, (0f - projectile.velocity.X) * 0.2f, (0f - projectile.velocity.Y) * 0.2f, 100, default(Color), 2f * projectile.scale);
                Main.dust[num584].noGravity = true;
                Dust dust176 = Main.dust[num584];
                Dust dust2 = dust176;
                dust2.velocity *= 2f;
                num584 = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, DustID.Fire, (0f - projectile.velocity.X) * 0.2f, (0f - projectile.velocity.Y) * 0.2f, 100, default(Color), 1f * projectile.scale);
                dust176 = Main.dust[num584];
                dust2 = dust176;
                dust2.velocity *= 2f;
            }
        }
    }
}