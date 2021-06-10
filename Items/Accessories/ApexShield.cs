using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;
using System.Collections.Generic;
using Microsoft.Xna.Framework;

namespace TheApexMod.Items.Accessories
{
    [AutoloadEquip(EquipType.Shield)]
    public class ApexShield : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Apex Shield");
            Tooltip.SetDefault("Immunity to knockback and fire blocks\nImmune to majority of Debuffs\n20% Damage Reduction\n+100 Maximum Health\nAbsorbs 25% of damage done to players on your team when above 25% life\nGives you a dash\nMay confuse nearby enemies after being struck");
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
            sbyte shield = item.shieldSlot;
            item.CloneDefaults(ItemID.AnkhShield);
            item.width = 30;
            item.height = 34;
            item.rare = ItemRarityID.Purple;
            item.value = Item.sellPrice(gold: 25);
            item.shieldSlot = shield;
            item.defense = 10;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.statLifeMax2 += 100;
            player.noKnockback = true;
            player.hasPaladinShield = true;
            player.dash = 2;
            player.fireWalk = true;
            player.endurance += 0.2f;
            player.brainOfConfusion = true;
            player.buffImmune[BuffID.Chilled] = true;
            player.buffImmune[BuffID.Frozen] = true;
            player.buffImmune[BuffID.Stoned] = true;
            player.buffImmune[BuffID.Weak] = true;
            player.buffImmune[BuffID.BrokenArmor] = true;
            player.buffImmune[BuffID.Bleeding] = true;
            player.buffImmune[BuffID.Poisoned] = true;
            player.buffImmune[BuffID.Slow] = true;
            player.buffImmune[BuffID.Confused] = true;
            player.buffImmune[BuffID.Silenced] = true;
            player.buffImmune[BuffID.Cursed] = true;
            player.buffImmune[BuffID.Darkness] = true;

        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.AnkhShield, 1);
            recipe.AddIngredient(ModContent.ItemType<CozyMirror>(), 1);
            recipe.AddIngredient(ItemID.PaladinsShield, 1);
            recipe.AddIngredient(ItemID.EoCShield, 1);
            recipe.AddIngredient(ItemID.WormScarf, 1);
            recipe.AddIngredient(ItemID.BrainOfConfusion, 1);
            recipe.AddIngredient(ModContent.ItemType<Materials.ApexEssence>(), 1);
            recipe.AddTile(TileID.LunarCraftingStation);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
