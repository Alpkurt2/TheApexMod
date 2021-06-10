using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;
using System.Collections.Generic;
using Microsoft.Xna.Framework;

namespace TheApexMod.Items.Accessories
{
    [AutoloadEquip(EquipType.Neck)]
    public class WoodenLocket : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Wooden Locket");
            Tooltip.SetDefault("'Remember the good times'.\nBuffs Every Stat");
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
            sbyte neck = item.neckSlot;
            item.CloneDefaults(ItemID.PanicNecklace);
            item.width = 30;
            item.height = 32;
            item.rare = ItemRarityID.Purple;
            item.value = Item.sellPrice(gold: 5);
            item.neckSlot = neck;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.statDefense += 8;
            player.statLifeMax2 += 50;
            player.magicCrit += 8;
            player.meleeCrit += 8;
            player.rangedCrit += 8;
            player.allDamage += 0.20f;
            player.moveSpeed += 2f;
            player.maxRunSpeed += 2f;
            player.pickSpeed += 0.3f;
            player.meleeSpeed += 0.2f;
            player.minionKB += 2;
            player.maxMinions += 1;

        }
    }
}
