using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.Enums;
using Terraria.ID;
using Terraria.ModLoader;

namespace TheApexMod.NPCs.Bosses
{
	public class Skyron : ModNPC
	{
		public override void SetStaticDefaults()
		{
			Main.npcFrameCount[npc.type] = 4;
		}
		public override void SetDefaults()
		{
			npc.CloneDefaults(NPCID.Sharkron);
			npc.scale = 2;
			npc.noGravity = true;
			npc.width = 120;
			npc.height = 24;
			npc.aiStyle = 71;
			npc.damage = 125;
			npc.defense = 200;
			npc.lifeMax = 350;
			npc.HitSound = SoundID.NPCHit1;
			npc.DeathSound = SoundID.NPCDeath1;
			npc.knockBackResist = 0f;
			npc.alpha = 255;
		}
		public override void ScaleExpertStats(int numPlayers, float bossLifeScale)
		{
			npc.damage = (int)(npc.damage * 1.5);
		}
		public override void AI()
		{
			npc.noTileCollide = true;
			int num1032 = 90;
			if (npc.target < 0 || npc.target == 255 || Main.player[npc.target].dead)
			{
				npc.TargetClosest(faceTarget: false);
				npc.direction = 1;
				npc.netUpdate = true;
			}
			if (npc.ai[0] == 0f)
			{
				npc.ai[1]++;
				_ = npc.type;
				npc.noGravity = true;
				npc.dontTakeDamage = true;
				npc.velocity.Y = npc.ai[3];
				if (npc.ai[1] >= (float)num1032)
				{
					npc.ai[0] = 1f;
					npc.ai[1] = 0f;
					if (!Collision.SolidCollision(npc.position, npc.width, npc.height))
					{
						npc.ai[1] = 1f;
					}
					Main.PlaySound(SoundID.NPCKilled, (int)npc.Center.X, (int)npc.Center.Y, 19);
					npc.TargetClosest();
					npc.spriteDirection = npc.direction;
					Vector2 vector123 = Main.player[npc.target].Center - npc.Center;
					vector123.Normalize();
					npc.velocity = vector123 * 30f;
					npc.rotation = npc.velocity.ToRotation();
					if (npc.direction == -1)
					{
						npc.rotation += (float)Math.PI;
					}
					npc.netUpdate = true;
				}
			}
			else
			{
				if (npc.ai[0] != 1f)
				{
					return;
				}
				npc.noGravity = true;
				if (!Collision.SolidCollision(npc.position, npc.width, npc.height))
				{
					if (npc.ai[1] < 1f)
					{
						npc.ai[1] = 1f;
					}
				}
				else
				{
					npc.alpha -= 15;
					if (npc.alpha < 150)
					{
						npc.alpha = 150;
					}
				}
				if (npc.ai[1] >= 1f)
				{
					npc.alpha -= 60;
					if (npc.alpha < 0)
					{
						npc.alpha = 0;
					}
					npc.dontTakeDamage = false;
					npc.ai[1]++;
					if (Collision.SolidCollision(npc.position, npc.width, npc.height))
					{
						if (npc.DeathSound != null)
						{
							Main.PlaySound(npc.DeathSound, npc.position);
						}
						npc.life = 0;
						npc.HitEffect();
						npc.active = false;
						return;
					}
				}
				if (npc.ai[1] >= 60f)
				{
					npc.noGravity = false;
				}
				npc.rotation = npc.velocity.ToRotation();
				if (npc.direction == -1)
				{
					npc.rotation += (float)Math.PI;
				}
			}
		}
		public override void FindFrame(int frameHeight)
		{
			if (++npc.frameCounter > 3)
			{
				npc.frameCounter = 0;
				npc.frame.Y += frameHeight;
				if (npc.frame.Y >= 4 * frameHeight)
					npc.frame.Y = 0;
			}
		}
	}
}

