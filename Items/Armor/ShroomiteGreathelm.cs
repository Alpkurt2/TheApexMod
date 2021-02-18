using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using System.Collections.Generic;
using TheApexMod.Projectiles;
using TheApexMod;
using System.Security.Policy;
using Terraria.DataStructures;

namespace TheApexMod.Items.Armor
{
    [AutoloadEquip(EquipType.Head)]
    public class ShroomiteGreathelm : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Shroomite Greathelm");
            Tooltip.SetDefault("20% increased ranged damage.\n15% increased ranged critical strike chance.");
        }

        public override void SetDefaults()
        {
            item.value = Item.sellPrice(gold: 15);
            item.width = 34;
            item.height = 32;
            item.rare = ItemRarityID.Cyan;
            item.defense = 22;
        }
        public override void UpdateEquip(Player player)
        {
            player.rangedDamage += 0.2f;
            player.rangedCrit += 15;
        }

        public override bool IsArmorSet(Item head, Item body, Item legs)
        {
            return body.type == ItemID.ShroomiteBreastplate && legs.type == ItemID.ShroomiteLeggings;
        }
        
        public override void UpdateArmorSet(Player player)
        {
            player.setBonus = "Not moving puts you in stealth, increasing ranged ability and reducing chance for enemies to target you";
            player.shroomiteStealth = true;
            
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.ShroomiteHeadgear, 1);
            recipe.AddIngredient(ItemID.ShroomiteHelmet, 1);
            recipe.AddIngredient(ItemID.ShroomiteMask, 1);
            recipe.AddIngredient(ItemID.BeetleHusk, 5);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}