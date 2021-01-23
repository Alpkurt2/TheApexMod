using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace TheApexMod.Items.Weapons.Melee
{
	public class JunglesResolution : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Jungle's Resolution");
		}

		public override void SetDefaults()
		{
			item.damage = 56;
			item.useStyle = ItemUseStyleID.HoldingOut;
			item.useAnimation = 16;
			item.useTime = 22;
			item.shootSpeed = 3.7f;
			item.knockBack = 6.5f;
			item.width = 32;
			item.height = 32;
			item.scale = 1f;
			item.rare = ItemRarityID.LightPurple;
			item.value = Item.sellPrice(gold: 5);

			item.melee = true;
			item.noMelee = true;
			item.noUseGraphic = true; 
			item.autoReuse = true; 

			item.UseSound = SoundID.Item1;
			item.shoot = mod.ProjectileType("JrProj");
		}

		public override bool CanUseItem(Player player)
		{
			return player.ownedProjectileCounts[item.shoot] < 1;
		}
	}
}