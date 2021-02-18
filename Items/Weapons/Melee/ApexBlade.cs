using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using TheApexMod.Buffs;
using TheApexMod.Projectiles;

namespace TheApexMod.Items.Weapons.Melee
{
    public class ApexBlade : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Apex Blade");
            Tooltip.SetDefault("A sword made out of all the others.\nProjectiles when they hit an enemy drop a rain of projectiles");
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
            item.damage = 600;
            item.melee = true;
            item.Size = new Vector2(120f);
            item.useTime = 8;
            item.useAnimation = 8;
            item.useStyle = ItemUseStyleID.SwingThrow;
            item.knockBack = 6.5f;
            item.value = Item.sellPrice(platinum: 1);
            item.rare = ItemRarityID.Purple;
            item.UseSound = SoundID.Item60;
            item.autoReuse = true;
            item.shoot = mod.ProjectileType("ApexSwordProjectile");
            item.shootSpeed = 20f;
            item.scale = 1.25f;
        }
        public override void OnHitNPC(Player player, NPC target, int damage, float knockBack, bool crit)
        {
            target.AddBuff(mod.BuffType("White Flames"), 300);
        }
        public override void MeleeEffects(Player player, Rectangle hitbox)
        {
            if (Main.rand.Next(3) == 0)
                Dust.NewDust(new Vector2(hitbox.X, hitbox.Y), hitbox.Width, hitbox.Height, DustID.AncientLight);
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<DivineWoodSword>());
            recipe.AddIngredient(ItemID.CopperShortsword, 1);
            recipe.AddIngredient(ItemID.SolarEruption, 1);
            recipe.AddIngredient(ItemID.DayBreak, 1);
            recipe.AddIngredient(ModContent.ItemType<SolarRotation>(), 1);
            recipe.AddIngredient(mod.ItemType("RainbowFeather"), 10);
            recipe.AddTile(TileID.LunarCraftingStation);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
