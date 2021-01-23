using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace TheApexMod.Items.Tools
{
    public class ApexPickaxe : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Apex Pickaxe");
            Tooltip.SetDefault("A pickaxe that can break through the heavens above");
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
            item.damage = 47;
            item.melee = true;
            item.useTime = 3;
            item.useAnimation = 15;
            item.useStyle = ItemUseStyleID.SwingThrow;
            item.knockBack = 8;
            item.value = Item.sellPrice(gold: 10);
            item.rare = ItemRarityID.Purple;
            item.UseSound = SoundID.Item1;
            item.autoReuse = true;
            item.tileBoost += 8;
            item.pick = 500;
            item.scale = 1.25f;

            item.width = 20;
            item.height = 20;
        }
        public override void MeleeEffects(Player player, Rectangle hitbox)
        {
            if (Main.rand.Next(3) == 0)
                Dust.NewDust(new Vector2(hitbox.X, hitbox.Y), hitbox.Width, hitbox.Height, DustID.AncientLight);
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.CopperPickaxe, 1);
            recipe.AddIngredient(ItemID.VortexPickaxe, 1);
            recipe.AddIngredient(ItemID.SolarFlarePickaxe, 1);
            recipe.AddIngredient(ItemID.NebulaPickaxe, 1);
            recipe.AddIngredient(ItemID.StardustPickaxe, 1);
            recipe.AddIngredient(mod.ItemType("RainbowFeather"), 5);
            recipe.AddTile(TileID.LunarCraftingStation);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
