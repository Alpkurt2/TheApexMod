using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using TheApexMod.Projectiles.RangedProjectiles;

namespace TheApexMod.Items.Weapons.Ranged
{
    public class ApexShooter : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Apex Shooter");
            Tooltip.SetDefault("Turns Wooden Arrows into Apex Arrows\nOcasionally fires a shotgun of arrows");

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
            item.noMelee = true;
            item.ranged = true;
            item.Size = new Vector2(120f);
            item.useTime = 8;
            item.useAnimation = 8;
            item.useStyle = ItemUseStyleID.HoldingOut;
            item.knockBack = 4;
            item.value = Item.sellPrice(platinum: 1);
            item.rare = ItemRarityID.Purple;
            item.UseSound = SoundID.Item5;
            item.autoReuse = true;
            item.useAmmo = AmmoID.Arrow;
            item.shoot = ProjectileID.WoodenArrowFriendly;
            item.shootSpeed = 20;
             
        }
        public override void OnHitNPC(Player player, NPC target, int damage, float knockBack, bool crit)
        {
            target.AddBuff(mod.BuffType("White Flames"), 300);

        }
        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            if (type == ProjectileID.WoodenArrowFriendly)
            {
                type = ModContent.ProjectileType<ApexArrow>();
            }
            if (Main.rand.Next(5) == 0)
            {
                int numberProjectiles = 5 + Main.rand.Next(3);
                for (int i = 0; i < numberProjectiles; i++)
                {
                    Vector2 perturbedSpeed = new Vector2(speedX, speedY).RotatedByRandom(MathHelper.ToRadians(10));
                    Projectile.NewProjectile(position.X, position.Y, perturbedSpeed.X, perturbedSpeed.Y, type, damage*2, knockBack, player.whoAmI);
                }
            }
            return true;
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(mod.ItemType("DivineWoodBow"), 1);
            recipe.AddIngredient(ItemID.FlareGun, 1);
            recipe.AddIngredient(ItemID.Phantasm, 1);
            recipe.AddIngredient(ItemID.VortexBeater, 1);
            recipe.AddIngredient(ModContent.ItemType<VortexBlaster>(), 1);
            recipe.AddIngredient(mod.ItemType("RainbowFeather"), 10);
            recipe.AddTile(TileID.LunarCraftingStation);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
