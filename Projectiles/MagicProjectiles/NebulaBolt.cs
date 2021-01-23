using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace TheApexMod.Projectiles.MagicProjectiles
{
    public class NebulaBolt : ModProjectile
    {
        public override void SetDefaults()
        {
            projectile.CloneDefaults(ProjectileID.NebulaLaser);
            projectile.Name = "NebulaBolt";
            projectile.width = 16;
            projectile.height = 16;
            projectile.penetrate = 1;
            projectile.aiStyle = 102;
            projectile.timeLeft = 150;
            projectile.friendly = true;
            projectile.hostile = false;
            projectile.tileCollide = false;
            projectile.ignoreWater = true;
            projectile.magic = true;
            projectile.alpha = 255;
        }
        public override void AI()
        {
            if (Main.rand.Next(1) == 0)
            {
                int num949 = Dust.NewDust(projectile.Center, 8, 8, 242);
                Main.dust[num949].position = projectile.Center;
                Main.dust[num949].velocity = projectile.velocity;
                Main.dust[num949].noGravity = true;
                Main.dust[num949].scale = 1.5f;
            }
            if (Main.rand.Next(2) == 0)
            {
                int num956 = Dust.NewDust(projectile.Center, 8, 8, 242);
                Main.dust[num956].position = projectile.Center;
                Dust dust141 = Main.dust[num956];
                Dust dust2 = dust141;
                dust2.velocity *= 0.2f;
                Main.dust[num956].noGravity = true;
                Main.dust[num956].scale = 1.5f;
            }
        }
        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            target.immune[projectile.owner] = 4;
        }

        public override void Kill(int timeLeft)
        {
            Main.PlaySound(SoundID.Item10, projectile.Center);
        }
    }
}