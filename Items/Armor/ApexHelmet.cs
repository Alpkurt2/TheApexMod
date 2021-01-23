using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using System.Collections.Generic;
using TheApexMod.Projectiles;
using TheApexMod;
using System.Security.Policy;
using Terraria.DataStructures;

namespace TheApexMod.Items.Armor
{
    [AutoloadEquip(EquipType.Head)]
    public class ApexHelmet : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Apex Helmet");
            Tooltip.SetDefault("The final armor.\nIncreases your max number of minions by 2.\nIncreases damage by 20%.\nIncreases critical strike chance by 20%.\nIncreases maximum mana by 100 and reduces mana usage by 20%.\nEnemies are more likely to target you.");
            Main.RegisterItemAnimation(item.type, new DrawAnimationVertical(4, 7));
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
            item.value = Item.sellPrice(platinum: 1);
            item.width = 34;
            item.height = 32;
            item.rare = ItemRarityID.Purple;
            item.defense = 30;
        }
        public override void UpdateEquip(Player player)
        {
            player.maxMinions += 2;
            player.allDamage += 0.2f;
            player.statManaMax2 += 100;
            player.manaCost -= 0.2f;
            player.magicCrit += 20;
            player.meleeCrit += 20;
            player.rangedCrit += 20;
            player.aggro += 400;
        }

        public override bool IsArmorSet(Item head, Item body, Item legs)
        {
            return body.type == ModContent.ItemType<ApexBreastplate>() && legs.type == ModContent.ItemType<ApexGreaves>();
        }
        
        public override void UpdateArmorSet(Player player)
        {
            player.setBonus = "Increases damage by 50%\nGives you a revive.";
            player.allDamage += 0.5f;
            player.GetModPlayer<ApexPlayer>().ApexEffect = true;
            
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<DivineWoodHelmet>(), 1);
            recipe.AddIngredient(ItemID.CopperHelmet, 1);
            recipe.AddIngredient(ItemID.SolarFlareHelmet, 1);
            recipe.AddIngredient(ItemID.NebulaHelmet, 1);
            recipe.AddIngredient(ItemID.StardustHelmet, 1);
            recipe.AddIngredient(ItemID.VortexHelmet, 1);
            recipe.AddIngredient(mod.ItemType("RainbowFeather"), 5);
            recipe.AddTile(TileID.LunarCraftingStation);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}