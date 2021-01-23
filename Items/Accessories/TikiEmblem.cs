using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;
using System.Collections.Generic;
using Microsoft.Xna.Framework;

namespace TheApexMod.Items.Accessories
{
    public class TikiEmblem : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Tiki Emblem");
            Tooltip.SetDefault("Increases max number of minions by 1.\nIncreased life regen.");
        }

        public override void SetDefaults()
        {
            item.CloneDefaults(ItemID.PutridScent);
            item.width = 34;
            item.height = 34;
            item.rare = ItemRarityID.LightPurple;
            item.value = Item.sellPrice(gold: 8);
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.slotsMinions += 1;
            player.lifeRegen += 3;
        }
    }
}
