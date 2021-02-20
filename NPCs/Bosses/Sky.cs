using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.Enums;
using Terraria.ID;
using Terraria.ModLoader;
using TheApexMod.Items.Materials;
using TheApexMod.Items.Placeable;
using TheApexMod.Items.Weapons.Magic;
using TheApexMod.Items.Weapons.Melee;
using TheApexMod.Items.Weapons.Ranged;
using TheApexMod.Projectiles.MeleeProjectiles;
using TheApexMod.Projectiles.SkyProjectiles;

namespace TheApexMod.NPCs.Bosses
{
	[AutoloadBossHead]
	public class Sky : ModNPC
	{
		public override void SetStaticDefaults()
		{
			Main.npcFrameCount[npc.type] = 5;
		}

		public override void SetDefaults()
		{
			npc.boss = true;
			npc.width = 60;
			npc.height = 64;
			npc.damage = 120;
			npc.defense = 80;
			npc.lifeMax = 150000;
			npc.HitSound = SoundID.NPCHit3;
			npc.DeathSound = SoundID.NPCDeath3;
			npc.netAlways = true;
			npc.value = Item.buyPrice(1);
			npc.knockBackResist = 0f;
			npc.aiStyle = -1;
			npc.lavaImmune = true;
			npc.noTileCollide = true;
			music = ModLoader.GetMod("TheApexMod").GetSoundSlot(SoundType.Music, "Sounds/Music/StarRain");
			musicPriority = (MusicPriority)10;
			npc.buffImmune[31] = true;
			bossBag = ModContent.ItemType<Items.Misc.SkyBag>();

		}
		public override void ScaleExpertStats(int numPlayers, float bossLifeScale)
		{
			npc.lifeMax = (int)(npc.lifeMax * bossLifeScale);
			npc.damage = (int)(npc.damage * 1.3);
		}
		public override void AI()
		{
			bool expertMode = Main.expertMode;
			float num = (expertMode ? (0.6f * Main.damageMultiplier) : 1f);
			bool flag = npc.life <= npc.lifeMax * 0.5;
			bool flag2 = expertMode && npc.life <= npc.lifeMax * 0.15;
			bool flag3 = npc.ai[0] > 4f;
			bool flag4 = npc.ai[0] > 9f;
			bool flag5 = npc.ai[3] < 10f;
			if (flag4)
			{
				npc.damage = (int)((float)npc.defDamage * 1.1f * num);
				npc.defense = 0;
			}
			else if (flag3)
			{
				npc.damage = (int)((float)npc.defDamage * 1.2f * num);
				npc.defense = (int)((float)npc.defDefense * 0.8f);
			}
			else
			{
				npc.damage = npc.defDamage;
				npc.defense = npc.defDefense;
			}
			int num2 = (expertMode ? 3 : 6);
			float num3 = (expertMode ? 0.275f : 0.225f);
			float scaleFactor = (expertMode ? 8.5f : 7.5f);
			if (flag4)
			{
				num3 = 0.7f;
				scaleFactor = 12f;
				num2 = 2;
			}
			else if (flag3 && flag5)
			{
				num3 = (expertMode ? 0.6f : 0.5f);
				scaleFactor = (expertMode ? 10f : 8f);
				num2 = (expertMode ? 3 : 1);
			}
			else if (flag5 && !flag3 && !flag4)
			{
				num2 = 2;
			}
			int num4 = (expertMode ? 20 : 24);
			float num5 = (expertMode ? 22f : 20f);
			if (flag4)
			{
				num4 = 25;
				num5 = 29f;
			}
			else if (flag5 && flag3)
			{
				num4 = (expertMode ? 27 : 30);
				if (expertMode)
				{
					num5 = 23f;
				}
			}
			int num6 = 80;
			int num7 = 4;
			float num8 = 0.3f;
			float scaleFactor2 = 5f;
			int num9 = 90;
			int num10 = 180;
			int num11 = 180;
			int num12 = 30;
			int num13 = 120;
			int num14 = 4;
			float scaleFactor3 = 4f;
			float scaleFactor4 = 20f;
			float num15 = (float)Math.PI * 2f / (float)(num13 / 2);
			int num16 = 75;
			Vector2 center = npc.Center;
			Player player = Main.player[npc.target];
			if (npc.target < 0 || npc.target == 255 || player.dead || !player.active)
			{
				npc.TargetClosest();
				player = Main.player[npc.target];
				npc.netUpdate = true;
			}
			if (player.dead || Vector2.Distance(player.Center, center) > 5600f)
			{
				npc.velocity.Y -= 0.8f;
				if (npc.timeLeft > 10)
				{
					npc.timeLeft = 10;
				}
				if (npc.ai[0] > 4f)
				{
					npc.ai[0] = 5f;
				}
				else
				{
					npc.ai[0] = 0f;
				}
				npc.ai[2] = 0f;
			}
			if (!player.ZoneSkyHeight)
			{
				num2 = 1;
				npc.damage = npc.defDamage * 2;
				npc.defense = npc.defDefense * 2;
				npc.ai[3] = 0f;
				num5 += 7f;
			}
			if (npc.localAI[0] == 0f)
			{
				npc.localAI[0] = 1f;
				npc.alpha = 255;
				npc.rotation = 0f;
				if (Main.netMode != NetmodeID.MultiplayerClient)
				{
					npc.ai[0] = -1f;
					npc.netUpdate = true;
				}
			}
			float num17 = (float)Math.Atan2(player.Center.Y - center.Y, player.Center.X - center.X);
			if (npc.spriteDirection == 1)
			{
				num17 += (float)Math.PI;
			}
			if (num17 < 0f)
			{
				num17 += (float)Math.PI * 2f;
			}
			if (num17 > (float)Math.PI * 2f)
			{
				num17 -= (float)Math.PI * 2f;
			}
			if (npc.ai[0] == -1f)
			{
				num17 = 0f;
			}
			if (npc.ai[0] == 3f)
			{
				num17 = 0f;
			}
			if (npc.ai[0] == 4f)
			{
				num17 = 0f;
			}
			if (npc.ai[0] == 8f)
			{
				num17 = 0f;
			}
			float num18 = 0.04f;
			if (npc.ai[0] == 1f || npc.ai[0] == 6f)
			{
				num18 = 0f;
			}
			if (npc.ai[0] == 7f)
			{
				num18 = 0f;
			}
			if (npc.ai[0] == 3f)
			{
				num18 = 0.01f;
			}
			if (npc.ai[0] == 4f)
			{
				num18 = 0.01f;
			}
			if (npc.ai[0] == 8f)
			{
				num18 = 0.01f;
			}
			if (npc.rotation < num17)
			{
				if ((double)(num17 - npc.rotation) > Math.PI)
				{
					npc.rotation -= num18;
				}
				else
				{
					npc.rotation += num18;
				}
			}
			if (npc.rotation > num17)
			{
				if ((double)(npc.rotation - num17) > Math.PI)
				{
					npc.rotation += num18;
				}
				else
				{
					npc.rotation -= num18;
				}
			}
			if (npc.rotation > num17 - num18 && npc.rotation < num17 + num18)
			{
				npc.rotation = num17;
			}
			if (npc.rotation < 0f)
			{
				npc.rotation += (float)Math.PI * 2f;
			}
			if (npc.rotation > (float)Math.PI * 2f)
			{
				npc.rotation -= (float)Math.PI * 2f;
			}
			if (npc.rotation > num17 - num18 && npc.rotation < num17 + num18)
			{
				npc.rotation = num17;
			}
			if (npc.ai[0] != -1f && npc.ai[0] < 9f)
			{
				if (Collision.SolidCollision(npc.position, npc.width, npc.height))
				{
					npc.alpha += 15;
				}
				else
				{
					npc.alpha -= 15;
				}
				if (npc.alpha < 0)
				{
					npc.alpha = 0;
				}
				if (npc.alpha > 150)
				{
					npc.alpha = 150;
				}
			}
			if (npc.ai[0] == -1f)
			{
				npc.velocity *= 0.98f;
				int num19 = Math.Sign(player.Center.X - center.X);
				if (num19 != 0)
				{
					npc.direction = num19;
					npc.spriteDirection = -npc.direction;
				}
				if (npc.ai[2] > 20f)
				{
					npc.velocity.Y = -2f;
					npc.alpha -= 5;
					if (Collision.SolidCollision(npc.position, npc.width, npc.height))
					{
						npc.alpha += 15;
					}
					if (npc.alpha < 0)
					{
						npc.alpha = 0;
					}
					if (npc.alpha > 150)
					{
						npc.alpha = 150;
					}
				}
				if (npc.ai[2] == (float)(num9 - 30))
				{
					int num20 = 36;
					for (int i = 0; i < num20; i++)
					{
						Vector2 value = (Vector2.Normalize(npc.velocity) * new Vector2((float)npc.width / 2f, npc.height) * 0.75f * 0.5f).RotatedBy((float)(i - (num20 / 2 - 1)) * ((float)Math.PI * 2f) / (float)num20) + npc.Center;
						Vector2 value2 = value - npc.Center;
						int num21 = Dust.NewDust(value + value2, 0, 0, DustID.AncientLight, value2.X * 2f, value2.Y * 2f, 100, default(Color), 1.4f);
						Main.dust[num21].noGravity = true;
						Main.dust[num21].noLight = true;
						Main.dust[num21].velocity = Vector2.Normalize(value2) * 3f;
					}
					Main.PlaySound(SoundID.Zombie, (int)center.X, (int)center.Y, 20);
				}
				npc.ai[2] += 1f;
				if (npc.ai[2] >= (float)num16)
				{
					npc.ai[0] = 0f;
					npc.ai[1] = 0f;
					npc.ai[2] = 0f;
					npc.netUpdate = true;
				}
			}
			else if (npc.ai[0] == 0f && !player.dead)
			{
				if (npc.ai[1] == 0f)
				{
					npc.ai[1] = 300 * Math.Sign((center - player.Center).X);
				}
				Vector2 vector = Vector2.Normalize(player.Center + new Vector2(npc.ai[1], -200f) - center - npc.velocity) * scaleFactor;
				if (npc.velocity.X < vector.X)
				{
					npc.velocity.X += num3;
					if (npc.velocity.X < 0f && vector.X > 0f)
					{
						npc.velocity.X += num3;
					}
				}
				else if (npc.velocity.X > vector.X)
				{
					npc.velocity.X -= num3;
					if (npc.velocity.X > 0f && vector.X < 0f)
					{
						npc.velocity.X -= num3;
					}
				}
				if (npc.velocity.Y < vector.Y)
				{
					npc.velocity.Y += num3;
					if (npc.velocity.Y < 0f && vector.Y > 0f)
					{
						npc.velocity.Y += num3;
					}
				}
				else if (npc.velocity.Y > vector.Y)
				{
					npc.velocity.Y -= num3;
					if (npc.velocity.Y > 0f && vector.Y < 0f)
					{
						npc.velocity.Y -= num3;
					}
				}
				int num22 = Math.Sign(player.Center.X - center.X);
				if (num22 != 0)
				{
					if (npc.ai[2] == 0f && num22 != npc.direction)
					{
						npc.rotation += (float)Math.PI;
					}
					npc.direction = num22;
					if (npc.spriteDirection != -npc.direction)
					{
						npc.rotation += (float)Math.PI;
					}
					npc.spriteDirection = -npc.direction;
				}
				npc.ai[2] += 1f;
				if (!(npc.ai[2] >= (float)num2))
				{
					return;
				}
				int num23 = 0;
				switch ((int)npc.ai[3])
				{
					case 0:
					case 1:
					case 2:
					case 3:
					case 4:
					case 5:
					case 6:
					case 7:
					case 8:
					case 9:
						num23 = 1;
						break;
					case 10:
						npc.ai[3] = 1f;
						num23 = 2;
						break;
					case 11:
						npc.ai[3] = 0f;
						num23 = 3;
						break;
				}
				if (flag)
				{
					num23 = 4;
				}
				switch (num23)
				{
					case 1:
						npc.ai[0] = 1f;
						npc.ai[1] = 0f;
						npc.ai[2] = 0f;
						npc.velocity = Vector2.Normalize(player.Center - center) * num5;
						npc.rotation = (float)Math.Atan2(npc.velocity.Y, npc.velocity.X);
						if (num22 != 0)
						{
							npc.direction = num22;
							if (npc.spriteDirection == 1)
							{
								npc.rotation += (float)Math.PI;
							}
							npc.spriteDirection = -npc.direction;
						}
						break;
					case 2:
						npc.ai[0] = 2f;
						npc.ai[1] = 0f;
						npc.ai[2] = 0f;
						break;
					case 3:
						npc.ai[0] = 3f;
						npc.ai[1] = 0f;
						npc.ai[2] = 0f;
						break;
					case 4:
						npc.ai[0] = 4f;
						npc.ai[1] = 0f;
						npc.ai[2] = 0f;
						break;
				}
				npc.netUpdate = true;
			}
			else if (npc.ai[0] == 1f)
			{
				int num24 = 7;
				for (int j = 0; j < num24; j++)
				{
					Vector2 value3 = (Vector2.Normalize(npc.velocity) * new Vector2((float)(npc.width + 50) / 2f, npc.height) * 0.75f).RotatedBy((double)(j - (num24 / 2 - 1)) * Math.PI / (double)(float)num24) + center;
					Vector2 value4 = ((float)(Main.rand.NextDouble() * 3.1415927410125732) - (float)Math.PI / 2f).ToRotationVector2() * Main.rand.Next(3, 8);
					int num25 = Dust.NewDust(value3 + value4, 0, 0, DustID.AncientLight, value4.X * 2f, value4.Y * 2f, 100, default(Color), 1.4f);
					Main.dust[num25].noGravity = true;
					Main.dust[num25].noLight = true;
					Main.dust[num25].velocity /= 4f;
					Main.dust[num25].velocity -= npc.velocity;
				}
				npc.ai[2] += 1f;
				if (npc.ai[2] >= (float)num4)
				{
					npc.ai[0] = 0f;
					npc.ai[1] = 0f;
					npc.ai[2] = 0f;
					npc.ai[3] += 2f;
					npc.netUpdate = true;
				}
			}
			else if (npc.ai[0] == 2f)
			{
				if (npc.ai[1] == 0f)
				{
					npc.ai[1] = 300 * Math.Sign((center - player.Center).X);
				}
				Vector2 vector2 = Vector2.Normalize(player.Center + new Vector2(npc.ai[1], -200f) - center - npc.velocity) * scaleFactor2;
				if (npc.velocity.X < vector2.X)
				{
					npc.velocity.X += num8;
					if (npc.velocity.X < 0f && vector2.X > 0f)
					{
						npc.velocity.X += num8;
					}
				}
				else if (npc.velocity.X > vector2.X)
				{
					npc.velocity.X -= num8;
					if (npc.velocity.X > 0f && vector2.X < 0f)
					{
						npc.velocity.X -= num8;
					}
				}
				if (npc.velocity.Y < vector2.Y)
				{
					npc.velocity.Y += num8;
					if (npc.velocity.Y < 0f && vector2.Y > 0f)
					{
						npc.velocity.Y += num8;
					}
				}
				else if (npc.velocity.Y > vector2.Y)
				{
					npc.velocity.Y -= num8;
					if (npc.velocity.Y > 0f && vector2.Y < 0f)
					{
						npc.velocity.Y -= num8;
					}
				}
				if (npc.ai[2] == 0f)
				{
					Main.PlaySound(SoundID.Zombie, (int)center.X, (int)center.Y, 20);
				}
				if (npc.ai[2] % (float)num7 == 0f)
				{
					Main.PlaySound(SoundID.NPCKilled, (int)npc.Center.X, (int)npc.Center.Y, 19);
					if (Main.netMode != NetmodeID.MultiplayerClient)
					{
						Vector2 vector3 = Vector2.Normalize(player.Center - center) * (npc.width + 20) / 2f + center;
						NPC.NewNPC((int)vector3.X, (int)vector3.Y + 45, ModContent.NPCType<SkyBubble>());
					}
				}
				int num26 = Math.Sign(player.Center.X - center.X);
				if (num26 != 0)
				{
					npc.direction = num26;
					if (npc.spriteDirection != -npc.direction)
					{
						npc.rotation += (float)Math.PI;
					}
					npc.spriteDirection = -npc.direction;
				}
				npc.ai[2] += 1f;
				if (npc.ai[2] >= (float)num6)
				{
					npc.ai[0] = 0f;
					npc.ai[1] = 0f;
					npc.ai[2] = 0f;
					npc.netUpdate = true;
				}
			}
			else if (npc.ai[0] == 3f)
			{
				npc.velocity *= 0.98f;
				npc.velocity.Y = MathHelper.Lerp(npc.velocity.Y, 0f, 0.02f);
				if (npc.ai[2] == (float)(num9 - 30))
				{
					Main.PlaySound(SoundID.Zombie, (int)center.X, (int)center.Y, 9);
				}
				if (Main.netMode != NetmodeID.MultiplayerClient && npc.ai[2] == (float)(num9 - 30))
				{
					Vector2 vector4 = npc.rotation.ToRotationVector2() * (Vector2.UnitX * npc.direction) * (npc.width + 20) / 2f + center;
					Projectile.NewProjectile(vector4.X, vector4.Y, npc.direction * 4, 8f, ModContent.ProjectileType<SkyTyphoonH>(), 0, 0f, Main.myPlayer, 1f, npc.target + 1);
				}
				npc.ai[2] += 1f;
				if (npc.ai[2] >= (float)num9)
				{
					npc.ai[0] = 0f;
					npc.ai[1] = 0f;
					npc.ai[2] = 0f;
					npc.netUpdate = true;
				}
			}
			else if (npc.ai[0] == 4f)
			{
				npc.velocity *= 0.98f;
				npc.velocity.Y = MathHelper.Lerp(npc.velocity.Y, 0f, 0.02f);
				if (npc.ai[2] == (float)(num10 - 60))
				{
					Main.PlaySound(SoundID.Zombie, (int)center.X, (int)center.Y, 20);
				}
				npc.ai[2] += 1f;
				if (npc.ai[2] >= (float)num10)
				{
					npc.ai[0] = 5f;
					npc.ai[1] = 0f;
					npc.ai[2] = 0f;
					npc.ai[3] = 0f;
					npc.netUpdate = true;
				}
			}
			else if (npc.ai[0] == 5f && !player.dead)
			{
				if (npc.ai[1] == 0f)
				{
					npc.ai[1] = 300 * Math.Sign((center - player.Center).X);
				}
				Vector2 vector5 = Vector2.Normalize(player.Center + new Vector2(npc.ai[1], -200f) - center - npc.velocity) * scaleFactor;
				if (npc.velocity.X < vector5.X)
				{
					npc.velocity.X += num3;
					if (npc.velocity.X < 0f && vector5.X > 0f)
					{
						npc.velocity.X += num3;
					}
				}
				else if (npc.velocity.X > vector5.X)
				{
					npc.velocity.X -= num3;
					if (npc.velocity.X > 0f && vector5.X < 0f)
					{
						npc.velocity.X -= num3;
					}
				}
				if (npc.velocity.Y < vector5.Y)
				{
					npc.velocity.Y += num3;
					if (npc.velocity.Y < 0f && vector5.Y > 0f)
					{
						npc.velocity.Y += num3;
					}
				}
				else if (npc.velocity.Y > vector5.Y)
				{
					npc.velocity.Y -= num3;
					if (npc.velocity.Y > 0f && vector5.Y < 0f)
					{
						npc.velocity.Y -= num3;
					}
				}
				int num27 = Math.Sign(player.Center.X - center.X);
				if (num27 != 0)
				{
					if (npc.ai[2] == 0f && num27 != npc.direction)
					{
						npc.rotation += (float)Math.PI;
					}
					npc.direction = num27;
					if (npc.spriteDirection != -npc.direction)
					{
						npc.rotation += (float)Math.PI;
					}
					npc.spriteDirection = -npc.direction;
				}
				npc.ai[2] += 1f;
				if (!(npc.ai[2] >= (float)num2))
				{
					return;
				}
				int num28 = 0;
				switch ((int)npc.ai[3])
				{
					case 0:
					case 1:
					case 2:
					case 3:
					case 4:
					case 5:
						num28 = 1;
						break;
					case 6:
						npc.ai[3] = 1f;
						num28 = 2;
						break;
					case 7:
						npc.ai[3] = 0f;
						num28 = 3;
						break;
				}
				if (flag2)
				{
					num28 = 4;
				}
				switch (num28)
				{
					case 1:
						npc.ai[0] = 6f;
						npc.ai[1] = 0f;
						npc.ai[2] = 0f;
						npc.velocity = Vector2.Normalize(player.Center - center) * num5;
						npc.rotation = (float)Math.Atan2(npc.velocity.Y, npc.velocity.X);
						if (num27 != 0)
						{
							npc.direction = num27;
							if (npc.spriteDirection == 1)
							{
								npc.rotation += (float)Math.PI;
							}
							npc.spriteDirection = -npc.direction;
						}
						break;
					case 2:
						npc.velocity = Vector2.Normalize(player.Center - center) * scaleFactor4;
						npc.rotation = (float)Math.Atan2(npc.velocity.Y, npc.velocity.X);
						if (num27 != 0)
						{
							npc.direction = num27;
							if (npc.spriteDirection == 1)
							{
								npc.rotation += (float)Math.PI;
							}
							npc.spriteDirection = -npc.direction;
						}
						npc.ai[0] = 7f;
						npc.ai[1] = 0f;
						npc.ai[2] = 0f;
						break;
					case 3:
						npc.ai[0] = 8f;
						npc.ai[1] = 0f;
						npc.ai[2] = 0f;
						break;
					case 4:
						npc.ai[0] = 9f;
						npc.ai[1] = 0f;
						npc.ai[2] = 0f;
						break;
				}
				npc.netUpdate = true;
			}
			else if (npc.ai[0] == 6f)
			{
				int num29 = 7;
				for (int k = 0; k < num29; k++)
				{
					Vector2 value5 = (Vector2.Normalize(npc.velocity) * new Vector2((float)(npc.width + 50) / 2f, npc.height) * 0.75f).RotatedBy((double)(k - (num29 / 2 - 1)) * Math.PI / (double)(float)num29) + center;
					Vector2 value6 = ((float)(Main.rand.NextDouble() * 3.1415927410125732) - (float)Math.PI / 2f).ToRotationVector2() * Main.rand.Next(3, 8);
					int num30 = Dust.NewDust(value5 + value6, 0, 0, DustID.AncientLight, value6.X * 2f, value6.Y * 2f, 100, default(Color), 1.4f);
					Main.dust[num30].noGravity = true;
					Main.dust[num30].noLight = true;
					Main.dust[num30].velocity /= 4f;
					Main.dust[num30].velocity -= npc.velocity;
				}
				npc.ai[2] += 1f;
				if (npc.ai[2] >= (float)num4)
				{
					npc.ai[0] = 5f;
					npc.ai[1] = 0f;
					npc.ai[2] = 0f;
					npc.ai[3] += 2f;
					npc.netUpdate = true;
				}
			}
			else if (npc.ai[0] == 7f)
			{
				if (npc.ai[2] == 0f)
				{
					Main.PlaySound(SoundID.Zombie, (int)center.X, (int)center.Y, 20);
				}
				if (npc.ai[2] % (float)num14 == 0f)
				{
					Main.PlaySound(SoundID.NPCKilled, (int)npc.Center.X, (int)npc.Center.Y, 19);
					if (Main.netMode != NetmodeID.MultiplayerClient)
					{
						for (int i = 0; i < 3; i++)
						{
							Vector2 vector6 = Vector2.Normalize(npc.velocity) * (npc.width + 20) / 2f + center;
							int num31 = NPC.NewNPC((int)vector6.X, (int)vector6.Y + 45, ModContent.NPCType<SkyBubble>());
							Main.npc[num31].target = npc.target;
							Main.npc[num31].velocity = Vector2.Normalize(npc.velocity).RotatedBy((float)Math.PI / 2f * (float)npc.direction) * scaleFactor3;
							Main.npc[num31].netUpdate = true;
							Main.npc[num31].ai[3] = (float)Main.rand.Next(80, 121) / 100f;
						}
					}
				}
				npc.velocity = npc.velocity.RotatedBy((0f - num15) * (float)npc.direction);
				npc.rotation -= num15 * (float)npc.direction;
				npc.ai[2] += 1f;
				if (npc.ai[2] >= (float)num13)
				{
					npc.ai[0] = 5f;
					npc.ai[1] = 0f;
					npc.ai[2] = 0f;
					npc.netUpdate = true;
				}
			}
			else if (npc.ai[0] == 8f)
			{
				npc.velocity *= 0.98f;
				npc.velocity.Y = MathHelper.Lerp(npc.velocity.Y, 0f, 0.02f);
				if (npc.ai[2] == (float)(num9 - 30))
				{
					Main.PlaySound(SoundID.Zombie, (int)center.X, (int)center.Y, 20);
				}
				if (Main.netMode != NetmodeID.MultiplayerClient && npc.ai[2] == (float)(num9 - 30))
				{
					Projectile.NewProjectile(center.X, center.Y, 0f, 0f, ModContent.ProjectileType<SkyTyphoonH>(), 0, 0f, Main.myPlayer, 1f, npc.target + 1);
				}
				npc.ai[2] += 1f;
				if (npc.ai[2] >= (float)num9)
				{
					npc.ai[0] = 5f;
					npc.ai[1] = 0f;
					npc.ai[2] = 0f;
					npc.netUpdate = true;
				}
			}
			else if (npc.ai[0] == 9f)
			{
				if (npc.ai[2] < (float)(num11 - 90))
				{
					if (Collision.SolidCollision(npc.position, npc.width, npc.height))
					{
						npc.alpha += 15;
					}
					else
					{
						npc.alpha -= 15;
					}
					if (npc.alpha < 0)
					{
						npc.alpha = 0;
					}
					if (npc.alpha > 150)
					{
						npc.alpha = 150;
					}
				}
				else if (npc.alpha < 255)
				{
					npc.alpha += 4;
					if (npc.alpha > 255)
					{
						npc.alpha = 255;
					}
				}
				npc.velocity *= 0.98f;
				npc.velocity.Y = MathHelper.Lerp(npc.velocity.Y, 0f, 0.02f);
				if (npc.ai[2] == (float)(num11 - 60))
				{
					Main.PlaySound(SoundID.Zombie, (int)center.X, (int)center.Y, 20);
				}
				npc.ai[2] += 1f;
				if (npc.ai[2] >= (float)num11)
				{
					npc.ai[0] = 10f;
					npc.ai[1] = 0f;
					npc.ai[2] = 0f;
					npc.ai[3] = 0f;
					npc.netUpdate = true;
				}
			}
			else if (npc.ai[0] == 10f && !player.dead)
			{
				npc.dontTakeDamage = false;
				npc.chaseable = false;
				if (npc.alpha < 255)
				{
					npc.alpha += 25;
					if (npc.alpha > 255)
					{
						npc.alpha = 255;
					}
				}
				if (npc.ai[1] == 0f)
				{
					npc.ai[1] = 360 * Math.Sign((center - player.Center).X);
				}
				Vector2 desiredVelocity = Vector2.Normalize(player.Center + new Vector2(npc.ai[1], -200f) - center - npc.velocity) * scaleFactor;
				npc.SimpleFlyMovement(desiredVelocity, num3);
				int num32 = Math.Sign(player.Center.X - center.X);
				if (num32 != 0)
				{
					if (npc.ai[2] == 0f && num32 != npc.direction)
					{
						npc.rotation += (float)Math.PI;
						for (int l = 0; l < npc.oldPos.Length; l++)
						{
							npc.oldPos[l] = Vector2.Zero;
						}
					}
					npc.direction = num32;
					if (npc.spriteDirection != -npc.direction)
					{
						npc.rotation += (float)Math.PI;
					}
					npc.spriteDirection = -npc.direction;
				}
				npc.ai[2] += 1f;
				if (!(npc.ai[2] >= (float)num2))
				{
					return;
				}
				int num33 = 0;
				switch ((int)npc.ai[3])
				{
					case 0:
					case 2:
					case 3:
					case 5:
					case 6:
					case 7:
						num33 = 1;
						break;
					case 1:
					case 4:
					case 8:
						num33 = 2;
						break;
				}
				switch (num33)
				{
					case 1:
						npc.ai[0] = 11f;
						npc.ai[1] = 0f;
						npc.ai[2] = 0f;
						npc.velocity = Vector2.Normalize(player.Center - center) * num5;
						npc.rotation = (float)Math.Atan2(npc.velocity.Y, npc.velocity.X);
						if (num32 != 0)
						{
							npc.direction = num32;
							if (npc.spriteDirection == 1)
							{
								npc.rotation += (float)Math.PI;
							}
							npc.spriteDirection = -npc.direction;
						}
						break;
					case 2:
						npc.ai[0] = 12f;
						npc.ai[1] = 0f;
						npc.ai[2] = 0f;
						break;
					case 3:
						npc.ai[0] = 13f;
						npc.ai[1] = 0f;
						npc.ai[2] = 0f;
						break;
				}
				npc.netUpdate = true;
			}
			else if (npc.ai[0] == 11f)
			{
				npc.dontTakeDamage = false;
				npc.chaseable = true;
				npc.alpha -= 25;
				if (npc.alpha < 0)
				{
					npc.alpha = 0;
				}
				int num34 = 7;
				for (int m = 0; m < num34; m++)
				{
					Vector2 value7 = (Vector2.Normalize(npc.velocity) * new Vector2((float)(npc.width + 50) / 2f, npc.height) * 0.75f).RotatedBy((double)(m - (num34 / 2 - 1)) * Math.PI / (double)(float)num34) + center;
					Vector2 value8 = ((float)(Main.rand.NextDouble() * 3.1415927410125732) - (float)Math.PI / 2f).ToRotationVector2() * Main.rand.Next(3, 8);
					int num35 = Dust.NewDust(value7 + value8, 0, 0, DustID.AncientLight, value8.X * 2f, value8.Y * 2f, 100, default(Color), 1.4f);
					Main.dust[num35].noGravity = true;
					Main.dust[num35].noLight = true;
					Main.dust[num35].velocity /= 4f;
					Main.dust[num35].velocity -= npc.velocity;
				}
				npc.ai[2] += 1f;
				if (npc.ai[2] >= (float)num4)
				{
					npc.ai[0] = 10f;
					npc.ai[1] = 0f;
					npc.ai[2] = 0f;
					npc.ai[3] += 1f;
					npc.netUpdate = true;
				}
			}
			else if (npc.ai[0] == 12f)
			{
				npc.dontTakeDamage = true;
				npc.chaseable = false;
				if (npc.alpha < 255)
				{
					npc.alpha += 17;
					if (npc.alpha > 255)
					{
						npc.alpha = 255;
					}
				}
				npc.velocity *= 0.98f;
				npc.velocity.Y = MathHelper.Lerp(npc.velocity.Y, 0f, 0.02f);
				if (npc.ai[2] == (float)(num12 / 2))
				{
					Main.PlaySound(SoundID.Zombie, (int)center.X, (int)center.Y, 20);
				}
				if (Main.netMode != NetmodeID.MultiplayerClient && npc.ai[2] == (float)(num12 / 2))
				{
					if (npc.ai[1] == 0f)
					{
						npc.ai[1] = 300 * Math.Sign((center - player.Center).X);
					}
					Vector2 vector7 = player.Center + new Vector2(0f - npc.ai[1], -200f);
					Vector2 vector9 = (npc.Center = vector7);
					center = vector9;
					int num36 = Math.Sign(player.Center.X - center.X);
					if (num36 != 0)
					{
						if (npc.ai[2] == 0f && num36 != npc.direction)
						{
							npc.rotation += (float)Math.PI;
							for (int n = 0; n < npc.oldPos.Length; n++)
							{
								npc.oldPos[n] = Vector2.Zero;
							}
						}
						npc.direction = num36;
						if (npc.spriteDirection != -npc.direction)
						{
							npc.rotation += (float)Math.PI;
						}
						npc.spriteDirection = -npc.direction;
					}
				}
				npc.ai[2] += 1f;
				if (npc.ai[2] >= (float)num12)
				{
					npc.ai[0] = 10f;
					npc.ai[1] = 0f;
					npc.ai[2] = 0f;
					npc.ai[3] += 1f;
					if (npc.ai[3] >= 9f)
					{
						npc.ai[3] = 0f;
					}
					npc.netUpdate = true;
				}
			}
			else if (npc.ai[0] == 13f)
			{
				if (npc.ai[2] == 0f)
				{
					Main.PlaySound(SoundID.Zombie, (int)center.X, (int)center.Y, 20);
				}
				npc.velocity = npc.velocity.RotatedBy((0f - num15) * (float)npc.direction);
				npc.rotation -= num15 * (float)npc.direction;
				npc.ai[2] += 1f;
				if (npc.ai[2] >= (float)num13)
				{
					npc.ai[0] = 10f;
					npc.ai[1] = 0f;
					npc.ai[2] = 0f;
					npc.ai[3] += 1f;
					npc.netUpdate = true;
				}
			}
		}

		public override void FindFrame(int frameHeight)
		{
			if (++npc.frameCounter > 6)
			{
				npc.frameCounter = 0;
				npc.frame.Y += frameHeight;
				if (npc.frame.Y >= 4 * frameHeight)
					npc.frame.Y = 0;
			}
		}
		public override void NPCLoot()
		{
			if (!Main.expertMode)
			{
				Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ModContent.ItemType<RainbowFeather>(), Main.rand.Next(10, 20));
				if (Main.rand.Next(10) == 0)
					Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ModContent.ItemType<SkySword>(), 1);
				if (Main.rand.Next(10) == 0)
					Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ModContent.ItemType<SkyBow>(), 1);
				if (Main.rand.Next(10) == 0)
					Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ModContent.ItemType<SkyCaster>(), 1);
			}
			if (Main.expertMode)
			{
				npc.DropBossBags();
			}
			ApexWorld.downedSky = true;

			if (Main.rand.Next(10) == 0)
				Item.NewItem(npc.Hitbox, ModContent.ItemType<SkyTrophy>());


		}
		public override void BossLoot(ref string name, ref int potionType)
		{
			potionType = ItemID.SuperHealingPotion;
		}
	}
}

