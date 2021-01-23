using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace TheApexMod.Items.Armor
{
    [AutoloadEquip(EquipType.Head)]
    public class NeoHelmet : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Neo Helmet");
            Tooltip.SetDefault("10% increased ranged and melee critical strike chance");
        }

        public override void SetDefaults()
        {
            item.value = Item.sellPrice(gold: 3);
            item.width = 20;
            item.height = 18;
            item.rare = ItemRarityID.Pink;
            item.defense = 14;
        }

        public override bool IsArmorSet(Item head, Item body, Item legs)
        {
            return body.type == ModContent.ItemType<NeoBreastplate>() && legs.type == ModContent.ItemType<NeoGreaves>();
        }
        public override void UpdateEquip(Player player)
        {
            player.rangedCrit += 10;
            player.meleeCrit += 10;
        }
        public override void UpdateArmorSet(Player player)
        {
            player.setBonus = @"Increases melee and ranged damage by 15%. Gives you immunity to every fire debuff.";
            player.rangedDamage += 0.15f;
            player.meleeDamage += 0.15f;
            player.buffImmune[39] = true;
            player.buffImmune[24] = true;
            player.buffImmune[44] = true;
            player.buffImmune[153] = true;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.MoltenHelmet, 1);
            recipe.AddIngredient(ModContent.ItemType<ChilledHelmet>(), 1);
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