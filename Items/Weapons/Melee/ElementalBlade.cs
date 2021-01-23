using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace TheApexMod.Items.Weapons.Melee
{
    public class ElementalBlade : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Elemental Blade");
            Tooltip.SetDefault("Fires a bunch of projectiles\nDoes more damage depending on which projectile is shot");

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
            item.damage = 50;
            item.noMelee = true;
            item.melee = true;
            item.Size = new Vector2(120f);
            item.useTime = 12;
            item.useAnimation = 12;
            item.useStyle = ItemUseStyleID.SwingThrow;
            item.knockBack = 6;
            item.value = Item.sellPrice(gold: 25);
            item.rare = ItemRarityID.Cyan;
            item.UseSound = SoundID.Item1;
            item.autoReuse = true;
            item.shoot = ProjectileID.EnchantedBeam;
            item.shootSpeed = 20;
            item.scale = 1.5f;

        }
        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            switch (Main.rand.Next(5))
            {
                case 0:
                    item.damage = 50;
                    item.shoot = ProjectileID.EnchantedBeam;
                    break;
                case 1:
                    item.damage = 75;
                    item.shoot = ProjectileID.SwordBeam;
                    break;
                case 2:
                    item.damage = 100;
                    item.shoot = ProjectileID.LightBeam;
                    break;
                case 3:
                    item.damage = 100;
                    item.shoot = ProjectileID.NightBeam;
                    break;
                case 4:
                    item.damage = 150;
                    item.shoot = ProjectileID.TerraBeam;
                    break;

            }
            return true;
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.FetidBaghnakhs, 1);
            recipe.AddIngredient(ItemID.ChainGuillotines, 1);
            recipe.AddIngredient(ItemID.FlyingKnife, 1);
            recipe.AddIngredient(ModContent.ItemType<JunglesResolution>(), 1);
            recipe.AddIngredient(ItemID.BeetleHusk, 5);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
