using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace TheApexMod.Items.Weapons.Ranged
{
    public class CursedFlamethrower : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Cursed Flamethrower");
            Tooltip.SetDefault("For a friend");
        }
        public override void SetDefaults()
        {

            item.damage = 48;
            item.ranged = true;   
            item.width = 42;  
            item.height = 16;
            item.useTime = 6;
            item.useAnimation = 20;
            item.useStyle = ItemUseStyleID.HoldingOut;
            item.noMelee = true;
            item.knockBack = 0.5f; 
            item.UseSound = SoundID.Item34; 
            item.value = Item.sellPrice(0, 15, 0, 0);
            item.rare = ItemRarityID.Yellow;
            item.autoReuse = true;  
            item.shoot = mod.ProjectileType("CursedFlamethrowerProjectile");   
            item.shootSpeed = 4.5f; 
            item.useAmmo = AmmoID.Gel;
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.Flamethrower, 1);
            recipe.AddIngredient(ItemID.CursedFlame, 20);
            recipe.AddIngredient(ItemID.ShroomiteBar, 10);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}