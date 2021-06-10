using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using TheApexMod.Items.Materials;

namespace TheApexMod.Items.Weapons.Melee
{
    public class GalactaSword : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Galacta Sword");
            Tooltip.SetDefault("The planets gravitate towards this behemoth of a sword.");

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
            item.damage = 250;
            item.melee = true;
            item.Size = new Vector2(120f);
            item.useTime = 12;
            item.useAnimation = 12;
            item.useStyle = ItemUseStyleID.SwingThrow;
            item.knockBack = 6;
            item.value = Item.sellPrice(platinum: 1);
            item.rare = ItemRarityID.Cyan;
            item.UseSound = SoundID.Item1;
            item.autoReuse = true;
            item.scale = 1.5f;

        }
        public override Vector2? HoldoutOffset()
        {
            return new Vector2(-2f, -4f);
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<DivineFragment>(), 100);
            recipe.AddIngredient(ModContent.ItemType<ApexEssence>(), 5);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
