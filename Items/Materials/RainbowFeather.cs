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
	public class RainbowFeather : ModItem
	{
        public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Rainbow Feather");
			Tooltip.SetDefault("Seem's like it's from a cool bird.");
			Main.RegisterItemAnimation(item.type, new DrawAnimationVertical(4, 7));
		}
		public override void ModifyTooltips(List<TooltipLine> list)
		{
			foreach (TooltipLine line2 in list)
			{
				if (line2.mod == "Terraria" && line2.Name == "ItemName")
				{
					line2.overrideColor = new Color(Main.DiscoR, Main.DiscoG, Main.DiscoB);
				}
			}
		}
		public override void SetDefaults()
		{
			item.maxStack = 999;
			item.value = Item.sellPrice(gold: 1);
			item.width = 20;
			item.height = 20;
			item.rare = ItemRarityID.Purple;
		}
	}
}