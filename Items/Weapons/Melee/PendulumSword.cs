using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using TheApexMod.Buffs;

namespace TheApexMod.Items.Weapons.Melee
{
    public class PendulumSword : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Pendulum Sword");
            Tooltip.SetDefault("A sword based on a clock handle.");
        }
        
        public override void SetDefaults()
        {
            item.damage = 20;
            item.melee = true;
            item.noMelee = false;
            item.mana = 8;
            item.noUseGraphic = false;
            item.Size = new Vector2(120f);
            item.useTime = 12;
            item.useAnimation = 12;
            item.channel = true;
            item.useStyle = ItemUseStyleID.HoldingOut;
            item.knockBack = 0;
            item.value = Item.sellPrice(gold: 5);
            item.rare = ItemRarityID.Pink;
            item.autoReuse = true;
            Item.staff[item.type] = true;
            item.shoot = ModContent.ProjectileType<Projectiles.MeleeProjectiles.NoxBeam>();
            item.shootSpeed = 10;
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.CopperWatch, 1);
            recipe.AddIngredient(ItemID.HallowedBar, 15);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}

