using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.DataStructures;
using System.Collections.Generic;

namespace TheApexMod.Items.Materials
{
	public class ConcentratedSnow : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Concentrated Snow");
			Tooltip.SetDefault("Snow that's so concentrated it's used to forge weapons.");
			Main.RegisterItemAnimation(item.type, new DrawAnimationVertical(4, 7));
		}
		public override void SetDefaults()
		{
			item.maxStack = 999;
			item.value = Item.sellPrice(gold: 2);
			item.width = 20;
			item.height = 20;
			item.rare = ItemRarityID.LightPurple;
		}
        public override void AddRecipes()
        {
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ModContent.ItemType<SnowmanHeart>(), 1);
			recipe.AddIngredient(ItemID.FrostCore, 1);
			recipe.AddIngredient(ItemID.SnowBlock, 200);
			recipe.AddIngredient(ItemID.SoulofLight, 5);
			recipe.AddIngredient(ItemID.SoulofNight, 5);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
    }
}