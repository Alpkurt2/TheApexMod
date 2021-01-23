using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

using System.Collections.Generic;

namespace TheApexMod.Projectiles.SummonerProjectiles
{
    public class GImpFireball : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            ProjectileID.Sets.Homing[projectile.type] = true;
            ProjectileID.Sets.MinionShot[projectile.type] = true;
        }
        public override void SetDefaults()
        {
            projectile.Name = "Galaxy Imp Fireball";
            projectile.width = 12;
            projectile.height = 12;
            projectile.aiStyle = 0;
            projectile.friendly = true;
            projectile.penetrate = -1;
            projectile.tileCollide = true;
            projectile.timeLeft = 100;
            projectile.alpha = 255;
            projectile.extraUpdates = 1;

        }
        public override void AI()
        {
            if (projectile.localAI[0] == 0f)
            {
                Main.PlaySound(SoundID.Item20, projectile.position);
            }
            projectile.localAI[0] += 1f;
            if (projectile.localAI[0] > 3f)
            {
                int num94 = 1;
                if (projectile.localAI[0] > 5f)
                {
                    num94 = 2;
                }
                for (int num95 = 0; num95 < num94; num95++)
                {
                    int num96 = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y + 2f), projectile.width, projectile.height, 65, projectile.velocity.X * 0.2f, projectile.velocity.Y * 0.2f, 100, default(Color), 2f);
                    Main.dust[num96].noGravity = true;
                    Main.dust[num96].velocity.X *= 0.3f;
                    Main.dust[num96].velocity.Y *= 0.3f;
                    Main.dust[num96].noLight = true;
                }
                if (projectile.wet && !projectile.lavaWet)
                {
                    projectile.Kill();
                    return;
                }
            }
        }
        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            target.AddBuff(BuffID.ShadowFlame, 300);
        }
    }
}
