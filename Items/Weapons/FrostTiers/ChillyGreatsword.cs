using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using TheApexMod.Buffs;
using TheApexMod.Items.Materials;
using TheApexMod.Items.Weapons.Melee;
using TheApexMod.Projectiles;

namespace TheApexMod.Items.Weapons.FrostTiers
{
    public class ChillyGreatsword : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Chilly Greatsword");
        }

        
        public override void SetDefaults()
        {
            item.CloneDefaults(ItemID.FieryGreatsword);
            item.damage = 32;
        }
        public override void MeleeEffects(Player player, Rectangle hitbox)
        {
                Dust.NewDust(new Vector2(hitbox.X, hitbox.Y), hitbox.Width, hitbox.Height, 135, 0f, 0f, 0, default(Color), 1.5f);
        }
        public override void OnHitNPC(Player player, NPC target, int damage, float knockBack, bool crit)
        {
            target.AddBuff(BuffID.Frostburn, 300);
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<FroststoneBar>(), 20);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
