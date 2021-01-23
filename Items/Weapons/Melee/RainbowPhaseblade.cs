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
    public class RainbowPhaseblade : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Rainbow Phaseblade");
        }
        
        public override void SetDefaults()
        {
            item.CloneDefaults(ItemID.BluePhaseblade);
            item.damage = 35;
            item.useTime = 20;
            item.useAnimation = 20;
            item.value = Item.sellPrice(gold: 2);
            item.rare = ItemRarityID.Green;
            item.autoReuse = true;
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.BluePhaseblade, 1);
            recipe.AddIngredient(ItemID.GreenPhaseblade, 1);
            recipe.AddIngredient(ItemID.PurplePhaseblade, 1);
            recipe.AddIngredient(ItemID.RedPhaseblade, 1);
            recipe.AddIngredient(ItemID.WhitePhaseblade, 1);
            recipe.AddIngredient(ItemID.YellowPhaseblade, 1);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}

