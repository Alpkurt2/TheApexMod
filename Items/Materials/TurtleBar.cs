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
	public class TurtleBar : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Turtle Bar");
			Tooltip.SetDefault("'An indestructable material'");
		}
		public override void SetDefaults()
		{
			item.maxStack = 999;
			item.value = Item.sellPrice(gold: 1);
			item.width = 30;
			item.height = 24;
			item.rare = ItemRarityID.Lime;
		}
        public override void AddRecipes()
        {
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.ChlorophyteBar, 18);
			recipe.AddIngredient(ItemID.TurtleShell, 1);
			recipe.AddTile(TileID.AdamantiteForge);
			recipe.SetResult(this, 18);
			recipe.AddRecipe();
		}
    }
}