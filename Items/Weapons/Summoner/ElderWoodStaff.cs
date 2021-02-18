using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using TheApexMod.Buffs;
using TheApexMod.Buffs.MinionBuffs;
using TheApexMod.Projectiles;
using TheApexMod.Projectiles.SummonerProjectiles;

namespace TheApexMod.Items.Weapons.Summoner
{
	public class ElderWoodStaff : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Elderwood Staff");
			Tooltip.SetDefault("A staff of nature");
		}
		public override void SetDefaults()
		{
			item.damage = 24;
			item.knockBack = 2.5f;
			item.mana = 10;
			item.width = 32;
			item.height = 32;
			item.useTime = 36;
			item.useAnimation = 36;
			item.useStyle = ItemUseStyleID.SwingThrow;
			item.value = Item.sellPrice(silver: 5);
			item.rare = ItemRarityID.Green;
			item.UseSound = SoundID.Item44;

			item.noMelee = true;
			item.summon = true;
			item.buffType = ModContent.BuffType<EWoodMinionBuff>();
			item.shoot = ModContent.ProjectileType<EWoodMinion>();
		}

		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			player.AddBuff(item.buffType, 2);
			position = Main.MouseWorld;
			return true;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ModContent.ItemType<WoodenStaff>(), 1);
			recipe.AddIngredient(ItemID.BorealWood, 25);
			recipe.AddIngredient(ItemID.RichMahogany, 25);
			recipe.AddIngredient(ItemID.Ebonwood, 25);
			recipe.AddIngredient(ItemID.PalmWood, 25);
			recipe.AddIngredient(ItemID.DynastyWood, 25);
			recipe.AddTile(TileID.WorkBenches);
			recipe.SetResult(this);
			recipe.AddRecipe();
			recipe = new ModRecipe(mod);
			recipe.AddIngredient(ModContent.ItemType<WoodenStaff>(), 1);
			recipe.AddIngredient(ItemID.BorealWood, 25);
			recipe.AddIngredient(ItemID.RichMahogany, 25);
			recipe.AddIngredient(ItemID.Shadewood, 25);
			recipe.AddIngredient(ItemID.PalmWood, 25);
			recipe.AddIngredient(ItemID.DynastyWood, 25);
			recipe.AddTile(TileID.WorkBenches);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}