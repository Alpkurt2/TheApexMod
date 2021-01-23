using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using TheApexMod.Items.Materials;

namespace TheApexMod.Items.Weapons.Ranged
{
    public class SantasFury : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Santa's Fury");
            Tooltip.SetDefault("POV: You were put in the naughty list");
        }

        public override void SetDefaults()
        {
            item.damage = 32;
            item.noMelee = true;
            item.ranged = true;
            item.Size = new Vector2(120f);
            item.useAnimation = 14;
            item.useTime = 14;
            item.useStyle = ItemUseStyleID.HoldingOut;
            item.knockBack = 2;
            item.value = Item.sellPrice(gold: 10);
            item.rare = ItemRarityID.Cyan;
            item.UseSound = SoundID.Item36;
            item.autoReuse = true;
            item.shoot = ModContent.ProjectileType<Projectiles.RangedProjectiles.CoalProj>();
            item.shootSpeed = 30;

        }
        public override Vector2? HoldoutOffset()
        {
            return new Vector2(-3.5f, 0);
        }

        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            int numberProjectiles = 3 + Main.rand.Next(2); // 4 or 5 shots
            for (int i = 0; i < numberProjectiles; i++)
            {
                Vector2 perturbedSpeed = new Vector2(speedX, speedY).RotatedByRandom(MathHelper.ToRadians(10));
                Projectile.NewProjectile(position.X, position.Y, perturbedSpeed.X, perturbedSpeed.Y, type, damage, knockBack, player.whoAmI);
            }
            return true;
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Rydin>(), 1);
            recipe.AddIngredient(ModContent.ItemType<SnowballCannonEX>(), 1);
            recipe.AddIngredient(ModContent.ItemType<Materials.NaughtyEssence>(), 1);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
