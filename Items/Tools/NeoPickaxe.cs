using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace TheApexMod.Items.Tools
{
    public class NeoPickaxe : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Neo Pickaxe");
        }
        public override void SetDefaults()
        {
            item.CloneDefaults(ItemID.MoltenPickaxe);
            item.damage = 24;
            item.useTime = 21;
            item.useAnimation = 21;
            item.pick = 190;
            item.rare = ItemRarityID.Pink;
            item.value = Item.sellPrice(gold: 3);

            item.width = 20;
            item.height = 20;
        }
        public override void MeleeEffects(Player player, Rectangle hitbox)
        {
            if (Main.rand.Next(3) == 0)
            {
                Dust.NewDust(new Vector2(hitbox.X, hitbox.Y), hitbox.Width, hitbox.Height, 135);
                Dust.NewDust(new Vector2(hitbox.X, hitbox.Y), hitbox.Width, hitbox.Height, DustID.Fire);
            }
        }
        public override void OnHitNPC(Player player, NPC target, int damage, float knockBack, bool crit)
        {
            target.AddBuff(BuffID.Frostburn, 180);
            target.AddBuff(BuffID.OnFire, 180);
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.MoltenPickaxe, 1);
            recipe.AddIngredient(ModContent.ItemType<ChilledPickaxe>(), 1);
            recipe.AddIngredient(ItemID.SoulofLight, 12);
            recipe.AddIngredient(ItemID.SoulofNight, 12);
            recipe.AddIngredient(ItemID.DarkShard, 1);
            recipe.AddIngredient(ItemID.LightShard, 1);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
