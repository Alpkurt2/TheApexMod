using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace TheApexMod.Items.Armor
{
    [AutoloadEquip(EquipType.Head)]
    public class DynastyWoodHelmet : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Dynasty Wood Helmet");
        }

        public override void SetDefaults()
        {
            item.value = Item.sellPrice(silver: 6);
            item.width = 30;
            item.height = 20;
            item.rare = ItemRarityID.Blue;
            item.defense = 1;
        }

        public override bool IsArmorSet(Item head, Item body, Item legs)
        {
            return body.type == ModContent.ItemType<DynastyWoodBreastplate>() && legs.type == ModContent.ItemType<DynastyWoodGreaves>();
        }
        public override void UpdateArmorSet(Player player)
        {
            player.setBonus = @"1 Defense.";
            player.statDefense += 1;
        }


        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.DynastyWood, 20);
            recipe.AddTile(TileID.WorkBenches);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}