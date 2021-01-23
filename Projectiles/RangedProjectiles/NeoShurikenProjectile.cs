using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace TheApexMod.Projectiles.RangedProjectiles
{
    public class NeoShurikenProjectile : ModProjectile
    {
        public override void SetDefaults()
        {
            projectile.Name = "NeoShurikenProjectile";
            projectile.width = 18;
            projectile.height = 26;
            projectile.penetrate = 7;
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
                Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, DustID.Fire);
            Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, 135);
            Lighting.AddLight(projectile.position, 0f, 0.255f, 0.255f);
            Lighting.AddLight(projectile.position, 0.255f, 0.165f, 0f);


        }
        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            target.AddBuff(BuffID.Frostburn, 300);
            target.AddBuff(BuffID.OnFire, 300);
        }
        public override void Kill(int timeLeft)
        {
            Main.PlaySound(SoundID.Item10, projectile.Center);

            for (int i = 0; i < 10; i++)
            {
                int dust = Dust.NewDust(projectile.position, projectile.width,
                    projectile.height, DustID.Fire, 0f, 0f, 100, default(Color), 3f);
                Main.dust[dust].noGravity = true;
                Main.dust[dust].velocity *= 4f;
                dust = Dust.NewDust(projectile.position, projectile.width,
                    projectile.height, 15, 0f, 0f, 100, default(Color), 1f);
                Main.dust[dust].velocity *= 2f;
            }
        }
    }
}