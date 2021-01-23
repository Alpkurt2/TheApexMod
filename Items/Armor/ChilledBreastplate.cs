using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace TheApexMod.Items.Armor
{
    [AutoloadEquip(EquipType.Body)]
    public class ChilledBreastplate : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Chilled Breastplate");
            Tooltip.SetDefault("7% increased ranged damage");

        }

        public override void SetDefaults()
        {
            item.CloneDefaults(ItemID.MoltenBreastplate);
            item.rare = ItemRarityID.Orange;
            item.defense = 8; 
        }

        public override void UpdateEquip(Player player)
        {
            player.rangedDamage += 0.07f;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Materials.FroststoneBar>(), 20);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}