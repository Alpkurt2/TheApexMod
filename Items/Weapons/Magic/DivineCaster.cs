using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using TheApexMod.Items.Materials;

namespace TheApexMod.Items.Weapons.Magic
{
    public class DivineCaster : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Divine Caster");
            Tooltip.SetDefault("A Pure Staff infused with the celestial fragments.");
        }

        public override void SetDefaults()
        {   
            item.damage = 120;
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
            item.value = Item.sellPrice(gold: 7);
            item.rare = ItemRarityID.Yellow;
            item.noMelee = true;
            item.shoot = mod.ProjectileType("DivineBolt");
            item.shootSpeed = 16;
            Item.staff[item.type] = true;
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<PureCaster>(), 1);
            recipe.AddIngredient(ModContent.ItemType<DivineFragment>(), 10);
            recipe.AddTile(TileID.LunarCraftingStation);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
