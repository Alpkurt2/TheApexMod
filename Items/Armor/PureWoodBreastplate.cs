using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace TheApexMod.Items.Armor
{
    [AutoloadEquip(EquipType.Body)]
    public class PureWoodBreastplate : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Purewood Breastplate");
            Tooltip.SetDefault("A true combination of all the wood armors.\nIncreases regeneration greatly.\nIncreases your max number of minions by 2\nIncreases damage by 5%.");

        }

        public override void SetDefaults()
        {
            item.value = Item.sellPrice(gold: 6);
            item.width = 30;
            item.height = 20;
            item.rare = ItemRarityID.Yellow;
            item.defense = 22;
        }

        public override void UpdateEquip(Player player)
        {
            player.lifeRegen += 8;
            player.maxMinions += 2;
            player.allDamage += 0.05f;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<ElderWoodBreastplate>(), 1);
            recipe.AddIngredient(ItemID.SpookyBreastplate, 1);
            recipe.AddIngredient(ItemID.PearlwoodBreastplate, 1);
            recipe.AddIngredient(ItemID.Ectoplasm, 10);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}