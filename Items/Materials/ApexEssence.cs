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
	public class ApexEssence : ModItem
	{
        public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Apex Essence");
			Tooltip.SetDefault("Used to craft some of the strongest weapons of all time.");
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
		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ModContent.ItemType<RainbowFeather>(), 1);
			recipe.AddIngredient(ModContent.ItemType<SoulOfSuperBright>(), 1);
			recipe.AddIngredient(ItemID.Gel, 1);
			recipe.AddIngredient(ItemID.BeetleHusk, 1);
			recipe.AddIngredient(ItemID.Ectoplasm, 1);
			recipe.AddIngredient(ItemID.LunarBar, 1);
			recipe.AddIngredient(ItemID.FragmentNebula, 1);
			recipe.AddIngredient(ItemID.FragmentSolar, 1);
			recipe.AddIngredient(ItemID.FragmentStardust, 1);
			recipe.AddIngredient(ItemID.FragmentVortex, 1);
			recipe.AddIngredient(ItemID.AncientBattleArmorMaterial, 1);
			recipe.AddIngredient(ItemID.FrostCore, 1);
			recipe.AddIngredient(ItemID.TissueSample, 1);
			recipe.AddIngredient(ItemID.ShadowScale, 1);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}