using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace TheApexMod.Items.Weapons.Magic
{
    public class PureCaster : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Pure Caster");
            Tooltip.SetDefault("A more powerful version of the Elder Caster.");
        }

        public override void SetDefaults()
        {   
            item.damage = 80;
            item.mana = 10;
            item.UseSound = SoundID.Item43;
            item.useStyle = ItemUseStyleID.HoldingOut;
            
            item.useAnimation = 14;
            item.useTime = 14;
            item.width = 40;
            item.height = 40;
          
            item.knockBack = 5.5f;
            item.magic = true;
            item.autoReuse = true;
            item.value = Item.sellPrice(gold: 5);
            item.rare = ItemRarityID.Yellow;
            item.noMelee = true;
            item.shoot = mod.ProjectileType("PureBolt");
            item.shootSpeed = 15;
            Item.staff[item.type] = true;
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<ElderCaster>(), 1);
            recipe.AddIngredient(ItemID.SpectreStaff, 1);
            recipe.AddIngredient(ItemID.HallowedBar, 15);
            recipe.AddIngredient(ItemID.SoulofMight, 5);
            recipe.AddIngredient(ItemID.SoulofSight, 5);
            recipe.AddIngredient(ItemID.SoulofFright, 5);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
