using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace TheApexMod.Items.Armor
{
    [AutoloadEquip(EquipType.Head)]
    public class ElderWoodHelmet : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Elderwood Helmet");
            Tooltip.SetDefault("A combination of all the wood armors.");
        }

        public override void SetDefaults()
        {
            item.value = Item.sellPrice(silver: 6);
            item.width = 30;
            item.height = 20;
            item.rare = ItemRarityID.Green;
            item.defense = 4;
        }

        public override bool IsArmorSet(Item head, Item body, Item legs)
        {
            return body.type == ModContent.ItemType<ElderWoodBreastplate>() && legs.type == ModContent.ItemType<ElderWoodGreaves>();
        }

        public override void UpdateArmorSet(Player player)
        {
            player.setBonus = @"Increases damage by 5%.";
            player.allDamage += 0.05f;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.WoodHelmet, 1);
            recipe.AddIngredient(ItemID.BorealWoodHelmet, 1);
            recipe.AddIngredient(ItemID.RichMahoganyHelmet, 1);
            recipe.AddIngredient(ItemID.EbonwoodHelmet, 1);
            recipe.AddIngredient(ItemID.PalmWoodHelmet, 1);
            recipe.AddIngredient(ModContent.ItemType<DynastyWoodHelmet>(), 1);
            recipe.AddTile(TileID.WorkBenches);
            recipe.SetResult(this);
            recipe.AddRecipe();

            ModRecipe recipetwo = new ModRecipe(mod);
            recipetwo.AddIngredient(ItemID.WoodHelmet, 1);
            recipetwo.AddIngredient(ItemID.BorealWoodHelmet, 1);
            recipetwo.AddIngredient(ItemID.RichMahoganyHelmet, 1);
            recipetwo.AddIngredient(ItemID.ShadewoodHelmet, 1);
            recipetwo.AddIngredient(ItemID.PalmWoodHelmet, 1);
            recipetwo.AddIngredient(ModContent.ItemType<DynastyWoodHelmet>(), 1);
            recipetwo.AddTile(TileID.WorkBenches);
            recipetwo.SetResult(this);
            recipetwo.AddRecipe();
        }
    }
}