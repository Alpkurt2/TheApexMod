using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace TheApexMod.Items.Armor
{
    [AutoloadEquip(EquipType.Legs)]
    public class GalaxyGreaves : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Galaxy Greaves");
            Tooltip.SetDefault("20% increased damage");
        }

        public override void SetDefaults()
        {
            item.value = Item.sellPrice(gold: 8);
            item.width = 22;
            item.height = 18;
            item.rare = ItemRarityID.Red;
            item.defense = 18;
        }

        public override void UpdateEquip(Player player)
        {
            player.allDamage += 0.2f;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<NeoGreaves>(), 1);
            recipe.AddIngredient(ModContent.ItemType<Materials.DivineFragment>(), 10);
            recipe.AddTile(TileID.LunarCraftingStation);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}