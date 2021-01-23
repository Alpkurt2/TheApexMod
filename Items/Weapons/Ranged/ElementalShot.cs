using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace TheApexMod.Items.Weapons.Ranged
{
    public class ElementalShot : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Elemental Shot");
            Tooltip.SetDefault("Fires Arrows, Bullets, Rockets, and Darts\nDoes not work if you don't have every single ammo type.");

        }
        public override void ModifyTooltips(List<TooltipLine> list)
        {
            foreach (TooltipLine line2 in list)
            {
                if (line2.mod == "Terraria" && line2.Name == "ItemName")
                {
                    line2.overrideColor = new Color(0, 255, 0);
                }
            }
        }

        public override void SetDefaults()
        {
            item.damage = 80;
            item.noMelee = true;
            item.ranged = true;
            item.Size = new Vector2(120f);
            item.useTime = 12;
            item.useAnimation = 12;
            item.useStyle = ItemUseStyleID.HoldingOut;
            item.knockBack = 4;
            item.value = Item.sellPrice(gold: 25);
            item.rare = ItemRarityID.Cyan;
            item.UseSound = SoundID.Item5;
            item.autoReuse = true;
            item.useAmmo = AmmoID.Arrow;
            item.shoot = ProjectileID.WoodenArrowFriendly;
            item.shootSpeed = 20;
             
        }
        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            switch (Main.rand.Next(4))
            {
                case 0:
                    item.UseSound = SoundID.Item5;
                    item.useAmmo = AmmoID.Arrow;
                    item.shoot = ProjectileID.WoodenArrowFriendly;
                    break;
                case 1:
                    item.UseSound = SoundID.Item11;
                    item.useAmmo = AmmoID.Bullet;
                    item.shoot = ProjectileID.Bullet;
                    break;
                case 2:
                    item.UseSound = SoundID.Item99;
                    item.useAmmo = AmmoID.Dart;
                    item.shoot = ProjectileID.PoisonDartBlowgun;
                    break;
                case 3:
                    item.UseSound = SoundID.Item92;
                    item.useAmmo = AmmoID.Rocket;
                    item.shoot = ProjectileID.RocketI;
                    break;

            }
            return true;
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.DartRifle, 1);
            recipe.AddIngredient(ItemID.DartPistol, 1);
            recipe.AddIngredient(ItemID.DaedalusStormbow, 1);
            recipe.AddIngredient(ModContent.ItemType<CoconutGun>(), 1);
            recipe.AddIngredient(ItemID.BeetleHusk, 5);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
