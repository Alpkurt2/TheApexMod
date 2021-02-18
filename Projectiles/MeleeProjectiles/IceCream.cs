using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace TheApexMod.Projectiles.MeleeProjectiles
{
    public class IceCream : ModProjectile
    {
        public override void SetDefaults()
        {
            projectile.Name = "Ice Cream";
            projectile.penetrate = -1;
            projectile.friendly = true;
            projectile.hostile = false;
            projectile.tileCollide = true;
            projectile.ignoreWater = true;
            projectile.melee = true;
            projectile.aiStyle = 2;
            projectile.scale = 10f;
            projectile.width = 28;
            projectile.height = 32;
        }
        public override void AI()
        {
            if (projectile.soundDelay == 0)
            {
                projectile.soundDelay = 100;
                Main.PlaySound(mod.GetLegacySoundSlot(SoundType.Custom, "Sounds/Items/IceCream"), projectile.position);
            }
        }

        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            target.immune[projectile.owner] = 1;
            Projectile.NewProjectile(target.Center.X, target.Center.Y, 0f, 0f, ProjectileID.SolarWhipSwordExplosion, damage, 10f, projectile.owner, 0f, 0.85f + Main.rand.NextFloat() * 1.15f);
        }
        public override void Kill(int timeLeft)
        {
            Main.PlaySound(SoundID.Item27, projectile.Center);
            for (int i = 0; i < 15; i++)
            {
                int dust = Dust.NewDust(projectile.position, projectile.width, projectile.height, 13, 0f, 0f, 100, default(Color), 3f);
                Main.dust[dust].noGravity = true;
                Main.dust[dust].velocity *= 1.5f;
            }
            if (projectile.owner == Main.myPlayer)
            {
                for (int i = 0; i < 8; i++)
                    Projectile.NewProjectile(projectile.Center, Vector2.Normalize(projectile.velocity).RotatedBy(Math.PI / 4 * i) * Main.rand.NextFloat(12f, 20f), mod.ProjectileType("GlassShard"), projectile.damage / 2, projectile.knockBack, projectile.owner, 0, Main.rand.Next(11) + 1);
            }
        }
    }
}


