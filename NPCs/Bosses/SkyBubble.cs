using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.Enums;
using Terraria.ID;
using Terraria.ModLoader;

namespace TheApexMod.NPCs.Bosses
{
	public class SkyBubble : ModNPC
	{

		public override void SetDefaults()
		{
			npc.width = 36;
			npc.height = 36;
			npc.aiStyle = -1;
			npc.damage = 220;
			npc.defense = 0;
			npc.lifeMax = 1;
			npc.HitSound = SoundID.NPCHit3;
			npc.DeathSound = SoundID.NPCDeath3;
			npc.noGravity = true;
			npc.noTileCollide = true;
			npc.knockBackResist = 0f;
			npc.alpha = 255;
		}
		public override void ScaleExpertStats(int numPlayers, float bossLifeScale)
		{
			npc.damage = (int)(npc.damage * 1.5);
		}
		public override void AI()
        {
			if (npc.target == 255)
			{
				npc.TargetClosest();
				npc.ai[3] = (float)Main.rand.Next(80, 121) / 100f;
				float scaleFactor = (float)Main.rand.Next(165, 265) / 15f;
				npc.velocity = Vector2.Normalize(Main.player[npc.target].Center - npc.Center + new Vector2(Main.rand.Next(-100, 101), Main.rand.Next(-100, 101))) * scaleFactor;
				npc.netUpdate = true;
			}
			Vector2 vector122 = Vector2.Normalize(Main.player[npc.target].Center - npc.Center);
			npc.velocity = (npc.velocity * 42f + vector122 * 20f) / 41f;
			npc.scale = npc.ai[3];
			npc.alpha -= 30;
			if (npc.alpha < 50)
			{
				npc.alpha = 50;
			}
			npc.alpha = 50;
			npc.velocity.X = (npc.velocity.X * 52f + Main.windSpeed * 2f + (float)Main.rand.Next(-10, 11) * 0.1f) / 51f;
			npc.velocity.Y = (npc.velocity.Y * 52f + -0.25f + (float)Main.rand.Next(-10, 11) * 0.2f) / 51f;
			if (npc.velocity.Y > 0f)
			{
				npc.velocity.Y -= 0.04f;
			}
			if (npc.ai[0] == 0f)
			{
				int num1030 = 40;
				Rectangle rect = npc.getRect();
				rect.X -= num1030 + npc.width / 2;
				rect.Y -= num1030 + npc.height / 2;
				rect.Width += num1030 * 2;
				rect.Height += num1030 * 2;
				for (int num1031 = 0; num1031 < 255; num1031++)
				{
					Player player2 = Main.player[num1031];
					if (player2.active && !player2.dead && rect.Intersects(player2.getRect()))
					{
						npc.ai[0] = 1f;
						npc.ai[1] = 4f;
						npc.netUpdate = true;
						break;
					}
				}
			}
			if (npc.ai[0] == 0f)
			{
				npc.ai[1]++;
				if (npc.ai[1] >= 150f)
				{
					npc.ai[0] = 1f;
					npc.ai[1] = 4f;
				}
			}
			if (npc.ai[0] == 1f)
			{
				npc.ai[1]--;
				if (npc.ai[1] <= 0f)
				{
					npc.life = 0;
					npc.HitEffect();
					npc.active = false;
					return;
				}
			}
			if (npc.justHit || npc.ai[0] == 1f)
			{
				npc.dontTakeDamage = true;
				npc.position = npc.Center;
				npc.width = (npc.height = 100);
				npc.position = new Vector2(npc.position.X - (float)(npc.width / 2), npc.position.Y - (float)(npc.height / 2));
				if (npc.timeLeft > 3)
				{
					npc.timeLeft = 3;
				}
			}
		}
		public override void HitEffect(int hitDirection, double damage)
        {
			Main.PlaySound(SoundID.NPCKilled, (int)npc.position.X, (int)npc.position.Y, 3);
			if (npc.life <= 0)
			{
				_ = npc.Center;
				for (int num206 = 0; num206 < 60; num206++)
				{
					int num207 = 25;
					_ = ((float)Main.rand.NextDouble() * ((float)Math.PI * 2f)).ToRotationVector2() * Main.rand.Next(24, 41) / 8f;
					int num208 = Dust.NewDust(npc.Center - Vector2.One * num207, num207 * 2, num207 * 2, DustID.AncientLight);
					Dust dust100 = Main.dust[num208];
					Vector2 vector7 = Vector2.Normalize(dust100.position - npc.Center);
					dust100.position = npc.Center + vector7 * 25f * npc.scale;
					if (num206 < 30)
					{
						dust100.velocity = vector7 * dust100.velocity.Length();
					}
					else
					{
						dust100.velocity = vector7 * Main.rand.Next(45, 91) / 10f;
					}
					dust100.color = Main.hslToRgb((float)(0.40000000596046448 + Main.rand.NextDouble() * 0.20000000298023224), 0.9f, 0.5f);
					dust100.color = Color.Lerp(dust100.color, Color.White, 0.3f);
					dust100.noGravity = true;
					dust100.scale = 0.7f;
				}
			}
		}
    }
}

