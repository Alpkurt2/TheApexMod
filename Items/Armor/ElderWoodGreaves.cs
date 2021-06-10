using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace TheApexMod.Items.Armor
{
    [AutoloadEquip(EquipType.Legs)]
    public class ElderWoodGreaves : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Elderwood Greaves");
            Tooltip.SetDefault("A combination of all the wood armors.\n10% increased movement speed");
        }

        public override void SetDefaults()
        {
            item.value = Item.sellPrice(silver: 8);
            item.width = 22;
            item.height = 18;
            item.rare = ItemRarityID.Green;
            item.defense = 5;
        }

        public override void UpdateEquip(Player player)
        {
            player.moveSpeed += 0.1f;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.WoodGreaves, 1);
            recipe.AddIngredient(ItemID.BorealWoodGreaves, 1);
            recipe.AddIngredient(ItemID.RichMahoganyGreaves, 1);
            recipe.AddIngredient(ItemID.EbonwoodGreaves, 1);
            recipe.AddIngredient(ItemID.PalmWoodGreaves, 1);
            recipe.AddIngredient(ModContent.ItemType<DynastyWoodGreaves>(), 1);
            recipe.AddTile(TileID.WorkBenches);
            recipe.SetResult(this);
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.WoodGreaves, 1);
            recipe.AddIngredient(ItemID.BorealWoodGreaves, 1);
            recipe.AddIngredient(ItemID.RichMahoganyGreaves, 1);
            recipe.AddIngredient(ItemID.ShadewoodGreaves, 1);
            recipe.AddIngredient(ItemID.PalmWoodGreaves, 1);
            recipe.AddIngredient(ModContent.ItemType<DynastyWoodGreaves>(), 1);
            recipe.AddTile(TileID.WorkBenches);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}