using System;
using System.Security.Policy;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace TheApexMod.Projectiles
{
    public class DivineStar : ModProjectile
    {
        public override void SetDefaults()
        {
            projectile.Name = "DivineStar";
            projectile.width = 32;
            projectile.height = 32;
            projectile.penetrate = 2;
            projectile.friendly = true;
            projectile.hostile = false;
            projectile.tileCollide = false;
            projectile.ignoreWater = true;
            projectile.light = 0.9f;
            projectile.aiStyle = 5;
            projectile.alpha = 50;
            projectile.scale = 0.8f;

        }
        public override void AI()
        {
            projectile.rotation += 0.4f * (float)projectile.direction;
            if (Main.rand.Next(10) == 0)
                Dust.NewDust(projectile.position, projectile.width, projectile.height, 58, projectile.velocity.X * 0.5f, projectile.velocity.Y * 0.5f, 150, default(Color), 1.2f);
            if (Main.rand.Next(20) == 0)
                Gore.NewGore(projectile.position, new Vector2(projectile.velocity.X * 0.2f, projectile.velocity.Y * 0.2f), Main.rand.Next(16, 18));


            if (projectile.position.Y > projectile.ai[1])
            {
                projectile.tileCollide = true;
            }
            else
            {
                if (projectile.ai[1] == 0f && !Collision.SolidCollision(projectile.position, projectile.width, projectile.height))
                {
                    projectile.ai[1] = 1f;
                    projectile.netUpdate = true;
                }
                if (projectile.ai[1] != 0f)
                {
                    projectile.tileCollide = true;
                }
            }
            if (projectile.soundDelay == 0)
            {
                projectile.soundDelay = 20 + Main.rand.Next(40);
                Main.PlaySound(SoundID.Item9, projectile.position);

            }

        }
        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            target.AddBuff(BuffID.ShadowFlame, 120);
        }
        public override void Kill(int timeLeft)
        {
            Main.PlaySound(SoundID.Item10, projectile.Center);
        }
    }
}
