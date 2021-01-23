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
	public class FrozenImpStaff : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Frozen Imp Staff");
			Tooltip.SetDefault("Summons a frozen imp to fight for you");
		}
		public override void SetDefaults()
		{
			item.CloneDefaults(ItemID.ImpStaff);
			item.damage = 19;
			item.buffType = ModContent.BuffType<FIBuff>();
			item.shoot = ModContent.ProjectileType<FrozenImp>();
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
			recipe.AddIngredient(ModContent.ItemType<Materials.FroststoneBar>(), 17);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}