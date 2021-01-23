using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using TheApexMod.Items.Accessories;
using TheApexMod.Items.Materials;

namespace TheApexMod.Items.Misc
{
	public class SkyBag : ModItem
	{
		public override int BossBagNPC => mod.NPCType("Sky");
        public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Treasure Bag");
			Tooltip.SetDefault("Right click to open.");
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
            item.maxStack = 999;
            item.consumable = true;
            item.rare = ItemRarityID.Purple;
            item.width = 20;
            item.height = 20;
            item.expert = true;
        }
        public override bool CanRightClick()
        {
            return true;
        }
        public override void OpenBossBag(Player player)
        {
            if (Main.rand.Next(5) == 0)
                player.QuickSpawnItem(ModContent.ItemType<Weapons.Melee.SkySword>(), 1);
            if (Main.rand.Next(5) == 0)
                player.QuickSpawnItem(ModContent.ItemType<Weapons.Ranged.SkyBow>(), 1);
            if (Main.rand.Next(5) == 0)
                player.QuickSpawnItem(ModContent.ItemType<Weapons.Magic.SkyCaster>(), 1);

            player.QuickSpawnItem(ModContent.ItemType<WoodenLocket>(), 1);
            player.QuickSpawnItem(ModContent.ItemType<RainbowFeather>(), Main.rand.Next(10,20));

        }
        
    
    }
}