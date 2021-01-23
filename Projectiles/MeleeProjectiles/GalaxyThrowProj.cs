using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace TheApexMod.Projectiles.MeleeProjectiles
{
	public class GalaxyThrowProj : ModProjectile
	{
		public override void SetStaticDefaults()
		{
			ProjectileID.Sets.YoyosLifeTimeMultiplier[projectile.type] = -1;
			ProjectileID.Sets.YoyosMaximumRange[projectile.type] = 350f;
			ProjectileID.Sets.YoyosTopSpeed[projectile.type] = 17f;
		}

		public override void SetDefaults()
		{
			projectile.extraUpdates = 0;
			projectile.width = 16;
			projectile.height = 16;
			projectile.aiStyle = 99;
			projectile.friendly = true;
			projectile.penetrate = -1;
			projectile.melee = true;
			projectile.scale = 1f;
		}
		public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
		{
			target.immune[projectile.owner] = 6;
			target.AddBuff(BuffID.ShadowFlame, 300);
			Vector2 spawn = new Vector2(projectile.Center.X, projectile.Center.Y);
			Vector2 speed = target.Center - spawn;
			speed.Normalize();
			speed *= 15f;
			Projectile.NewProjectile(spawn, speed, ModContent.ProjectileType<GalaxyStar>(), damage, 1f, Main.myPlayer);

		}

		public override void PostAI()
		{
			if (Main.rand.NextBool())
			{
				for (int i = 0; i < 2; i++)
				{
					Dust dust = Dust.NewDustDirect(projectile.position, projectile.width, projectile.height, DustID.Shadowflame);
					dust.noGravity = true;
					dust.scale = 1.6f;
				}
			}
		}
	}
}