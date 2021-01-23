using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace TheApexMod.Items.Armor
{
    [AutoloadEquip(EquipType.Legs)]
    public class NeoGreaves : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Neo Greaves");
            Tooltip.SetDefault("10% increased ranged and melee damage");
        }

        public override void SetDefaults()
        {
            item.value = Item.sellPrice(gold: 3);
            item.width = 22;
            item.height = 18;
            item.rare = ItemRarityID.Pink;
            item.defense = 12;
        }

        public override void UpdateEquip(Player player)
        {
            player.rangedDamage += 0.1f;
            player.meleeDamage += 0.1f;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.MoltenGreaves, 1);
            recipe.AddIngredient(ModContent.ItemType<ChilledGreaves>(), 1);
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