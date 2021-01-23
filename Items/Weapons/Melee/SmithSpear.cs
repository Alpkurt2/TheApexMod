using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace TheApexMod.Items.Weapons.Melee
{
	public class SmithSpear : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Smith Spear");
			Tooltip.SetDefault("A smither's dream spear");
		}

		public override void SetDefaults()
		{
			item.damage = 80;
			item.useStyle = ItemUseStyleID.HoldingOut;
			item.useAnimation = 16;
			item.useTime = 22;
			item.shootSpeed = 3.7f;
			item.knockBack = 6.5f;
			item.width = 32;
			item.height = 32;
			item.scale = 1f;
			item.rare = ItemRarityID.Pink;
			item.value = Item.sellPrice(gold: 5);

			item.melee = true;
			item.noMelee = true;
			item.noUseGraphic = true; 
			item.autoReuse = true; 

			item.UseSound = SoundID.Item1;
			item.shoot = mod.ProjectileType("SmithSpearProjectile");
		}

		public override bool CanUseItem(Player player)
		{
			return player.ownedProjectileCounts[item.shoot] < 1;
		}
		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.AdamantiteGlaive, 1);
			recipe.AddIngredient(ItemID.TitaniumTrident, 1);
			recipe.AddIngredient(ItemID.OrichalcumHalberd, 1);
			recipe.AddIngredient(ItemID.MythrilHalberd, 1);
			recipe.AddIngredient(ItemID.PalladiumPike, 1);
			recipe.AddIngredient(ItemID.CobaltNaginata, 1);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}