using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace TheApexMod.Items.Armor
{
    [AutoloadEquip(EquipType.Body)]
    public class DynastyWoodBreastplate : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Dynasty Wood Breastplate");
        }

        public override void SetDefaults()
        {
            item.value = Item.sellPrice(silver: 2);
            item.width = 30;
            item.height = 20;
            item.rare = ItemRarityID.Blue;
            item.defense = 2; 
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.DynastyWood, 30);
            recipe.AddTile(TileID.WorkBenches);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}