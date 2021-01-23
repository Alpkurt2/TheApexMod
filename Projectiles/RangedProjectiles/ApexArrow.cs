﻿using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace TheApexMod.Projectiles.RangedProjectiles
{
    public class ApexArrow : ModProjectile
    {
        public override void SetDefaults()
        {
            projectile.Name = "ApexArrow";
            projectile.width = 18;
            projectile.height = 26;
            projectile.aiStyle = 1;
            projectile.penetrate = 3;
            projectile.friendly = true;
            projectile.hostile = false;
            projectile.tileCollide = true;
            projectile.ignoreWater = true;
            projectile.ranged = true;
            projectile.light = 2;
            projectile.arrow = true;


        }
        public override void AI()
        {
            projectile.rotation = (float)Math.Atan2((double)projectile.velocity.Y, (double)projectile.velocity.X) + 1.57f;
            if (Main.rand.Next(3) == 0)
                Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, DustID.AncientLight);

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
            for (int i = 0; i < 10; i++)
            {
                int dust = Dust.NewDust(projectile.position, projectile.width,
                    projectile.height, DustID.AncientLight, 0f, 0f, 100, default(Color), 3f);
                Main.dust[dust].noGravity = true;
                Main.dust[dust].velocity *= 7f;
                dust = Dust.NewDust(projectile.position, projectile.width,
                    projectile.height, DustID.AncientLight, 0f, 0f, 100, default(Color), 1f);
                Main.dust[dust].velocity *= 3f;
            }
        }




    }
}
