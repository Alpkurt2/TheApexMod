using System;
using System.Security.Policy;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using TheApexMod.Buffs.MinionBuffs;

namespace TheApexMod.Projectiles.SummonerProjectiles
{
	public class PWoodMinion : ModProjectile
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Purewood Minion");
			Main.projFrames[projectile.type] = 1;
			ProjectileID.Sets.MinionTargettingFeature[projectile.type] = true;
			ProjectileID.Sets.MinionSacrificable[projectile.type] = true;
			ProjectileID.Sets.Homing[projectile.type] = true;
		}

		public sealed override void SetDefaults()
		{
			aiType = ProjectileID.Raven;
			projectile.width = 30;
			projectile.height = 30;
			Main.projPet[projectile.type] = true;
			projectile.tileCollide = false;
			projectile.friendly = true;
			projectile.minion = true;
			projectile.minionSlots = 1f;
			projectile.penetrate = -1;
			
		}

		public override void AI()
		{
			Player player = Main.player[projectile.owner];
			if (player.dead || !player.active)
			{
				player.ClearBuff(ModContent.BuffType<PureWoodMinionBuff>());
			}
			if (player.HasBuff(ModContent.BuffType<PureWoodMinionBuff>()))
			{
				projectile.timeLeft = 2;
			}
			for (int num541 = 0; num541 < 1000; num541++)
			{
				if (num541 != projectile.whoAmI && Main.projectile[num541].active && Main.projectile[num541].owner == projectile.owner && Math.Abs(projectile.position.X - Main.projectile[num541].position.X) + Math.Abs(projectile.position.Y - Main.projectile[num541].position.Y) < (float)projectile.width)
				{
					if (projectile.position.X < Main.projectile[num541].position.X)
					{
						projectile.velocity.X -= 0.05f;
					}
					else
					{
						projectile.velocity.X += 0.05f;
					}
					if (projectile.position.Y < Main.projectile[num541].position.Y)
					{
						projectile.velocity.Y -= 0.05f;
					}
					else
					{
						projectile.velocity.Y += 0.05f;
					}
				}
			}
			float num542 = projectile.position.X;
			float num543 = projectile.position.Y;
			float num544 = 900f;
			bool flag19 = false;
			int num545 = 500;
			if (projectile.ai[1] != 0f || projectile.friendly)
			{
				num545 = 1400;
			}
			if (Math.Abs(projectile.Center.X - Main.player[projectile.owner].Center.X) + Math.Abs(projectile.Center.Y - Main.player[projectile.owner].Center.Y) > (float)num545)
			{
				projectile.ai[0] = 1f;
			}
			if (projectile.ai[0] == 0f)
			{
				projectile.tileCollide = true;
				NPC ownerMinionAttackTargetNPC2 = projectile.OwnerMinionAttackTargetNPC;
				if (ownerMinionAttackTargetNPC2 != null && ownerMinionAttackTargetNPC2.CanBeChasedBy(projectile))
				{
					float num546 = ownerMinionAttackTargetNPC2.position.X + (float)(ownerMinionAttackTargetNPC2.width / 2);
					float num547 = ownerMinionAttackTargetNPC2.position.Y + (float)(ownerMinionAttackTargetNPC2.height / 2);
					float num548 = Math.Abs(projectile.position.X + (float)(projectile.width / 2) - num546) + Math.Abs(projectile.position.Y + (float)(projectile.height / 2) - num547);
					if (num548 < num544 && Collision.CanHit(projectile.position, projectile.width, projectile.height, ownerMinionAttackTargetNPC2.position, ownerMinionAttackTargetNPC2.width, ownerMinionAttackTargetNPC2.height))
					{
						num544 = num548;
						num542 = num546;
						num543 = num547;
						flag19 = true;
					}
				}
				if (!flag19)
				{
					for (int num549 = 0; num549 < 200; num549++)
					{
						if (Main.npc[num549].CanBeChasedBy(projectile))
						{
							float num550 = Main.npc[num549].position.X + (float)(Main.npc[num549].width / 2);
							float num551 = Main.npc[num549].position.Y + (float)(Main.npc[num549].height / 2);
							float num552 = Math.Abs(projectile.position.X + (float)(projectile.width / 2) - num550) + Math.Abs(projectile.position.Y + (float)(projectile.height / 2) - num551);
							if (num552 < num544 && Collision.CanHit(projectile.position, projectile.width, projectile.height, Main.npc[num549].position, Main.npc[num549].width, Main.npc[num549].height))
							{
								num544 = num552;
								num542 = num550;
								num543 = num551;
								flag19 = true;
							}
						}
					}
				}
			}
			else
			{
				projectile.tileCollide = false;
			}
			if (!flag19)
			{
				projectile.friendly = true;
				float num553 = 8f;
				if (projectile.ai[0] == 1f)
				{
					num553 = 12f;
				}
				Vector2 vector35 = new Vector2(projectile.position.X + (float)projectile.width * 0.5f, projectile.position.Y + (float)projectile.height * 0.5f);
				float num554 = Main.player[projectile.owner].Center.X - vector35.X;
				float num555 = Main.player[projectile.owner].Center.Y - vector35.Y - 60f;
				float num556 = (float)Math.Sqrt(num554 * num554 + num555 * num555);
				float num557 = num556;
				if (num556 < 100f && projectile.ai[0] == 1f && !Collision.SolidCollision(projectile.position, projectile.width, projectile.height))
				{
					projectile.ai[0] = 0f;
				}
				if (num556 > 2000f)
				{
					projectile.position.X = Main.player[projectile.owner].Center.X - (float)(projectile.width / 2);
					projectile.position.Y = Main.player[projectile.owner].Center.Y - (float)(projectile.width / 2);
				}
				if (num556 > 70f)
				{
					num556 = num553 / num556;
					num554 *= num556;
					num555 *= num556;
					projectile.velocity.X = (projectile.velocity.X * 20f + num554) / 21f;
					projectile.velocity.Y = (projectile.velocity.Y * 20f + num555) / 21f;
				}
				else
				{
					if (projectile.velocity.X == 0f && projectile.velocity.Y == 0f)
					{
						projectile.velocity.X = -0.15f;
						projectile.velocity.Y = -0.05f;
					}
					projectile.velocity *= 1.01f;
				}
				projectile.friendly = false;
				projectile.rotation = projectile.velocity.X * 0.05f;
				projectile.frameCounter++;
				if (projectile.frameCounter >= 4)
				{
					projectile.frameCounter = 0;
					projectile.frame++;
				}
				if (projectile.frame > 3)
				{
					projectile.frame = 0;
				}
				if ((double)Math.Abs(projectile.velocity.X) > 0.2)
				{
					projectile.spriteDirection = -projectile.direction;
				}
				return;
			}
			if (projectile.ai[1] == -1f)
			{
				projectile.ai[1] = 17f;
			}
			if (projectile.ai[1] > 0f)
			{
				projectile.ai[1] -= 1f;
			}
			if (projectile.ai[1] == 0f)
			{
				projectile.friendly = true;
				float num558 = 8f;
				Vector2 vector36 = new Vector2(projectile.position.X + (float)projectile.width * 0.5f, projectile.position.Y + (float)projectile.height * 0.5f);
				float num559 = num542 - vector36.X;
				float num560 = num543 - vector36.Y;
				float num561 = (float)Math.Sqrt(num559 * num559 + num560 * num560);
				float num562 = num561;
				if (num561 < 100f)
				{
					num558 = 10f;
				}
				num561 = num558 / num561;
				num559 *= num561;
				num560 *= num561;
				projectile.velocity.X = (projectile.velocity.X * 14f + num559) / 15f;
				projectile.velocity.Y = (projectile.velocity.Y * 14f + num560) / 15f;
			}
			else
			{
				projectile.friendly = false;
				if (Math.Abs(projectile.velocity.X) + Math.Abs(projectile.velocity.Y) < 10f)
				{
					projectile.velocity *= 1.05f;
				}
			}
			projectile.rotation = projectile.velocity.X * 0.05f;
			projectile.frameCounter++;
			if (projectile.frameCounter >= 4)
			{
				projectile.frameCounter = 0;
				projectile.frame++;
			}
			if (projectile.frame < 4)
			{
				projectile.frame = 4;
			}
			if (projectile.frame > 7)
			{
				projectile.frame = 4;
			}
			if ((double)Math.Abs(projectile.velocity.X) > 0.2)
			{
				projectile.spriteDirection = -projectile.direction;
			}
		}
		public override bool MinionContactDamage()
		{
			return true;
		}
		public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
			projectile.ai[1] = -1f;
			projectile.netUpdate = true;
		}
    }
}
