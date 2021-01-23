using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using TheApexMod.Items.Materials;

namespace TheApexMod.Items.Weapons.FrostTiers
{
    public class FrostburnShuriken : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Frostburn Shuriken");
            Tooltip.SetDefault("A regular shuriken imbued with the power of frostburn.");
        }

        public override void SetDefaults()
        {
            item.damage = 28;
            item.ranged = true;
            item.useTime = 16;
            item.useAnimation = 16;
            item.noUseGraphic = true;
            item.useStyle = ItemUseStyleID.SwingThrow;
            item.noMelee = true;
            item.knockBack = 0;
            item.value = Item.sellPrice(gold: 10);
            item.rare = ItemRarityID.Orange;
            item.UseSound = SoundID.Item1;
            item.autoReuse = true;
            item.shoot = mod.ProjectileType("FrostburnShurikenProjectile");
            item.shootSpeed = 13f;

            item.width = 20;
            item.height = 20;
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<FroststoneBar>(), 10);
            recipe.AddIngredient(ItemID.Shuriken, 999);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
