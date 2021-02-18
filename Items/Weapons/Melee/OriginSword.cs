using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace TheApexMod.Items.Weapons.Melee
{
    public class OriginSword : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Origin Sword");
            Tooltip.SetDefault("A sword?");
        }

        public override void SetDefaults()
        {
            item.damage = 6;
            item.melee = true;
            item.Size = new Vector2(40);
            item.useTime = 16;
            item.useAnimation = 16;
            item.useStyle = ItemUseStyleID.SwingThrow;
            item.knockBack = 5.5f;
            item.value = Item.sellPrice(silver: 1);
            item.rare = ItemRarityID.Blue;
            item.UseSound = SoundID.Item1;
            item.autoReuse = true;
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddRecipeGroup(RecipeGroupID.IronBar, 10);
            recipe.AddIngredient(ItemID.Wood, 10);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
