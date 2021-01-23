using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace TheApexMod.Items.Armor
{
    [AutoloadEquip(EquipType.Head)]
    public class GalaxyHelmet : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Galaxy Helmet");
            Tooltip.SetDefault("20% increased critical strike chance");
        }

        public override void SetDefaults()
        {
            item.value = Item.sellPrice(gold: 8);
            item.width = 20;
            item.height = 18;
            item.rare = ItemRarityID.Red;
            item.defense = 16;
        }

        public override bool IsArmorSet(Item head, Item body, Item legs)
        {
            return body.type == ModContent.ItemType<GalaxyBreastplate>() && legs.type == ModContent.ItemType<GalaxyGreaves>();
        }
        public override void UpdateEquip(Player player)
        {
            player.rangedCrit += 20;
            player.meleeCrit += 20;
            player.magicCrit += 20;
        }
        public override void UpdateArmorSet(Player player)
        {
            player.setBonus = @"Increases all damage by 30%. Gives you immunity to every fire debuff.";
            player.rangedDamage += 0.30f;
            player.meleeDamage += 0.30f;
            player.buffImmune[39] = true;
            player.buffImmune[24] = true;
            player.buffImmune[44] = true;
            player.buffImmune[153] = true;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<NeoHelmet>(), 1);
            recipe.AddIngredient(ModContent.ItemType<Materials.DivineFragment>(), 10);
            recipe.AddTile(TileID.LunarCraftingStation);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}