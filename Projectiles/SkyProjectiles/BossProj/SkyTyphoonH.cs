using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace TheApexMod.Projectiles.SkyProjectiles.BossProj
{
	public class SkyTyphoonH : ModProjectile
	{
		public override void SetStaticDefaults()
        {
			Main.projFrames[projectile.type] = 3;
		}
		public override void SetDefaults()
		{
			projectile.CloneDefaults(ProjectileID.SharknadoBolt);
			projectile.aiStyle = -1;
			projectile.width = 30;
			projectile.height = 30;
			projectile.hostile = true;
			projectile.penetrate = -1;
			projectile.alpha = 255;
			projectile.timeLeft = 300;
		}
		public override void AI()
		{
			if (projectile.ai[1] > 0f)
			{
				int num629 = (int)projectile.ai[1] - 1;
				if (num629 < 255)
				{
					projectile.localAI[0]++;
					if (projectile.localAI[0] > 10f)
					{
						int num630 = 6;
						for (int num631 = 0; num631 < num630; num631++)
						{
							Vector2 spinningpoint = Vector2.Normalize(projectile.velocity) * new Vector2((float)projectile.width / 2f, projectile.height) * 0.75f;
							spinningpoint = spinningpoint.RotatedBy((double)(num631 - (num630 / 2 - 1)) * Math.PI / (double)(float)num630) + projectile.Center;
							Vector2 value14 = ((float)(Main.rand.NextDouble() * 3.1415927410125732) - (float)Math.PI / 2f).ToRotationVector2() * Main.rand.Next(3, 8);
							int num632 = Dust.NewDust(spinningpoint + value14, 0, 0, DustID.AncientLight, value14.X * 2f, value14.Y * 2f, 100, default(Color), 1.4f);
							Main.dust[num632].noGravity = true;
							Main.dust[num632].noLight = true;
							Dust dust98 = Main.dust[num632];
							Dust dust2 = dust98;
							dust2.velocity /= 4f;
							dust98 = Main.dust[num632];
							dust2 = dust98;
							dust2.velocity -= projectile.velocity;
						}
						projectile.alpha -= 5;
						if (projectile.alpha < 100)
						{
							projectile.alpha = 100;
						}
						projectile.rotation += projectile.velocity.X * 0.1f;
						projectile.frame = (int)(projectile.localAI[0] / 3f) % 3;
					}
					Vector2 value15 = Main.player[num629].Center - projectile.Center;
					float num633 = 6f;
					num633 += projectile.localAI[0] / 20f;
					projectile.velocity = Vector2.Normalize(value15) * num633;
					if (value15.Length() < 50f)
					{
						projectile.Kill();
					}
				}
			}
			else
			{
				float num634 = (float)Math.PI / 15f;
				float num635 = 4f;
				float num636 = (float)(Math.Cos(num634 * projectile.ai[0]) - 0.5) * num635;
				projectile.velocity.Y -= num636;
				projectile.ai[0]++;
				num636 = (float)(Math.Cos(num634 * projectile.ai[0]) - 0.5) * num635;
				projectile.velocity.Y += num636;
				projectile.localAI[0]++;
				if (projectile.localAI[0] > 10f)
				{
					projectile.alpha -= 5;
					if (projectile.alpha < 100)
					{
						projectile.alpha = 100;
					}
					projectile.rotation += projectile.velocity.X * 0.1f;
					projectile.frame = (int)(projectile.localAI[0] / 3f) % 3;
				}
			}
			if (projectile.wet)
			{
				projectile.position.Y -= 16f;
				projectile.Kill();
			}
		}
	
        public override void Kill(int timeLeft)
		{
			Main.PlaySound(SoundID.NPCKilled, (int)projectile.Center.X, (int)projectile.Center.Y, 19);
			int num325 = 36;
			for (int num326 = 0; num326 < num325; num326++)
			{
				Vector2 spinningpoint2 = Vector2.Normalize(projectile.velocity) * new Vector2((float)projectile.width / 2f, projectile.height) * 0.75f;
				spinningpoint2 = spinningpoint2.RotatedBy((float)(num326 - (num325 / 2 - 1)) * ((float)Math.PI * 2f) / (float)num325) + projectile.Center;
				Vector2 vector14 = spinningpoint2 - projectile.Center;
				int num327 = Dust.NewDust(spinningpoint2 + vector14, 0, 0, DustID.AncientLight, vector14.X * 2f, vector14.Y * 2f, 100, default(Color), 1.4f);
				Main.dust[num327].noGravity = true;
				Main.dust[num327].noLight = true;
				Main.dust[num327].velocity = vector14;
			}
			if (projectile.owner == Main.myPlayer)
			{
				if (projectile.ai[1] < 1f)
				{
					int num328 = (Main.expertMode ? 25 : 40);
					int num329 = Projectile.NewProjectile(projectile.Center.X - (float)(projectile.direction * 30), projectile.Center.Y - 4f, (float)(-projectile.direction) * 0.01f, 0f, ModContent.ProjectileType<Skynado>(), num328, 4f, projectile.owner, 16f, 15f);
					Main.projectile[num329].netUpdate = true;
				}
				else
				{
					int num330 = (int)(projectile.Center.Y / 16f);
					int num331 = (int)(projectile.Center.X / 16f);
					int num332 = 100;
					if (num331 < 10)
					{
						num331 = 10;
					}
					if (num331 > Main.maxTilesX - 10)
					{
						num331 = Main.maxTilesX - 10;
					}
					if (num330 < 10)
					{
						num330 = 10;
					}
					if (num330 > Main.maxTilesY - num332 - 10)
					{
						num330 = Main.maxTilesY - num332 - 10;
					}
					for (int num333 = num330; num333 < num330 + num332; num333++)
					{
						Tile tile = Main.tile[num331, num333];
						if (tile.active() && (Main.tileSolid[tile.type] || tile.liquid != 0))
						{
							num330 = num333;
							break;
						}
					}
					int num334 = (Main.expertMode ? 50 : 80);
					int num335 = Projectile.NewProjectile(num331 * 16 + 8, num330 * 16 - 24, 0f, 0f, ModContent.ProjectileType<SkynadoS>(), num334, 4f, Main.myPlayer, 16f, 24f);
					Main.projectile[num335].netUpdate = true;
				}
			}
		}
	}
}



