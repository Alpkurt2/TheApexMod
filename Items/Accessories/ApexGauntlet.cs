using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using TheApexMod.Items.Materials;

namespace TheApexMod.Items.Accessories
{
    [AutoloadEquip(EquipType.HandsOn)]
    public class ApexGauntlet : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Apex Gauntlet");
            Tooltip.SetDefault("Gives the user master yoyo skills.\n50% increased melee damage\nInflicts fire damage on attack\n15% increased melee critical strike chance and melee speed");
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
            sbyte handOff = item.handOffSlot;
            item.CloneDefaults(ItemID.FireGauntlet);
            item.width = 26;
            item.height = 30;
            item.rare = ItemRarityID.Purple;
            item.value = Item.sellPrice(gold: 20);
            item.handOnSlot = handOn;
            item.handOffSlot = handOff;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.meleeDamage += 0.5f;
            player.meleeCrit += 15;
            player.meleeSpeed += 0.15f;
            player.counterWeight = 556 + Main.rand.Next(6);
            player.yoyoGlove = true;
            player.yoyoString = true;
            player.GetModPlayer<ApexPlayer>().ApexGauntlet = true;

        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.FireGauntlet, 1);
            recipe.AddIngredient(ItemID.YoyoBag, 1);
            recipe.AddIngredient(ItemID.WarriorEmblem, 1);
            recipe.AddIngredient(ModContent.ItemType<RainbowFeather>(), 5);
            recipe.AddTile(TileID.TinkerersWorkbench);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
