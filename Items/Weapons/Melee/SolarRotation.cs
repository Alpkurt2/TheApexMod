using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace TheApexMod.Items.Weapons.Melee
{
    public class SolarRotation : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Solar Rotation");
            Tooltip.SetDefault("The energy of the planets rotating around the sun condensed into a single weapon.");
        }

        public override void SetDefaults()
        {
            item.damage = 140;
            item.melee = true;
            item.width = 18;
            item.height = 32;
            item.useTime = 12;
            item.useAnimation = 24;
            item.noUseGraphic = true;
            item.useStyle = ItemUseStyleID.SwingThrow;
            item.knockBack = 8;
            item.value = Item.sellPrice(gold: 10);
            item.rare = ItemRarityID.Red;
            item.noMelee = true;
            item.UseSound = SoundID.Item1;
            item.autoReuse = true;
            item.shoot = mod.ProjectileType("SolarRotationProjectile");
            item.shootSpeed = 25;
        }
        public override bool CanUseItem(Player player)
        {
            return player.ownedProjectileCounts[item.shoot] < 4;
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.FragmentSolar, 18);
            recipe.AddTile(TileID.LunarCraftingStation);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
