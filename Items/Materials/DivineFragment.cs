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
	public class DivineFragment : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Divine Fragment");
			Tooltip.SetDefault("All the lunar fragments combined into a single fragment.");
			ItemID.Sets.ItemIconPulse[item.type] = true;
			ItemID.Sets.ItemNoGravity[item.type] = true;
			ItemID.Sets.AnimatesAsSoul[item.type] = true;
			Main.RegisterItemAnimation(item.type, new DrawAnimationVertical(10, 2));
		}
		public override void SetDefaults()
		{
			item.maxStack = 999;
			item.value = Item.sellPrice(silver: 80);
			item.width = 20;
			item.height = 20;
			item.rare = ItemRarityID.Red;
		}
        public override void AddRecipes()
        {
			ModRecipe recipe = new ModRecipe(mod);
     		recipe.AddIngredient(ItemID.FragmentNebula, 1);
			recipe.AddIngredient(ItemID.FragmentSolar, 1);
			recipe.AddIngredient(ItemID.FragmentStardust, 1);
			recipe.AddIngredient(ItemID.FragmentVortex, 1);
			recipe.AddTile(TileID.LunarCraftingStation);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
    }
}