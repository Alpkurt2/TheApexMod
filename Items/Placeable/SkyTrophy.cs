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
	public class SkyTrophy : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Sky Trophy");
		}
		public override void SetDefaults()
		{

			item.useStyle = ItemUseStyleID.SwingThrow;
			item.useTurn = true;
			item.useAnimation = 15;
			item.useTime = 10;
			item.autoReuse = true;
			item.consumable = true;
			item.createTile = ModContent.TileType<Tiles.BossTrophy>();
			item.width = 20;
			item.height = 20;
			item.maxStack = 999;
			item.value = 2500;
			item.rare = ItemRarityID.Blue;
		}
	}
}