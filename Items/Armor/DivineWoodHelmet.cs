using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using System.Collections.Generic;
using TheApexMod.Projectiles;
using TheApexMod;
using TheApexMod.Items.Materials;

namespace TheApexMod.Items.Armor
{
    [AutoloadEquip(EquipType.Head)]
    public class DivineWoodHelmet : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Divinewood Helmet");
            Tooltip.SetDefault("The ultimate combination of all the wood armors.\nIncreases your max number of minions by 1.\nIncreases damage by 10%.");
        }

        public override void SetDefaults()
        {
            item.value = Item.sellPrice(gold: 6);
            item.width = 30;
            item.height = 30;
            item.rare = ItemRarityID.Red;
            item.defense = 24;
        }
        public override void UpdateEquip(Player player)
        {
            player.maxMinions += 1;
            player.allDamage += 0.10f;
        }

        public override bool IsArmorSet(Item head, Item body, Item legs)
        {
            return body.type == ModContent.ItemType<DivineWoodBreastplate>() && legs.type == ModContent.ItemType<DivineWoodGreaves>();
        }

        public override void UpdateArmorSet(Player player)
        {
            player.setBonus = "Increases damage by 15%.\nHas a chance to spawn projectiles from the Sky when you hit an enemy";
            player.allDamage += 0.15f;
            player.GetModPlayer<ApexPlayer>().DivineEffect = true;
            
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<PureWoodHelmet>(), 1);
            recipe.AddIngredient(ModContent.ItemType<DivineFragment>(), 10);
            recipe.AddTile(TileID.LunarCraftingStation);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}