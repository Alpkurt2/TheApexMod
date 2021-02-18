using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace TheApexMod.Projectiles.MeleeProjectiles
{
    public class CruelSun : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            ProjectileID.Sets.Homing[projectile.type] = true;
        }
        public override void SetDefaults()
        {
            projectile.Name = "CruelSun";
            projectile.width = 380;
            projectile.height = 1428 / Main.projFrames[projectile.type];
            projectile.penetrate = -1;
            projectile.friendly = true;
            projectile.hostile = false;
            projectile.tileCollide = false;
            projectile.timeLeft = 300;
            projectile.ignoreWater = true;
            projectile.melee = true;
            projectile.light = 5;
            Main.projFrames[projectile.type] = 4;
            
        }
        public override void AI()
        {
            projectile.rotation = (float)Math.Atan2((double)projectile.velocity.Y, (double)projectile.velocity.X) + 1.57f;
            int dust = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, DustID.Fire, 0f, 0f, 255, default(Color), 5f);
            Main.dust[dust].noGravity = true;
            int frameSpeed = 4;
            projectile.frameCounter++;
            if (projectile.frameCounter >= frameSpeed)
            {
                projectile.frameCounter = 0;
                projectile.frame++;
                if (projectile.frame >= Main.projFrames[projectile.type])
                {
                    projectile.frame = 0;
                }
            }
        }

        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            target.AddBuff(mod.BuffType("FlamesOfHeaven"), 300);
            target.immune[projectile.owner] = 6;
            Projectile.NewProjectile(target.Center.X, target.Center.Y, 0f, 0f, ProjectileID.SolarWhipSwordExplosion, damage, 10f, projectile.owner, 0f, 0.85f + Main.rand.NextFloat() * 1.15f);
        }
        public override void Kill(int timeLeft)
        {
            Main.PlaySound(SoundID.Item14, projectile.Center);
            for (int i = 0; i < 10; i++)
            {
                int dust = Dust.NewDust(projectile.position, projectile.width,
                    projectile.height, DustID.Fire, 0f, 0f, 100, default(Color), 5f);
                Main.dust[dust].noGravity = true;
                Main.dust[dust].velocity *= 5f;
                dust = Dust.NewDust(projectile.position, projectile.width,
                    projectile.height, DustID.Fire, 0f, 0f, 100, default(Color), 5f);
                Main.dust[dust].velocity *= 5f;
                Main.dust[dust].noGravity = true;
                int dust2 = Dust.NewDust(projectile.position, projectile.width,
               projectile.height, DustID.Fire, 0f, 0f, 100, default(Color), 5f);
                Main.dust[dust2].noGravity = true;
                Main.dust[dust2].velocity *= 5f;
                dust2 = Dust.NewDust(projectile.position, projectile.width,
                    projectile.height, DustID.Fire, 0f, 0f, 100, default(Color), 5f);
                Main.dust[dust2].velocity *= 5f;
                Main.dust[dust2].noGravity = true;

            }
        }
    }
}

