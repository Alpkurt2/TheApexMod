using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;
using System.Collections.Generic;
using Microsoft.Xna.Framework;

namespace TheApexMod.Items.Accessories
{
    [AutoloadEquip(EquipType.HandsOn)]
    public class CelestialEmblemCuffs : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Celestial Emblem Cuffs");
            Tooltip.SetDefault("Increases pickup range for mana stars.\nRestores mana when damaged.\nIncreases maximum mana by 40\n20% increased magic damage ");
        }

        public override void SetDefaults()
        {
            sbyte handOn = item.handOnSlot;
            item.CloneDefaults(ItemID.CelestialCuffs);
            item.width = 32;
            item.height = 34;
            item.rare = ItemRarityID.Lime;
            item.value = Item.sellPrice(gold: 6);
            item.handOnSlot = handOn;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.magicDamage += 0.2f;
            player.statManaMax2 += 40;
            player.manaMagnet = true;
            player.magicCuffs = true;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.CelestialEmblem, 1);
            recipe.AddIngredient(ItemID.CelestialCuffs, 1);
            recipe.AddIngredient(ItemID.Ectoplasm, 10);
            recipe.AddTile(TileID.TinkerersWorkbench);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
