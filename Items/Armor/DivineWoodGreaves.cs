using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using TheApexMod.Items.Materials;

namespace TheApexMod.Items.Armor
{
    [AutoloadEquip(EquipType.Legs)]
    public class DivineWoodGreaves : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Divinewood Greaves");
            Tooltip.SetDefault("The ultimate combination of all the wood armors.\n100% increased movement speed\nIncreases your max number of minions by 1.\nIncreases damage by 10%");
        }

        public override void SetDefaults()
        {
            item.value = Item.sellPrice(gold: 8);
            item.width = 22;
            item.height = 18;
            item.rare = ItemRarityID.Red;
            item.defense = 22;
        }

        public override void UpdateEquip(Player player)
        {
            player.moveSpeed += 1f;
            player.maxRunSpeed += 1f;
            player.maxMinions += 1;
            player.allDamage += 0.10f;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<PureWoodGreaves>(), 1);
            recipe.AddIngredient(ModContent.ItemType<DivineFragment>(), 10);
            recipe.AddTile(TileID.LunarCraftingStation);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}