using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace TheApexMod.Projectiles.MeleeProjectiles
{
    public class GlassShard : ModProjectile
    {
        public override void SetDefaults()
        {
            projectile.Name = "GlassShard";
            projectile.penetrate = -1;
            projectile.friendly = true;
            projectile.hostile = false;
            projectile.tileCollide = true;
            projectile.ignoreWater = true;
            projectile.melee = true;
            projectile.scale = 5f;
            projectile.aiStyle = 2;
            projectile.width = 22;
            projectile.height = 12;

        }
        public override void AI()
        {

        }
        public override void Kill(int timeLeft)
        {
            Main.PlaySound(SoundID.Item27, projectile.Center);
            for (int i = 0; i < 5; i++)
            {
                int dust = Dust.NewDust(projectile.position, projectile.width, projectile.height, 13, 0f, 0f, 100, default(Color), 3f);
                Main.dust[dust].noGravity = true;
                Main.dust[dust].velocity *= 1.5f;
            }
        }
    }
}

