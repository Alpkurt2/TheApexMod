using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using TheApexMod.Items.Materials;

namespace TheApexMod.Items.Weapons.Melee
{
    public class EAHE : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Enchanted Arthur's Hero Excalibur");
            Tooltip.SetDefault("A hero named Arthur's legendary blade.");
        }

        public override void SetDefaults()
        {
            item.damage = 500;
            item.melee = true;
            item.Size = new Vector2(120f);
            item.useTime = 10;
            item.useAnimation = 10;
            item.useStyle = ItemUseStyleID.SwingThrow;
            item.knockBack = 6f;
            item.value = Item.sellPrice(gold: 20);
            item.rare = ItemRarityID.Purple;
            item.UseSound = SoundID.Item60;
            item.autoReuse = true;
            item.shoot = mod.ProjectileType("AHeroSwordProjectile");
            item.shootSpeed = 20;
            item.scale = 2;
        }
        public override void MeleeEffects(Player player, Rectangle hitbox)
        {
            if (Main.rand.Next(3) == 0)
            {
                int dust2 = Dust.NewDust(new Vector2(hitbox.X, hitbox.Y), hitbox.Width, hitbox.Height, 135);
                int dust3 = Dust.NewDust(new Vector2(hitbox.X, hitbox.Y), hitbox.Width, hitbox.Height, DustID.AmberBolt);
                Main.dust[dust2].noGravity = true;
                Main.dust[dust3].noGravity = true;
            }
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<EnchantedHeroSword>(), 1);
            recipe.AddIngredient(ModContent.ItemType<ArthursExcalibur>(), 1);
            recipe.AddIngredient(ItemID.LunarBar, 10);
            recipe.AddIngredient(ModContent.ItemType<ApexEssence>(), 1);
            recipe.AddTile(TileID.LunarCraftingStation);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
