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
	public class FrozenAsh : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Frozen Ash");
		}
		public override void SetDefaults()
		{
			item.CloneDefaults(ItemID.AshBlock);
			item.useStyle = ItemUseStyleID.SwingThrow;
			item.useTurn = true;
			item.useAnimation = 15;
			item.useTime = 10;
			item.autoReuse = true;
			item.consumable = true;
			item.createTile = ModContent.TileType<Tiles.FrozenAshTile>();
			item.width = 20;
			item.height = 20;
			item.maxStack = 999;
		}
	}
}