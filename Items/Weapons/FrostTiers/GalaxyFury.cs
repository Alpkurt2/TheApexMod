using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using TheApexMod.Items.Materials;
using TheApexMod.Projectiles.RangedProjectiles;

namespace TheApexMod.Items.Weapons.FrostTiers
{
    public class GalaxyFury : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Galaxy Fury");
            Tooltip.SetDefault("Converts Wooden Arrows into Galaxy Arrows.\nHas a 1/5 chance to shoot out a Galaxy Blast");
        }

        public override void SetDefaults()
        {
            item.CloneDefaults(ItemID.MoltenFury);
            item.damage = 80;
            item.noMelee = true;
            item.ranged = true;
            item.useAnimation = 10;
            item.useTime = 10;
            item.useStyle = ItemUseStyleID.HoldingOut;
            item.value = Item.sellPrice(0, 10, 0, 0);
            item.rare = ItemRarityID.Red;
            item.autoReuse = true;
            item.useAmmo = AmmoID.Arrow;
            item.shoot = ProjectileID.WoodenArrowFriendly;

            item.width = 20;
            item.height = 20;
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<NeoFury>(), 1);
            recipe.AddIngredient(ModContent.ItemType<DivineFragment>(), 10);
            recipe.AddTile(TileID.LunarCraftingStation);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            if (type == ProjectileID.WoodenArrowFriendly)
            {
                if (Main.rand.Next(5) == 0)
                {
                    Projectile.NewProjectile(position.X, position.Y, speedX * 1.25f, speedY * 1.25f, ModContent.ProjectileType<BGalaxyBlast>(), damage, knockBack, player.whoAmI);
                    return false;
                }
                else
                {
                    Projectile.NewProjectile(position.X, position.Y, speedX * 1.25f, speedY * 1.25f, ModContent.ProjectileType<GalaxyArrow>(), damage, knockBack, player.whoAmI);
                }
                return false;
            }
            if (Main.rand.Next(5) == 0)
            {
                Projectile.NewProjectile(position.X, position.Y, speedX * 1.25f, speedY * 1.25f, ModContent.ProjectileType<BGalaxyBlast>(), damage, knockBack, player.whoAmI);
                return false;
            }
            return true;
        }
    }
}
