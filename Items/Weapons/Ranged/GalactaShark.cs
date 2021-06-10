using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using TheApexMod.Items.Materials;
using TheApexMod.Items.Weapons.FrostTiers;
using TheApexMod.Projectiles.RangedProjectiles;

namespace TheApexMod.Items.Weapons.Ranged
{
    public class GalactaShark : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Galacta Shark");
            Tooltip.SetDefault("100% chance to not consume ammo\n'The shark that is above all of shark-kind'");
        }

        public override void SetDefaults()
        {
            item.damage = 250;
            item.noMelee = true;
            item.ranged = true;
            item.Size = new Vector2(120f);
            item.useAnimation = 1;
            item.useTime = 1;
            item.useStyle = ItemUseStyleID.HoldingOut;
            item.knockBack = 2f;
            item.value = Item.sellPrice(platinum: 10);
            item.rare = ItemRarityID.Purple;
            item.UseSound = SoundID.Item36;
            item.autoReuse = true;
            item.useAmmo = AmmoID.Bullet;
            item.shoot = ProjectileID.Bullet;
            item.shootSpeed = 15f;
        }
        public override Vector2? HoldoutOffset()
        {
            return new Vector2(-3.5f, 1);
        }
        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            int numberProjectiles = 10;
            for (int i = 0; i < numberProjectiles; i++)
            {
                Vector2 perturbedSpeed = new Vector2(speedX, speedY).RotatedByRandom(MathHelper.ToRadians(5));
                Projectile.NewProjectile(position.X, position.Y, perturbedSpeed.X, perturbedSpeed.Y, type, damage, knockBack, player.whoAmI);
            }
            return true;
        }
        public override bool ConsumeAmmo(Player player)
        {
            return false;
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<ShroomiteShark>(), 1);
            recipe.AddIngredient(ModContent.ItemType<SandShark>(), 1);
            recipe.AddIngredient(ModContent.ItemType<TheDuke>(), 1);
            recipe.AddIngredient(ItemID.SDMG, 1);
            recipe.AddIngredient(ModContent.ItemType<ApexEssence>(), 1);
            recipe.AddTile(TileID.LunarCraftingStation);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
