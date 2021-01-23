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
	public class SnowmanHeart : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Snowman's Heart");
			Tooltip.SetDefault("Contains sheer coldness.");
		}
		public override void SetDefaults()
		{
			item.maxStack = 999;
			item.value = 0;
			item.width = 20;
			item.height = 20;
			item.rare = ItemRarityID.Pink;
		}
	}
}