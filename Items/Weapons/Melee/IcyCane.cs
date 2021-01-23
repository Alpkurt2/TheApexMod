using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace TheApexMod.Items.Weapons.Melee
{
    public class IcyCane : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Icy Cane");
        }

        public override void SetDefaults()
        {
            item.damage = 84;
            item.melee = true;
            item.Size = new Vector2(120f);
            item.useTime = 14;
            item.useAnimation = 14;
            item.useStyle = ItemUseStyleID.SwingThrow;
            item.knockBack = 5.5f;
            item.value = Item.sellPrice(gold: 15);
            item.rare = ItemRarityID.Cyan;
            item.UseSound = SoundID.Item1;
            item.autoReuse = true;
            item.shoot = ModContent.ProjectileType<Projectiles.MeleeProjectiles.ICaneProj>();
            item.shootSpeed = 16;
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<TheCane>(), 1);
            recipe.AddIngredient(ModContent.ItemType<IcyEdge>(), 1);
            recipe.AddIngredient(ModContent.ItemType<Materials.NaughtyEssence>(), 1);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
