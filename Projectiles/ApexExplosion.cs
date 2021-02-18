using System;
using System.Security.Policy;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

using Terraria;
using Terraria.Graphics.Shaders;
using Terraria.ID;
using Terraria.ModLoader;

namespace TheApexMod.Projectiles
{
    public class ApexExplosion : ModProjectile
    {
        public override void SetDefaults()
        {
            projectile.CloneDefaults(ProjectileID.SolarWhipSwordExplosion);
            projectile.Name = "ApexExplosion";
            Main.projFrames[projectile.type] = 5;

        }
		public override void AI()
		{
			projectile.ai[1] += 0.01f;
			projectile.scale = projectile.ai[1];
			projectile.ai[0]++;
			if (projectile.ai[0] >= (float)(3 * Main.projFrames[projectile.type]))
			{
				projectile.Kill();
				return;
			}
			if (++projectile.frameCounter >= 3)
			{
				projectile.frameCounter = 0;
				if (++projectile.frame >= Main.projFrames[projectile.type])
				{
					projectile.hide = true;
				}
			}
			projectile.alpha -= 63;
			if (projectile.alpha < 0)
			{
				projectile.alpha = 0;
			}
			Lighting.AddLight(projectile.Center, 0.855f, 0.855f, 0.855f);
			if (projectile.ai[0] != 1f)
			{
				return;
			}
			projectile.position = projectile.Center;
			projectile.width = (projectile.height = (int)(52f * projectile.scale));
			projectile.Center = projectile.position;
			projectile.Damage();
			Main.PlaySound(SoundID.Item14, projectile.position);
			for (int num1006 = 0; num1006 < 4; num1006++)
			{
				int num1007 = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, 31, 0f, 0f, 100, default(Color), 1.5f);
				Main.dust[num1007].position = projectile.Center + Vector2.UnitY.RotatedByRandom(3.1415927410125732) * (float)Main.rand.NextDouble() * projectile.width / 2f;
			}
			for (int num1008 = 0; num1008 < 10; num1008++)
			{
				int num1009 = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, DustID.AncientLight, 0f, 0f, 200, default(Color), 2.7f);
				Main.dust[num1009].position = projectile.Center + Vector2.UnitY.RotatedByRandom(3.1415927410125732) * (float)Main.rand.NextDouble() * projectile.width / 2f;
				Main.dust[num1009].noGravity = true;
				Dust dust161 = Main.dust[num1009];
				Dust dust2 = dust161;
				dust2.velocity *= 3f;
				num1009 = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, DustID.AncientLight, 0f, 0f, 100, default(Color), 1.5f);
				Main.dust[num1009].position = projectile.Center + Vector2.UnitY.RotatedByRandom(3.1415927410125732) * (float)Main.rand.NextDouble() * projectile.width / 2f;
				dust161 = Main.dust[num1009];
				dust2 = dust161;
				dust2.velocity *= 2f;
				Main.dust[num1009].noGravity = true;
				Main.dust[num1009].fadeIn = 2.5f;
			}
			for (int num1010 = 0; num1010 < 5; num1010++)
			{
				int num1011 = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, DustID.AncientLight, 0f, 0f, 0, default(Color), 2.7f);
				Main.dust[num1011].position = projectile.Center + Vector2.UnitX.RotatedByRandom(3.1415927410125732).RotatedBy(projectile.velocity.ToRotation()) * projectile.width / 2f;
				Main.dust[num1011].noGravity = true;
				Dust dust162 = Main.dust[num1011];
				Dust dust2 = dust162;
				dust2.velocity *= 3f;
			}
			for (int num1012 = 0; num1012 < 10; num1012++)
			{
				int num1013 = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, 31, 0f, 0f, 0, default(Color), 1.5f);
				Main.dust[num1013].position = projectile.Center + Vector2.UnitX.RotatedByRandom(3.1415927410125732).RotatedBy(projectile.velocity.ToRotation()) * projectile.width / 2f;
				Main.dust[num1013].noGravity = true;
				Dust dust163 = Main.dust[num1013];
				Dust dust2 = dust163;
				dust2.velocity *= 3f;
			}
			Main.PlaySound(SoundID.Item14, projectile.position);
			float num1018 = (float)Main.rand.NextDouble() * ((float)Math.PI * 2f);
			float num1019 = (float)Main.rand.NextDouble() * ((float)Math.PI * 2f);
			float num1020 = (float)Main.rand.NextDouble() * ((float)Math.PI * 2f);
			float num1021 = 7f + (float)Main.rand.NextDouble() * 7f;
			float num1022 = 7f + (float)Main.rand.NextDouble() * 7f;
			float num1023 = 7f + (float)Main.rand.NextDouble() * 7f;
			float num1024 = num1021;
			if (num1022 > num1024)
			{
				num1024 = num1022;
			}
			if (num1023 > num1024)
			{
				num1024 = num1023;
			}
			for (int num1025 = 0; num1025 < 200; num1025++)
			{
				int num1026 = 135;
				float num1027 = num1024;
				if (num1025 > 50)
				{
					num1027 = num1022;
				}
				if (num1025 > 100)
				{
					num1027 = num1021;
				}
				if (num1025 > 150)
				{
					num1027 = num1023;
				}
				int num1028 = Dust.NewDust(projectile.position, 6, 6, num1026, 0f, 0f, 100);
				Vector2 vector99 = Main.dust[num1028].velocity;
				Main.dust[num1028].position = projectile.Center;
				vector99.Normalize();
				vector99 *= num1027;
				if (num1025 > 150)
				{
					vector99.Y *= 0.5f;
					vector99 = vector99.RotatedBy(num1020);
				}
				else if (num1025 > 100)
				{
					vector99.X *= 0.5f;
					vector99 = vector99.RotatedBy(num1018);
				}
				else if (num1025 > 50)
				{
					vector99.Y *= 0.5f;
					vector99 = vector99.RotatedBy(num1019);
				}
				Dust dust166 = Main.dust[num1028];
				Dust dust2 = dust166;
				dust2.velocity *= 0.2f;
				dust166 = Main.dust[num1028];
				dust2 = dust166;
				dust2.velocity += vector99;
				Main.dust[num1028].shader = GameShaders.Armor.GetSecondaryShader(Main.player[projectile.owner].cPet, Main.player[projectile.owner]);
				if (num1025 <= 200)
				{
					Main.dust[num1028].scale = 2f;
					Main.dust[num1028].noGravity = true;
					Main.dust[num1028].fadeIn = Main.rand.NextFloat() * 2f;
					if (Main.rand.Next(4) == 0)
					{
						Main.dust[num1028].fadeIn = 2.5f;
					}
					Main.dust[num1028].noLight = true;
					if (num1025 < 100)
					{
						dust166 = Main.dust[num1028];
						dust2 = dust166;
						dust2.position += Main.dust[num1028].velocity * 20f;
						dust166 = Main.dust[num1028];
						dust2 = dust166;
						dust2.velocity *= -1f;
					}
				}
			}
		}
        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            target.AddBuff(mod.BuffType("WhiteFlames"), 120);
        }
        public override void Kill(int timeLeft)
        {
        }
    }
}
