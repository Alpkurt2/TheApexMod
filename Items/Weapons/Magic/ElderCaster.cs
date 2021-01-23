using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace TheApexMod.Items.Weapons.Magic
{
    public class ElderCaster : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Elder Caster");
            Tooltip.SetDefault("A staff made by combining all the other gem staves.");
        }

        public override void SetDefaults()
        {   
            item.damage = 32;
            item.mana = 8;
            item.UseSound = SoundID.Item43;
            item.useStyle = ItemUseStyleID.HoldingOut;
            
            item.useAnimation = 24;
            item.useTime = 24;
            item.width = 40;
            item.height = 40;
          
            item.knockBack = 5.5f;
            item.magic = true;
            item.autoReuse = true;
            item.value = Item.sellPrice(gold: 1);
            item.rare = ItemRarityID.Green;
            item.noMelee = true;
            item.shoot = mod.ProjectileType("ElderBolt");
            item.shootSpeed = 10;
            Item.staff[item.type] = true;
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.AmethystStaff, 1);
            recipe.AddIngredient(ItemID.TopazStaff, 1);
            recipe.AddIngredient(ItemID.SapphireStaff, 1);
            recipe.AddIngredient(ItemID.EmeraldStaff, 1);
            recipe.AddIngredient(ItemID.RubyStaff, 1);
            recipe.AddIngredient(ItemID.DiamondStaff, 1);
            recipe.AddIngredient(ItemID.AmberStaff, 1);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
