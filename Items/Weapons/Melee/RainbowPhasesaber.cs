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
    public class RainbowPhasesaber : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Rainbow Phasesaber");
        }
        
        public override void SetDefaults()
        {
            item.CloneDefaults(ItemID.BluePhasesaber);
            item.damage = 52;
            item.melee = true;
            item.useTime = 16;
            item.useAnimation = 16;
            item.value = Item.sellPrice(gold: 3);
            item.rare = ItemRarityID.Pink;
            item.autoReuse = true;
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<RainbowPhaseblade>());
            recipe.AddIngredient(ItemID.CrystalShard, 50);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}

