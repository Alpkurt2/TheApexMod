using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace TheApexMod.Projectiles.MeleeProjectiles
{
    public class PureWoodSwordProjectile : ModProjectile
    {
        public override void SetDefaults()
        {
            projectile.Name = "PureWoodSwordProjectile";
            projectile.width = 18;
            projectile.height = 26;
            projectile.timeLeft = 180;
            projectile.penetrate = 3;
            projectile.friendly = true;
            projectile.hostile = false;
            projectile.tileCollide = true;
            projectile.ignoreWater = true;
            projectile.melee = true;
        }
        public override void AI()
        {
            projectile.rotation = (float)Math.Atan2((double)projectile.velocity.Y, (double)projectile.velocity.X) + 1.57f;
        }
        public override void Kill(int timeLeft)
        {
            Main.PlaySound(SoundID.Item10, projectile.Center);
            for (int i = 0; i < 10; i++)
            {
                int dust = Dust.NewDust(projectile.position, projectile.width,
                    projectile.height, DustID.Sandstorm, 0f, 0f, 100, default(Color), 3f);
                Main.dust[dust].noGravity = true;
                Main.dust[dust].velocity *= 7f;
                dust = Dust.NewDust(projectile.position, projectile.width,
                    projectile.height, DustID.Sandstorm, 0f, 0f, 100, default(Color), 1f);
                Main.dust[dust].velocity *= 3f;
            }
        }
    }
}