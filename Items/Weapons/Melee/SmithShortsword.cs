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
    public class SmithShortsword : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Smith Shortsword");
            Tooltip.SetDefault("A smither's great shortsword");
        }
        
        public override void SetDefaults()
        {
            item.CloneDefaults(ItemID.PlatinumShortsword);
            item.damage = 17;
            item.melee = true;
            item.Size = new Vector2(120f);
            item.useTime = 10;
            item.useAnimation = 10;
            item.useStyle = ItemUseStyleID.Stabbing;
            item.knockBack = 5;
            item.value = Item.sellPrice(gold: 1);
            item.rare = ItemRarityID.Green;
            item.UseSound = SoundID.Item1;
            item.autoReuse = true;
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.PlatinumShortsword, 1);
            recipe.AddIngredient(ItemID.GoldShortsword, 1);
            recipe.AddIngredient(ItemID.TungstenShortsword, 1);
            recipe.AddIngredient(ItemID.SilverShortsword, 1);
            recipe.AddIngredient(ItemID.TinShortsword, 1);
            recipe.AddIngredient(ItemID.CopperShortsword, 1);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}

