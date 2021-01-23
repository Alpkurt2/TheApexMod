using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace TheApexMod.Items.Armor
{
    [AutoloadEquip(EquipType.Body)]
    public class GalaxyBreastplate : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Galaxy Breastplate");
            Tooltip.SetDefault("20% increased damage");

        }

        public override void SetDefaults()
        {
            item.value = Item.sellPrice(gold: 10);
            item.width = 26;
            item.height = 18;
            item.rare = ItemRarityID.Red;
            item.defense = 8; 
        }

        public override void UpdateEquip(Player player)
        {
            player.allDamage += 0.2f;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<NeoBreastplate>(), 1);
            recipe.AddIngredient(ModContent.ItemType<Materials.DivineFragment>(), 10);
            recipe.AddTile(TileID.LunarCraftingStation);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}