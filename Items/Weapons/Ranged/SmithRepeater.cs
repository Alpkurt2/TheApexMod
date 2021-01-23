using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace TheApexMod.Items.Weapons.Ranged
{
    public class SmithRepeater : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Smith Repeater");
            Tooltip.SetDefault("A smither's dream bow.");
        }

        public override void SetDefaults()
        {
            item.damage = 50;
            item.noMelee = true;
            item.ranged = true;
            item.Size = new Vector2(120f);
            item.UseSound = SoundID.Item5;
            item.useTime = 16;
            item.useAnimation = 16;
            item.useStyle = ItemUseStyleID.HoldingOut;
            item.knockBack = 2.75f;
            item.value = Item.sellPrice(gold: 5);
            item.rare = ItemRarityID.Pink;
            item.UseSound = SoundID.Item5;
            item.autoReuse = true;
            item.useAmmo = AmmoID.Arrow;
            item.shoot = ProjectileID.WoodenArrowFriendly;
            item.shootSpeed = 14;
             
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.CobaltRepeater, 1);
            recipe.AddIngredient(ItemID.PalladiumRepeater, 1);
            recipe.AddIngredient(ItemID.MythrilRepeater, 1);
            recipe.AddIngredient(ItemID.OrichalcumRepeater, 1);
            recipe.AddIngredient(ItemID.AdamantiteRepeater, 1);
            recipe.AddIngredient(ItemID.TitaniumRepeater, 1);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
