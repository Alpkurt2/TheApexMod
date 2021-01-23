using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace TheApexMod.Items.Armor
{
    [AutoloadEquip(EquipType.Head)]
    public class ChilledHelmet : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Chilled Helmet");
            Tooltip.SetDefault("7% increased ranged critical strike chance");
        }

        public override void SetDefaults()
        {
            item.CloneDefaults(ItemID.MoltenHelmet);
            item.rare = ItemRarityID.Orange;
            item.defense = 7;
        }

        public override bool IsArmorSet(Item head, Item body, Item legs)
        {
            return body.type == ModContent.ItemType<ChilledBreastplate>() && legs.type == ModContent.ItemType<ChilledGreaves>();
        }
        public override void UpdateEquip(Player player)
        {
            player.rangedCrit += 7;
        }
        public override void UpdateArmorSet(Player player)
        {
            player.setBonus = @"Increases ranged damage by 10%.";
            player.rangedDamage += 0.1f;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Materials.FroststoneBar>(), 10);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}