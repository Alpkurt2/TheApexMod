using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace TheApexMod.Items.Weapons.Ranged
{
    public class StarChakram : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Star Chakram");
        }

        public override void SetDefaults()
        {
            item.CloneDefaults(ItemID.FruitcakeChakram);
            item.damage = 64;
            item.ranged = true;
            item.melee = false;
            item.width = 18;
            item.height = 32;
            item.useTime = 12;
            item.useAnimation = 12;
            item.useStyle = ItemUseStyleID.SwingThrow;
            item.knockBack = 1;
            item.value = Item.sellPrice(gold: 5);
            item.rare = ItemRarityID.Cyan;
            item.noMelee = true;
            item.autoReuse = true;
            item.shoot = mod.ProjectileType("SChakramProj");
            item.shootSpeed = 16;
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Melee.TheChakram>(), 1);
            recipe.AddIngredient(ModContent.ItemType<STARAnise>(), 1);
            recipe.AddIngredient(ModContent.ItemType<Materials.NaughtyEssence>(), 1);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
