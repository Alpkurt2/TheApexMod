using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;
using System.Collections.Generic;
using Microsoft.Xna.Framework;

namespace TheApexMod.Items.Accessories
{
    public class CrystalizedSoul : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Crystalized Soul");
            Tooltip.SetDefault("Returns 25% of the contact damage you take back to the attacker.");
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
            player.thorns = .25f;
        }
    }
}
