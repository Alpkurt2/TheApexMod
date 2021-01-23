using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

using System.Collections.Generic;

namespace TheApexMod.Projectiles.MeleeProjectiles
{
    public class IceEP : ModProjectile
    {
        public override void SetDefaults()
        {
            projectile.Name = "Icy Edge";
            projectile.width = 16;
            projectile.height = 16;
            projectile.penetrate = 3;
            projectile.timeLeft = 250;
            projectile.aiStyle = 29;
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
            for (int num506 = 0; num506 < 7; num506++)
            {
                int num507 = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, 135, projectile.oldVelocity.X, projectile.oldVelocity.Y, 50, default(Color), 2f);
                Main.dust[num507].noGravity = true;
                Dust dust157 = Main.dust[num507];
                Dust dust2 = dust157;
                dust2.scale *= 1.25f;
                dust157 = Main.dust[num507];
                dust2 = dust157;
                dust2.velocity *= 0.5f;
            }
            Lighting.AddLight(projectile.position, 0f, 0.255f, 0.255f);
        }
        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            target.AddBuff(BuffID.Frostburn, 300);
        }

        public override void Kill(int timeLeft)
        {
            Main.PlaySound(SoundID.Item27, projectile.Center);

            for (int i = 0; i < 10; i++)
            {
                int dust = Dust.NewDust(projectile.position, projectile.width,
                    projectile.height, 135, 0f, 0f, 100, default(Color), 3f);
                Main.dust[dust].noGravity = true;
                Main.dust[dust].velocity *= 7f;
            }
        }
    }
}
