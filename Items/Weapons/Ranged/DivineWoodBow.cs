using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using TheApexMod.Items.Materials;

namespace TheApexMod.Items.Weapons.Ranged
{
    public class DivineWoodBow : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Divinewood Bow");
            Tooltip.SetDefault("Contains the power of nature itself and imbued with the celestial fragments it makes a deadly weapon. Converts Wooden Arrows into Divinewood Arrows.");
        }

        public override void SetDefaults()
        {
            item.damage = 110;
            item.noMelee = true;
            item.ranged = true;
            item.Size = new Vector2(120f);
            item.UseSound = SoundID.Item5;
            item.useTime = 14;
            item.useAnimation = 14;
            item.useStyle = ItemUseStyleID.HoldingOut;
            item.knockBack = 3;
            item.value = Item.sellPrice(gold: 7);
            item.rare = ItemRarityID.Yellow;
            item.autoReuse = true;
            item.useAmmo = AmmoID.Arrow;
            item.shoot = ProjectileID.WoodenArrowFriendly;
            item.shootSpeed = 20;
             
        }
        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {

            if (type == ProjectileID.WoodenArrowFriendly)
            {
                Projectile.NewProjectile(position.X, position.Y, speedX, speedY, mod.ProjectileType("DivineWoodArrow"), damage, knockBack, player.whoAmI);
                return false;
            }
            return true;
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<PureWoodBow>(), 1);
            recipe.AddIngredient(ModContent.ItemType<DivineFragment>(), 10);
            recipe.AddTile(TileID.LunarCraftingStation);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
