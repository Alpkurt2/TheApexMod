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
	public class GalaxyImp : HoverShooter
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Galaxy Imp");
			Main.projFrames[projectile.type] = 4;
			ProjectileID.Sets.MinionTargettingFeature[projectile.type] = true;
			ProjectileID.Sets.MinionSacrificable[projectile.type] = true;
			ProjectileID.Sets.Homing[projectile.type] = true;
			Main.projPet[projectile.type] = true;

		}

		public sealed override void SetDefaults()
		{
			projectile.width = 30;
			projectile.height = 30;
			projectile.tileCollide = false;
			projectile.friendly = true;
			projectile.minion = true;
			projectile.minionSlots = 1f;
			projectile.penetrate = -1;
			inertia = 20f;
			shoot = ModContent.ProjectileType<GImpFireball>();
			shootSpeed = 16f;
			shootCool = 40f;

		}

		public override void CheckActive()
		{
			Player player = Main.player[projectile.owner];
			if (player.dead || !player.active || player.ownedProjectileCounts[ModContent.ProjectileType<GalaxyImp>()] < 0)
			{
				player.ClearBuff(ModContent.BuffType<GIBuff>());
			}
			if (player.HasBuff(ModContent.BuffType<GIBuff>()))
			{
				projectile.timeLeft = 2;
			}
		}
		public override void CreateDust()
		{
			if (Main.rand.Next(6) == 0)
			{
				int num26 = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, DustID.Shadowflame, 0f, 0f, 100, default(Color), 2f);
				Main.dust[num26].velocity *= 0.3f;
				Main.dust[num26].noGravity = true;
				Main.dust[num26].noLight = true;
			}
		}

		public override void SelectFrame()
		{
			projectile.frameCounter++;
			if (projectile.frameCounter >= 4)
			{
				projectile.frameCounter = 0;
				projectile.frame = (projectile.frame + 1) % 3;
			}
		}


		public override bool MinionContactDamage()
		{
			return true;
		}
	}
}
