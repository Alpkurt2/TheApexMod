using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace TheApexMod.Projectiles.RangedProjectiles
{
    public class FrostburnShurikenProjectile : ModProjectile
    {
        public override void SetDefaults()
        {
            projectile.Name = "FrostburnShurikenProjectile";
            projectile.width = 18;
            projectile.height = 26;
            projectile.penetrate = 5;
            projectile.friendly = true;
            projectile.hostile = false;
            projectile.tileCollide = true;
            projectile.ignoreWater = true;
            projectile.aiStyle = 2;
            projectile.ranged = true;
            projectile.rotation = 6f;
        }
        public override void AI()
        {
            if (Main.rand.Next(3) == 0)
                Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, 15);
            Lighting.AddLight(projectile.position, 0f, 0.255f, 0.255f);


    }
        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            target.AddBuff(BuffID.Frostburn, 300);
        }
        public override void Kill(int timeLeft)
        {
            Main.PlaySound(SoundID.Item10, projectile.Center);

            for (int i = 0; i < 5; i++)
            {
                int dust = Dust.NewDust(projectile.position, projectile.width,
                    projectile.height, 15, 0f, 0f, 100, default(Color), 3f);
                Main.dust[dust].noGravity = false;
                Main.dust[dust].velocity *= 2f;
            }
        }
    }
}