using Microsoft.Xna.Framework;

using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace TheApexMod.Dusts
{
    public class GalaxyDust : ModDust
    {

        public override void OnSpawn(Dust dust)
        {
            dust.velocity.Y = (float)Main.rand.Next(-10, 6) * 0.1f;
            dust.velocity.X *= 0.3f;
            dust.scale *= 0.7f;
        }

        public override bool Update(Dust dust)
        {
            if (!dust.noGravity)
            {
                dust.velocity.Y += 0.05f;
            }
            float num60 = dust.scale * 1.4f;
            if (!dust.noLight)
            {
                if (num60 > 1f)
                {
                    num60 = 1f;
                }
                Lighting.AddLight((int)(dust.position.X / 16f), (int)(dust.position.Y / 16f), num60 * 0.1f, num60 * 0.4f, num60);
            }
            if (dust.scale < 0.05f && !dust.noLight)
            {
                dust.active = false;
            }
            else
            {
                dust.scale -= 0.04f;
                if (dust.velocity.X > 0)
                {
                    dust.rotation += 0.1f / dust.scale;
                }
                else
                {
                    dust.rotation -= 0.1f / dust.scale;
                }
            }
                return false;
        }

        public override Color? GetAlpha(Dust dust, Color lightColor)
        {
            return new Color(lightColor.R, lightColor.G, lightColor.B, 25);
        }
    }
}
