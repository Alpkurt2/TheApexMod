using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace TheApexMod.Items.Weapons.Melee
{
    public class PureWoodSword : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Purewood Sword");
            Tooltip.SetDefault("A more perfected version of the Elderwood sword, this one contains immense power.");
        }

        public override void SetDefaults()
        {
            item.damage = 80;
            item.melee = true;
            item.Size = new Vector2(42);
            item.useTime = 14;
            item.useAnimation = 14;
            item.useStyle = ItemUseStyleID.SwingThrow;
            item.knockBack = 6;
            item.value = Item.sellPrice(gold: 3);
            item.rare = ItemRarityID.Yellow;
            item.UseSound = SoundID.Item1;
            item.autoReuse = true;
            item.shoot = mod.ProjectileType("PureWoodSwordProjectile");
            item.shootSpeed = 12;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<ElderWoodSword>(), 1);
            recipe.AddIngredient(ModContent.ItemType<SpookyWoodSword>(), 1);
            recipe.AddIngredient(ItemID.PearlwoodSword, 1);
            recipe.AddIngredient(ItemID.BrokenHeroSword, 1);
            recipe.AddIngredient(ItemID.Ectoplasm, 10);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
        