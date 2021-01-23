using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.DataStructures;
using System.Collections.Generic;

namespace TheApexMod.Items.Placeable
{
	public class Froststone : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Froststone");
			Tooltip.SetDefault("The icy counterpart to Hellstone, Froststone.");
		}
		public override void SetDefaults()
		{
			item.CloneDefaults(ItemID.Hellstone);
			item.useStyle = ItemUseStyleID.SwingThrow;
			item.useTurn = true;
			item.useAnimation = 15;
			item.useTime = 10;
			item.autoReuse = true;
			item.consumable = true;
			item.createTile = ModContent.TileType<Tiles.FroststoneOreTile>();
			item.width = 20;
			item.height = 20;
			item.maxStack = 999;
			item.rare = ItemRarityID.Green;
		}
	}
}