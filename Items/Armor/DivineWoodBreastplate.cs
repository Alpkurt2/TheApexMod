using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using TheApexMod.Items.Materials;

namespace TheApexMod.Items.Armor
{
    [AutoloadEquip(EquipType.Body)]
    public class DivineWoodBreastplate : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Divinewood Breastplate");
            Tooltip.SetDefault("The ultimate combination of all the wood armors.\nIncreases regeneration insanely\nIncreases your max number of minions by 2\nIncreases damage by 10%.");

        }

        public override void SetDefaults()
        {
            item.value = Item.sellPrice(gold: 10);
            item.width = 30;
            item.height = 20;
            item.rare = ItemRarityID.Red;
            item.defense = 30;
        }

        public override void UpdateEquip(Player player)
        {
            player.lifeRegen += 16;
            player.maxMinions += 2;
            player.allDamage += 0.10f;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<PureWoodBreastplate>(), 1);
            recipe.AddIngredient(ModContent.ItemType<DivineFragment>(), 10);
            recipe.AddTile(TileID.LunarCraftingStation);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}