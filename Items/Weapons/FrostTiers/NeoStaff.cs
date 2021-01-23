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
	public class NeoStaff : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Neo Staff");
			Tooltip.SetDefault("Summons an elemental imp to fight for you");
		}
		public override void SetDefaults()
		{
			item.CloneDefaults(ItemID.ImpStaff);
			item.damage = 50;
			item.rare = ItemRarityID.Pink;
			item.knockBack = 3f;
			item.value = Item.sellPrice(gold: 1);
			item.buffType = ModContent.BuffType<NIBuff>();
			item.shoot = ModContent.ProjectileType<NeoImp>();
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
			recipe.AddIngredient(ItemID.ImpStaff, 1);
			recipe.AddIngredient(ModContent.ItemType<FrozenImpStaff>(), 1);
			recipe.AddIngredient(ItemID.SoulofLight, 12);
			recipe.AddIngredient(ItemID.SoulofNight, 12);
			recipe.AddIngredient(ItemID.DarkShard, 1);
			recipe.AddIngredient(ItemID.LightShard, 1);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}