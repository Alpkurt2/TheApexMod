using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace TheApexMod.Items.Weapons.Melee
{
	public class ElderWoodSword : ModItem
	{
		public override void SetStaticDefaults() 
		{
			DisplayName.SetDefault("Elderwood Sword");
			Tooltip.SetDefault("A combination of all the pre-hardmode wooden swords.");
		}

		public override void SetDefaults() 
		{
			item.damage = 24;
			item.melee = true;
            item.Size = new Vector2(60);
			item.useTime = 20;
			item.useAnimation = 20;
			item.useStyle = ItemUseStyleID.SwingThrow;
			item.knockBack = 5;
			item.value = Item.sellPrice(silver:10);
			item.rare = ItemRarityID.Green;
			item.UseSound = SoundID.Item1;
			item.autoReuse = true;
		}

		public override void AddRecipes() 
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.WoodenSword, 1);
            recipe.AddIngredient(ItemID.BorealWoodSword, 1);
            recipe.AddIngredient(ItemID.RichMahoganySword, 1);
            recipe.AddIngredient(ItemID.EbonwoodSword, 1);
            recipe.AddIngredient(ItemID.PalmWoodSword, 1);
            recipe.AddIngredient(ModContent.ItemType<DynastyWoodSword>(), 1);
            recipe.AddTile(TileID.WorkBenches);
			recipe.SetResult(this);
			recipe.AddRecipe();

            ModRecipe recipetwo = new ModRecipe(mod);
            recipetwo.AddIngredient(ItemID.WoodenSword, 1);
            recipetwo.AddIngredient(ItemID.BorealWoodSword, 1);
            recipetwo.AddIngredient(ItemID.RichMahoganySword, 1);
            recipetwo.AddIngredient(ItemID.ShadewoodSword, 1);
            recipetwo.AddIngredient(ItemID.PalmWoodSword, 1);
            recipetwo.AddIngredient(ModContent.ItemType<DynastyWoodSword>(), 1);
            recipetwo.AddTile(TileID.WorkBenches);
            recipetwo.SetResult(this);
            recipetwo.AddRecipe();
        }
	}
}