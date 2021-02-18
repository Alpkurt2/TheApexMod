using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace TheApexMod.Items.Weapons.Ranged
{
    public class SandShark : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Sand Shark");
            Tooltip.SetDefault("Left click to shoot bullets\nRight click to shoot sand\n33% chance to not consume ammo\n'Minisharks sandy brother'");
        }

        public override void SetDefaults()
        {
            item.damage = 23;
            item.noMelee = true;
            item.ranged = true;
            item.Size = new Vector2(120f);
            item.useAnimation = 7;
            item.useTime = 7;
            item.useStyle = ItemUseStyleID.HoldingOut;
            item.knockBack = 1f;
            item.value = Item.sellPrice(gold: 8);
            item.rare = ItemRarityID.LightRed;
            item.UseSound = SoundID.Item11;
            item.autoReuse = true;
            item.useAmmo = AmmoID.Bullet;
            item.shoot = ProjectileID.Bullet;
            item.shootSpeed = 12f;
        }
        public override Vector2? HoldoutOffset()
        {
            return new Vector2(-4.5f, 3);
        }
        public override bool ConsumeAmmo(Player player)
        {
            return Main.rand.Next(3) == 0;
        }
        public override bool AltFunctionUse(Player player)
        {
            return true;
        }

        public override bool CanUseItem(Player player)
        {
            if (player.altFunctionUse == 2)
            {
                item.damage = 32;
                item.useAmmo = AmmoID.Sand;
                item.shoot = ProjectileID.SandBallGun;
                item.useAnimation = 10;
                item.useTime = 10;
                item.knockBack = 5f;
            }
            else
            {
                item.damage = 23;
                item.useAmmo = AmmoID.Bullet;
                item.shoot = ProjectileID.Bullet;
                item.useAnimation = 7;
                item.useTime = 7;
                item.knockBack = 1f;
            }
            return base.CanUseItem(player);
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.Minishark, 1);
            recipe.AddIngredient(ItemID.Sandgun, 1);
            recipe.AddIngredient(ItemID.AncientBattleArmorMaterial, 2);
            recipe.AddIngredient(ItemID.SoulofLight, 12);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
