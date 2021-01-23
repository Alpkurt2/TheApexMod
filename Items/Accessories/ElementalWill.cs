using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.DataStructures;
using System.Collections.Generic;

namespace TheApexMod.Items.Accessories
{
    public class ElementalWill : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Elemental Will");
            Tooltip.SetDefault("'The Will of the Elements'\nReturns 35% of the contact damage you take back to the attacker.\n10% increased damage and critical strike chance\nIncreases max number of minions by 2.\nGreatly Increased life regen.");
            Main.RegisterItemAnimation(item.type, new DrawAnimationVertical(4, 4));
        }
        public override void ModifyTooltips(List<TooltipLine> list)
        {
            foreach (TooltipLine line2 in list)
            {
                if (line2.mod == "Terraria" && line2.Name == "ItemName")
                {
                    line2.overrideColor = new Color(0, 255, 0);
                }
            }
        }

        public override void SetDefaults()
        {
            item.CloneDefaults(ItemID.PutridScent);
            item.width = 34;
            item.height = 34;
            item.rare = ItemRarityID.Cyan;
            item.value = Item.sellPrice(gold: 25);
            item.defense = 10;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.allDamage += 0.1f;
            player.meleeCrit += 10;
            player.rangedCrit += 10;
            player.magicCrit += 10;
            player.slotsMinions += 2;
            player.lifeRegen += 5;
            player.thorns = .35f;

        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.FleshKnuckles, 1);
            recipe.AddIngredient(ItemID.PutridScent, 1);
            recipe.AddIngredient(ModContent.ItemType<CrystalizedSoul>(), 1);
            recipe.AddIngredient(ModContent.ItemType<TikiEmblem>(), 1);
            recipe.AddIngredient(ItemID.BeetleHusk, 5);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
