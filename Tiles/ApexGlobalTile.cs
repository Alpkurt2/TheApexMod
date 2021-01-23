using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Graphics;
using Terraria.Localization;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using TheApexMod.Items.Materials;

namespace TheApexMod.Tiles
{
	public class ApexGlobalTile : GlobalTile
	{

        public override bool Drop(int i, int j, int type)
		{
			Tile tile = Main.tile[i, j];
				  
				if (tile == null)
				return base.Drop(i, j, type);

			if (type == TileID.LargePiles && i >= 810 && j <= 862)
			{
				if (i % 2 == 0 && j % 2 == 0)
				{
					Item.NewItem(i * 16, j * 16, 8, 8, ModContent.ItemType<BrokenHeroBlade>(), 1);
				}
			}
			return true;
		}
	}
}

