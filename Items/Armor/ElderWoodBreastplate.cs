using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace TheApexMod.Items.Armor
{
    [AutoloadEquip(EquipType.Body)]
    public class ElderWoodBreastplate : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Elderwood Breastplate");
            Tooltip.SetDefault("A combination of all the wood armors.\nIncreases regeneration");

        }

        public override void SetDefaults()
        {
            item.value = Item.sellPrice(silver: 2);
            item.width = 30;
            item.height = 20;
            item.rare = ItemRarityID.Green;
            item.defense = 6; 
        }

        public override void UpdateEquip(Player player)
        {
            player.lifeRegen += 3;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.WoodBreastplate, 1);
            recipe.AddIngredient(ItemID.BorealWoodBreastplate, 1);
            recipe.AddIngredient(ItemID.RichMahoganyBreastplate, 1);
            recipe.AddIngredient(ItemID.EbonwoodBreastplate, 1);
            recipe.AddIngredient(ItemID.PalmWoodBreastplate, 1);
            recipe.AddIngredient(ModContent.ItemType<DynastyWoodBreastplate>(), 1);
            recipe.AddTile(TileID.WorkBenches);
            recipe.SetResult(this);
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.WoodBreastplate, 1);
            recipe.AddIngredient(ItemID.BorealWoodBreastplate, 1);
            recipe.AddIngredient(ItemID.RichMahoganyBreastplate, 1);
            recipe.AddIngredient(ItemID.ShadewoodBreastplate, 1);
            recipe.AddIngredient(ItemID.PalmWoodBreastplate, 1);
            recipe.AddIngredient(ModContent.ItemType<DynastyWoodBreastplate>(), 1);
            recipe.AddTile(TileID.WorkBenches);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}