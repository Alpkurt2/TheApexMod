﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using TheApexMod.Items.Materials;

namespace TheApexMod.Items.Tools
{
    public class ApexAxe : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Apex Axe");
            Tooltip.SetDefault("An axe that can cause massive deforestation around the world");
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
            item.damage = 70;
            item.melee = true;
            item.useTime = 6;
            item.useAnimation = 24;
            item.useStyle = ItemUseStyleID.SwingThrow;
            item.knockBack = 8;
            item.value = Item.sellPrice(gold: 10);
            item.rare = ItemRarityID.Purple;
            item.UseSound = SoundID.Item1;
            item.autoReuse = true;
            item.tileBoost += 15;
            item.axe = 10000 / 5;
            item.scale = 1.5f;

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
            recipe.AddIngredient(ItemID.CopperAxe, 1);
            recipe.AddIngredient(ItemID.LunarHamaxeNebula, 1);
            recipe.AddIngredient(ItemID.LunarHamaxeSolar, 1);
            recipe.AddIngredient(ItemID.LunarHamaxeStardust, 1);
            recipe.AddIngredient(ItemID.LunarHamaxeVortex, 1);
            recipe.AddIngredient(ModContent.ItemType<ApexEssence>(), 1);
            recipe.AddTile(TileID.LunarCraftingStation);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
