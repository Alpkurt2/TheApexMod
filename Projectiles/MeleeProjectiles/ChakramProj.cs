using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace TheApexMod.Projectiles.MeleeProjectiles
{
    public class ChakramProj : ModProjectile
    {
        public override void SetDefaults()
        {
            projectile.Name = "NeoBoomerangProjectile";
            projectile.CloneDefaults(ProjectileID.FruitcakeChakram);
            aiType = ProjectileID.FruitcakeChakram;
            projectile.width = 18;
            projectile.height = 32;
            projectile.penetrate = -1;
        }
        public override void AI()
        {
            if (projectile.ai[0] == 1)
            {
                projectile.localAI[0] += 0.1f;
                projectile.position += projectile.DirectionTo(Main.player[projectile.owner].Center) * projectile.localAI[0];

                if (projectile.Distance(Main.player[projectile.owner].Center) <= projectile.localAI[0])
                    projectile.Kill();
            }
        }
        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            target.immune[projectile.owner] = 6;
        }
    }
}
