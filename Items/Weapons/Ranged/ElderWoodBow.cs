using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace TheApexMod.Items.Weapons.Ranged
{
    public class ElderWoodBow : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Elderwood Bow");
            Tooltip.SetDefault("A combination of all the pre-hardmode wood bows.");
        }

        public override void SetDefaults()
        {
            item.damage = 22;
            item.noMelee = true;
            item.ranged = true;
            item.Size = new Vector2(120f);
            item.UseSound = SoundID.Item5;
            item.useTime = 26;
            item.useAnimation = 26;
            item.useStyle = ItemUseStyleID.HoldingOut;
            item.knockBack = 2.5f;
            item.value = Item.sellPrice(silver: 5);
            item.rare = ItemRarityID.Green;
            item.UseSound = SoundID.Item5;
            item.autoReuse = true;
            item.useAmmo = AmmoID.Arrow;
            item.shoot = ProjectileID.WoodenArrowFriendly;
            item.shootSpeed = 14;
             
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.WoodenBow, 1);
            recipe.AddIngredient(ItemID.BorealWoodBow, 1);
            recipe.AddIngredient(ItemID.RichMahoganyBow, 1);
            recipe.AddIngredient(ItemID.EbonwoodBow, 1);
            recipe.AddIngredient(ItemID.PalmWoodBow, 1);
            recipe.AddIngredient(ModContent.ItemType<DynastyWoodBow>(), 1);
            recipe.AddTile(TileID.WorkBenches);
            recipe.SetResult(this);
            recipe.AddRecipe();

            ModRecipe recipetwo = new ModRecipe(mod);
            recipetwo.AddIngredient(ItemID.WoodenBow, 1);
            recipetwo.AddIngredient(ItemID.BorealWoodBow, 1);
            recipetwo.AddIngredient(ItemID.RichMahoganyBow, 1);
            recipetwo.AddIngredient(ItemID.ShadewoodBow, 1);
            recipetwo.AddIngredient(ItemID.PalmWoodBow, 1);
            recipetwo.AddIngredient(ModContent.ItemType<DynastyWoodBow>(), 1);
            recipetwo.AddTile(TileID.WorkBenches);
            recipetwo.SetResult(this);
            recipetwo.AddRecipe();
        }
    }
}
