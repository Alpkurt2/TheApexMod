using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.DataStructures;
using System.Collections.Generic;
using TheApexMod.Items.Placeable;

namespace TheApexMod.Items.Materials
{
	public class FroststoneBar : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Froststone Bar");
			Tooltip.SetDefault("'Cold to the touch'");
		}
		public override void SetDefaults()
		{
			item.maxStack = 999;
			item.value = Item.sellPrice(silver: 40);
			item.width = 20;
			item.height = 20;
			item.rare = ItemRarityID.Green;
		}
        public override void AddRecipes()
        {
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ModContent.ItemType<Froststone>(), 3);
			recipe.AddIngredient(ItemID.Obsidian, 1);
			recipe.AddTile(TileID.Hellforge);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
    }
}