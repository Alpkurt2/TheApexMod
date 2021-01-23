using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace TheApexMod.Projectiles.RangedProjectiles
{
    public class VBRocket : ModProjectile
    {
        public override void SetDefaults()
        {
            projectile.Name = "Vortex Launcher";
            projectile.width = 18;
            projectile.height = 26;
            projectile.timeLeft = 150;
            projectile.friendly = true;
            projectile.hostile = false;
            projectile.tileCollide = true;
            projectile.ignoreWater = true;
            projectile.ranged = true;
            projectile.light = 2;

        }
		public override void AI()
		{
			projectile.rotation = (float)Math.Atan2((double)projectile.velocity.Y, (double)projectile.velocity.X) + 1.57f;
			float num199 = 3f;
			for (int num200 = 0; (float)num200 < num199; num200++)
			{
				int num201 = Dust.NewDust(projectile.position, 1, 1, 229);
				Main.dust[num201].position = projectile.Center - projectile.velocity / num199 * num200;
				Main.dust[num201].velocity *= 0f;
				Main.dust[num201].noGravity = true;
				Main.dust[num201].alpha = 200;
				Main.dust[num201].scale = 0.5f;
			}
			float num202 = (float)Math.Sqrt(projectile.velocity.X * projectile.velocity.X + projectile.velocity.Y * projectile.velocity.Y);
			float num203 = projectile.localAI[0];
			if (num203 == 0f)
			{
				projectile.localAI[0] = num202;
				num203 = num202;
			}
			if (projectile.alpha > 0)
			{
				projectile.alpha -= 25;
			}
			if (projectile.alpha < 0)
			{
				projectile.alpha = 0;
			}
			float num204 = projectile.position.X;
			float num205 = projectile.position.Y;
			float num206 = 800f;
			bool flag5 = false;
			int num207 = 0;
			projectile.ai[0] += 1f;
			if (projectile.ai[0] > 20f)
			{
				projectile.ai[0] -= 1f;
				if (projectile.ai[1] == 0f)
				{
					for (int num208 = 0; num208 < 200; num208++)
					{
						if (Main.npc[num208].CanBeChasedBy(this) && (projectile.ai[1] == 0f || projectile.ai[1] == (float)(num208 + 1)))
						{
							float num209 = Main.npc[num208].position.X + (float)(Main.npc[num208].width / 2);
							float num210 = Main.npc[num208].position.Y + (float)(Main.npc[num208].height / 2);
							float num211 = Math.Abs(projectile.position.X + (float)(projectile.width / 2) - num209) + Math.Abs(projectile.position.Y + (float)(projectile.height / 2) - num210);
							if (num211 < num206 && Collision.CanHit(new Vector2(projectile.position.X + (float)(projectile.width / 2), projectile.position.Y + (float)(projectile.height / 2)), 1, 1, Main.npc[num208].position, Main.npc[num208].width, Main.npc[num208].height))
							{
								num206 = num211;
								num204 = num209;
								num205 = num210;
								flag5 = true;
								num207 = num208;
							}
						}
					}
					if (flag5)
					{
						projectile.ai[1] = num207 + 1;
					}
					flag5 = false;
				}
				if (projectile.ai[1] != 0f)
				{
					int num212 = (int)(projectile.ai[1] - 1f);
					if (Main.npc[num212].active && Main.npc[num212].CanBeChasedBy(this, ignoreDontTakeDamage: true))
					{
						float num213 = Main.npc[num212].position.X + (float)(Main.npc[num212].width / 2);
						float num214 = Main.npc[num212].position.Y + (float)(Main.npc[num212].height / 2);
						if (Math.Abs(projectile.position.X + (float)(projectile.width / 2) - num213) + Math.Abs(projectile.position.Y + (float)(projectile.height / 2) - num214) < 1000f)
						{
							flag5 = true;
							num204 = Main.npc[num212].position.X + (float)(Main.npc[num212].width / 2);
							num205 = Main.npc[num212].position.Y + (float)(Main.npc[num212].height / 2);
						}
					}
				}
				if (!projectile.friendly)
				{
					flag5 = false;
				}
				if (flag5)
				{
					float num215 = num203;
					Vector2 vector11 = new Vector2(projectile.position.X + (float)projectile.width * 0.5f, projectile.position.Y + (float)projectile.height * 0.5f);
					float num216 = num204 - vector11.X;
					float num217 = num205 - vector11.Y;
					float num218 = (float)Math.Sqrt(num216 * num216 + num217 * num217);
					num218 = num215 / num218;
					num216 *= num218;
					num217 *= num218;
					int num219 = 8;
					projectile.velocity.X = (projectile.velocity.X * (float)(num219 - 1) + num216) / (float)num219;
					projectile.velocity.Y = (projectile.velocity.Y * (float)(num219 - 1) + num217) / (float)num219;
				}
			}
		}



		public override void Kill(int timeLeft)
        {
            Main.PlaySound(SoundID.Item14, projectile.position);
            projectile.position = projectile.Center;
            projectile.width = (projectile.height = 80);
            projectile.position.X -= projectile.width / 2;
            projectile.position.Y -= projectile.height / 2;
            for (int num312 = 0; num312 < 4; num312++)
            {
                Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, 31, 0f, 0f, 100, default(Color), 1.5f);
            }
            for (int num313 = 0; num313 < 40; num313++)
            {
                int num314 = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, 229, 0f, 0f, 200, default(Color), 2.5f);
                Main.dust[num314].noGravity = true;
                Dust dust111 = Main.dust[num314];
                Dust dust2 = dust111;
                dust2.velocity *= 2f;
                num314 = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, 229, 0f, 0f, 200, default(Color), 1.5f);
                dust111 = Main.dust[num314];
                dust2 = dust111;
                dust2.velocity *= 1.2f;
                Main.dust[num314].noGravity = true;
            }
            for (int num315 = 0; num315 < 1; num315++)
            {
                int num316 = Gore.NewGore(projectile.position + new Vector2((float)(projectile.width * Main.rand.Next(100)) / 100f, (float)(projectile.height * Main.rand.Next(100)) / 100f) - Vector2.One * 10f, default(Vector2), Main.rand.Next(61, 64));
                Gore gore16 = Main.gore[num316];
                Gore gore2 = gore16;
                gore2.velocity *= 0.3f;
                Main.gore[num316].velocity.X += (float)Main.rand.Next(-10, 11) * 0.05f;
                Main.gore[num316].velocity.Y += (float)Main.rand.Next(-10, 11) * 0.05f;
            }
        }
    }
}
