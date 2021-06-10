using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace TheApexMod.Items.Misc
{
	public class MysteriousFeather : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Mysterious Feather");
			Tooltip.SetDefault("Has a chance to drop from every enemy in the space biome.\nThe boss enrages outside the space biome.");
		}

		
		public override void SetDefaults()
		{
			item.maxStack = 20;
			item.value = 0;
			item.rare = ItemRarityID.Blue;
			item.useAnimation = 30;
			item.useTime = 30;
			item.useStyle = ItemUseStyleID.HoldingUp;
			item.width = 20;
			item.height = 20;
			item.consumable = true;
		}
		public override bool UseItem(Player player)
		{
			if (player.ZoneSkyHeight)
			{
				NPC.SpawnOnPlayer(player.whoAmI, mod.NPCType("Sky"));
				Main.PlaySound(SoundID.Roar, player.position, 0);
				return true;
			}
			else
			{
				return false;
			}
		}
	}
}