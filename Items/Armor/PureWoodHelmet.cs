using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using System.Collections.Generic;
using TheApexMod.Projectiles;
using TheApexMod;

namespace TheApexMod.Items.Armor
{
    [AutoloadEquip(EquipType.Head)]
    public class PureWoodHelmet : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Purewood Helmet");
            Tooltip.SetDefault("A true combination of all the wood armors.\nIncreases your max number of minions by 1.\nIncreases damage by 5%.");
        }

        public override void SetDefaults()
        {
            item.value = Item.sellPrice(gold: 5);
            item.width = 30;
            item.height = 26;
            item.rare = ItemRarityID.Yellow;
            item.defense = 17;
        }
        public override void UpdateEquip(Player player)
        {
            player.maxMinions += 1;
            player.allDamage += 0.05f;
        }

        public override bool IsArmorSet(Item head, Item body, Item legs)
        {
            return body.type == ModContent.ItemType<PureWoodBreastplate>() && legs.type == ModContent.ItemType<PureWoodGreaves>();
        }

        public override void UpdateArmorSet(Player player)
        {
            player.setBonus = "Has a chance to spawn an extra projectile when you fire a weapon";
            player.GetModPlayer<ApexPlayer>().PureEffect = true;
            
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<ElderWoodHelmet>(), 1);
            recipe.AddIngredient(ItemID.SpookyHelmet, 1);
            recipe.AddIngredient(ItemID.PearlwoodHelmet, 1);
            recipe.AddIngredient(ItemID.Ectoplasm, 10);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}