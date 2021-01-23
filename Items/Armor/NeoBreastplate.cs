using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace TheApexMod.Items.Armor
{
    [AutoloadEquip(EquipType.Body)]
    public class NeoBreastplate : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Neo Breastplate");
            Tooltip.SetDefault("10% increased ranged and melee damage");

        }

        public override void SetDefaults()
        {
            item.value = Item.sellPrice(gold: 4);
            item.width = 26;
            item.height = 18;
            item.rare = ItemRarityID.Pink;
            item.defense = 15; 
        }

        public override void UpdateEquip(Player player)
        {
            player.rangedDamage += 0.1f;
            player.meleeDamage += 0.1f;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.MoltenBreastplate, 1);
            recipe.AddIngredient(ModContent.ItemType<ChilledBreastplate>(), 1);
            recipe.AddIngredient(ItemID.SoulofLight, 12);
            recipe.AddIngredient(ItemID.SoulofNight, 12);
            recipe.AddIngredient(ItemID.DarkShard, 1);
            recipe.AddIngredient(ItemID.LightShard, 1);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}