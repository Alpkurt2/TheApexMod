using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using TheApexMod.Buffs;

namespace TheApexMod.Items.Weapons.Melee
{
    public class SmithSword : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Smith Sword");
            Tooltip.SetDefault("A smither's dream blade");
        }
        
        public override void SetDefaults()
        {
            item.damage = 80;
            item.melee = true;
            item.Size = new Vector2(120f);
            item.useTime = 12;
            item.useAnimation = 12;
            item.useStyle = ItemUseStyleID.SwingThrow;
            item.knockBack = 7;
            item.value = Item.sellPrice(gold: 5);
            item.rare = ItemRarityID.Pink;
            item.UseSound = SoundID.Item1;
            item.autoReuse = true;
        }
        

        public override void MeleeEffects(Player player, Rectangle hitbox)
        {
            if (Main.rand.Next(3) == 0)
                Dust.NewDust(new Vector2(hitbox.X, hitbox.Y), hitbox.Width, hitbox.Height, DustID.AncientLight);
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.AdamantiteSword, 1);
            recipe.AddIngredient(ItemID.TitaniumSword, 1);
            recipe.AddIngredient(ItemID.OrichalcumSword, 1);
            recipe.AddIngredient(ItemID.MythrilSword, 1);
            recipe.AddIngredient(ItemID.PalladiumSword, 1);
            recipe.AddIngredient(ItemID.CobaltSword, 1);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}

