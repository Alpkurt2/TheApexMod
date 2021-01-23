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

namespace TheApexMod.Items.Weapons.FrostTiers
{
	public class GalaxyStaff : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Galaxy Staff");
			Tooltip.SetDefault("Summons a Galaxy imp to fight for you");
		}
		public override void SetDefaults()
		{
			item.CloneDefaults(ItemID.ImpStaff);
			item.damage = 80;
			item.rare = ItemRarityID.Red;
			item.knockBack = 4f;
			item.value = Item.sellPrice(gold: 10);
			item.buffType = ModContent.BuffType<GIBuff>();
			item.shoot = ModContent.ProjectileType<GalaxyImp>();
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
			recipe.AddIngredient(ModContent.ItemType<NeoStaff>(), 1);
			recipe.AddIngredient(ModContent.ItemType<Materials.DivineFragment>(), 10);
			recipe.AddTile(TileID.LunarCraftingStation);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}