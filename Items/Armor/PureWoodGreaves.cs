using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace TheApexMod.Items.Armor
{
    [AutoloadEquip(EquipType.Legs)]
    public class PureWoodGreaves : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Purewood Greaves");
            Tooltip.SetDefault("A true combination of all the wood armors.\n40% increased movement speed.\nIncreases your max number of minions by 1.\nIncreases damage by 5%");
        }

        public override void SetDefaults()
        {
            item.value = Item.sellPrice(gold: 5);
            item.width = 22;
            item.height = 18;
            item.rare = ItemRarityID.Yellow;
            item.defense = 17;
        }

        public override void UpdateEquip(Player player)
        {
            player.moveSpeed += 0.4f;
            player.maxMinions += 1;
            player.allDamage += 0.05f;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<ElderWoodGreaves>(), 1);
            recipe.AddIngredient(ItemID.SpookyLeggings, 1);
            recipe.AddIngredient(ItemID.PearlwoodGreaves, 1);
            recipe.AddIngredient(ItemID.Ectoplasm, 10);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}