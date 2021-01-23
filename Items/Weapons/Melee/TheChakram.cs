using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace TheApexMod.Items.Weapons.Melee
{
    public class TheChakram : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("The Chakram");
        }

        public override void SetDefaults()
        {
            item.CloneDefaults(ItemID.FruitcakeChakram);
            item.damage = 48;
            item.melee = true;
            item.width = 18;
            item.height = 32;
            item.useTime = 14;
            item.useAnimation = 14;
            item.useStyle = ItemUseStyleID.SwingThrow;
            item.knockBack = 6.5f;
            item.value = Item.sellPrice(gold: 2);
            item.rare = ItemRarityID.Pink;
            item.noMelee = true;
            item.autoReuse = true;
            item.shoot = mod.ProjectileType("ChakramProj");
            item.shootSpeed = 20;
        }
        public override bool CanUseItem(Player player)
        {
            return player.ownedProjectileCounts[item.shoot] < 2;
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.FruitcakeChakram, 1);
            recipe.AddIngredient(ModContent.ItemType<Materials.ConcentratedSnow>(), 1);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
