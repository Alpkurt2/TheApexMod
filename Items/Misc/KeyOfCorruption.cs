using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace TheApexMod.Items.Misc
{
	public class KeyOfCorruption : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Key of Corruption");
			Tooltip.SetDefault("Spawns the Corruption Mimic.");
		}


		public override void SetDefaults()
		{
			item.maxStack = 20;
			item.value = 0;
			item.rare = ItemRarityID.White;
			item.useAnimation = 30;
			item.useTime = 30;
			item.useStyle = ItemUseStyleID.HoldingUp;
			item.width = 20;
			item.height = 20;
			item.consumable = true;
		}
		public override bool UseItem(Player player)
		{
			NPC.SpawnOnPlayer(player.whoAmI, NPCID.BigMimicCorruption);
			Main.PlaySound(SoundID.Roar, player.position, 0);
			return true;
		}
        public override void AddRecipes()
        {
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.NightKey, 1);
			recipe.AddIngredient(ItemID.TissueSample, 5);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}

    }
}