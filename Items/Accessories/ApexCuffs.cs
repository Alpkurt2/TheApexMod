using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using TheApexMod.Items.Materials;
using Terraria.DataStructures;

namespace TheApexMod.Items.Accessories
{
    [AutoloadEquip(EquipType.HandsOn)]
    public class ApexCuffs : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Apex Cuffs");
            Tooltip.SetDefault("Increases pickup range for mana stars\nRestores mana when damaged\nAutomatically use mana potions when needed\nIncreases maximum mana by 100 and reduces mana usage by 50%\n50% increased magic damage\n15% increased magic critical strike chance");
        }
        public override void ModifyTooltips(List<TooltipLine> list)
        {
            foreach (TooltipLine line2 in list)
            {
                if (line2.mod == "Terraria" && line2.Name == "ItemName")
                {
                    line2.overrideColor = new Color(Main.DiscoR, Main.DiscoG, Main.DiscoB);
                }
            }
        }

        public override void SetDefaults()
        {
            sbyte handOn = item.handOnSlot;
            item.CloneDefaults(ItemID.CelestialCuffs);
            item.width = 32;
            item.height = 34;
            item.rare = ItemRarityID.Purple;
            item.value = Item.sellPrice(gold: 20);
            item.handOnSlot = handOn;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.magicDamage += 0.5f;
            player.magicCrit += 15;
            player.statManaMax2 += 100;
            player.manaCost -= 0.5f;
            player.manaMagnet = true;
            player.magicCuffs = true;
            player.manaFlower = true;
            player.GetModPlayer<ApexPlayer>().ApexCuffs = true;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<CelestialEmblemCuffs>(), 1);
            recipe.AddIngredient(ItemID.ManaFlower, 1);
            recipe.AddIngredient(ItemID.SorcererEmblem, 1);
            recipe.AddIngredient(ModContent.ItemType<RainbowFeather>(), 5);
            recipe.AddTile(TileID.TinkerersWorkbench);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
