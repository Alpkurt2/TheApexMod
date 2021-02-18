using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace TheApexMod.Projectiles.RangedProjectiles
{
    public class ApexArrowTrail : ModProjectile
    {
        public override void SetDefaults()
        {
            projectile.CloneDefaults(ProjectileID.MoonlordArrowTrail);
            projectile.Name = "ApexArrowTrail";
			projectile.width = 10;
			projectile.height = 10;
			projectile.aiStyle = 1;
			projectile.friendly = true;
			projectile.ranged = true;
			projectile.MaxUpdates = 3;
			projectile.timeLeft = 90;
			projectile.ignoreWater = true;
			projectile.usesLocalNPCImmunity = true;
			projectile.alpha = 255;
			projectile.penetrate = 4;
		}
        public override void AI()
        {
			projectile.alpha -= 25;
			if (projectile.alpha < 0)
			{
				projectile.alpha = 0;
			}
			if (projectile.velocity == Vector2.Zero)
			{
				projectile.ai[0] = 0f;
				bool flag = true;
				for (int num82 = 1; num82 < projectile.oldPos.Length; num82++)
				{
					if (projectile.oldPos[num82] != projectile.oldPos[0])
					{
						flag = false;
					}
				}
				if (flag)
				{
					projectile.Kill();
					return;
				}
				if (Main.rand.Next(projectile.extraUpdates) == 0 && (projectile.velocity != Vector2.Zero || Main.rand.Next((projectile.localAI[1] == 2f) ? 2 : 6) == 0))
				{
					for (int num83 = 0; num83 < 2; num83++)
					{
						float num84 = projectile.rotation + ((Main.rand.Next(2) == 1) ? (-1f) : 1f) * ((float)Math.PI / 2f);
						float num85 = (float)Main.rand.NextDouble() * 0.8f + 1f;
						Vector2 vector6 = new Vector2((float)Math.Cos(num84) * num85, (float)Math.Sin(num84) * num85);
						int num86 = Dust.NewDust(projectile.Center, 0, 0, DustID.AncientLight, vector6.X, vector6.Y);
						Main.dust[num86].noGravity = true;
						Main.dust[num86].scale = 1.2f;
					}
					if (Main.rand.Next(10) == 0)
					{
						Vector2 value14 = projectile.velocity.RotatedBy(1.5707963705062866) * ((float)Main.rand.NextDouble() - 0.5f) * projectile.width;
						int num87 = Dust.NewDust(projectile.Center + value14 - Vector2.One * 4f, 8, 8, DustID.AncientLight, 0f, 0f, 100, default(Color), 1.5f);
						Main.dust[num87].velocity *= 0.5f;
						Main.dust[num87].velocity.Y = 0f - Math.Abs(Main.dust[num87].velocity.Y);
					}
				}
			}
			else if (projectile.numUpdates == 1)
			{
				float num88 = projectile.rotation + (float)Math.PI / 2f + ((Main.rand.Next(2) == 1) ? (-1f) : 1f) * ((float)Math.PI / 2f);
				float num89 = (float)Main.rand.NextDouble() * 0.25f + 0.25f;
				Vector2 vector7 = new Vector2((float)Math.Cos(num88) * num89, (float)Math.Sin(num88) * num89);
				int num90 = Dust.NewDust(projectile.position, 0, 0, DustID.AncientLight, vector7.X, vector7.Y);
				Main.dust[num90].noGravity = true;
				Main.dust[num90].scale = 1.2f;
			}
			if (projectile.velocity != Vector2.Zero)
			{
				projectile.rotation = projectile.velocity.ToRotation() + (float)Math.PI / 2f;
			}
		}
        public override bool OnTileCollide(Vector2 oldVelocity)
        {
            if (projectile.localAI[1] < 1f)
            {
                projectile.localAI[1] += 2f;
                projectile.position += projectile.velocity;
                projectile.velocity = Vector2.Zero;
            }
            return false;
        }
		public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
		{
			for (int i = 0; i < 200; i++)
			{
				projectile.localNPCImmunity[i] = -1;
				Main.npc[i].immune[projectile.owner] = 0;
				damage = (int)((double)damage * 0.96);
			}
		}

        public override void Kill(int timeLeft)
        {
            int num271 = Main.rand.Next(5, 10);
            for (int num272 = 0; num272 < num271; num272++)
            {
                int num273 = Dust.NewDust(projectile.Center, 0, 0, DustID.AncientLight, 0f, 0f, 100, default(Color), 0.5f);
                Dust dust98 = Main.dust[num273];
                Dust dust2 = dust98;
                dust2.velocity *= 1.6f;
                Main.dust[num273].velocity.Y -= 1f;
                Main.dust[num273].position = Vector2.Lerp(Main.dust[num273].position, projectile.Center, 0.5f);
                Main.dust[num273].noGravity = true;
            }
        }
    }
}
