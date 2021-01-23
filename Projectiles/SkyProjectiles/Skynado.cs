using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using TheApexMod.NPCs.Bosses;

namespace TheApexMod.Projectiles.SkyProjectiles
{
    public class Skynado : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            Main.projFrames[projectile.type] = 6;
        }
        public override void SetDefaults()
        {
            projectile.CloneDefaults(ProjectileID.Sharknado);
			projectile.aiStyle = -1;
        }
		public override void AI()
		{
			int num617 = 10;
			int num618 = 15;
			float num619 = 1f;
			int num620 = 150;
			int num621 = 42;
			if (projectile.velocity.X != 0f)
			{
				projectile.direction = (projectile.spriteDirection = -Math.Sign(projectile.velocity.X));
			}
			projectile.frameCounter++;
			if (projectile.frameCounter > 2)
			{
				projectile.frame++;
				projectile.frameCounter = 0;
			}
			if (projectile.frame >= 6)
			{
				projectile.frame = 0;
			}
			if (projectile.localAI[0] == 0f && Main.myPlayer == projectile.owner)
			{
				projectile.localAI[0] = 1f;
				projectile.position.X += projectile.width / 2;
				projectile.position.Y += projectile.height / 2;
				projectile.scale = ((float)(num617 + num618) - projectile.ai[1]) * num619 / (float)(num618 + num617);
				projectile.width = (int)((float)num620 * projectile.scale);
				projectile.height = (int)((float)num621 * projectile.scale);
				projectile.position.X -= projectile.width / 2;
				projectile.position.Y -= projectile.height / 2;
				projectile.netUpdate = true;
			}
			if (projectile.ai[1] != -1f)
			{
				projectile.scale = ((float)(num617 + num618) - projectile.ai[1]) * num619 / (float)(num618 + num617);
				projectile.width = (int)((float)num620 * projectile.scale);
				projectile.height = (int)((float)num621 * projectile.scale);
			}
			if (!Collision.SolidCollision(projectile.position, projectile.width, projectile.height))
			{
				projectile.alpha -= 30;
				if (projectile.alpha < 60)
				{
					projectile.alpha = 60;
				}
			}
			else
			{
				projectile.alpha += 30;
				if (projectile.alpha > 150)
				{
					projectile.alpha = 150;
				}
			}
			if (projectile.ai[0] > 0f)
			{
				projectile.ai[0]--;
			}
			if (projectile.ai[0] == 1f && projectile.ai[1] > 0f && projectile.owner == Main.myPlayer)
			{
				projectile.netUpdate = true;
				Vector2 center = projectile.Center;
				center.Y -= (float)num621 * projectile.scale / 2f;
				float num622 = ((float)(num617 + num618) - projectile.ai[1] + 1f) * num619 / (float)(num618 + num617);
				center.Y -= (float)num621 * num622 / 2f;
				center.Y += 2f;
				Projectile.NewProjectile(center.X, center.Y, projectile.velocity.X, projectile.velocity.Y, projectile.type, projectile.damage, projectile.knockBack, projectile.owner, 10f, projectile.ai[1] - 1f);
				int num623 = 4;
				if ((int)projectile.ai[1] % num623 == 0 && projectile.ai[1] != 0f)
				{
					int num624 = ModContent.NPCType<Skyron>();
					int num625 = NPC.NewNPC((int)center.X, (int)center.Y, num624);
					Main.npc[num625].velocity = projectile.velocity;
					Main.npc[num625].netUpdate = true;
				}
			}
			if (projectile.ai[0] <= 0f)
			{
				float num626 = (float)Math.PI / 30f;
				float num627 = (float)projectile.width / 5f;
				float num628 = (float)(Math.Cos(num626 * (0f - projectile.ai[0])) - 0.5) * num627;
				projectile.position.X -= num628 * (float)(-projectile.direction);
				projectile.ai[0]--;
				num628 = (float)(Math.Cos(num626 * (0f - projectile.ai[0])) - 0.5) * num627;
				projectile.position.X += num628 * (float)(-projectile.direction);
			}
		}
        public override void Kill(int timeLeft)
        {
            for (int num352 = 0; num352 < 20; num352++)
            {
                int num353 = Dust.NewDust(projectile.position, projectile.width, projectile.height, DustID.AncientLight, projectile.direction * 2, 0f, 100, default(Color), 1.4f);
                Dust dust117 = Main.dust[num353];
                dust117.color = Color.CornflowerBlue;
                dust117.color = Color.Lerp(dust117.color, Color.White, 0.3f);
                dust117.noGravity = true;
            }
        }  
    }
}

