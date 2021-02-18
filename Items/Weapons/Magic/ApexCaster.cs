using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using TheApexMod.Items.Materials;

namespace TheApexMod.Items.Weapons.Magic
{
    public class ApexCaster : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Apex Caster");
            Tooltip.SetDefault("A staff full of light.");
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
            item.mana = 12;
            item.UseSound = SoundID.Item43;
            item.useStyle = ItemUseStyleID.HoldingOut;
            
            item.useAnimation = 8;
            item.useTime = 8;
            item.width = 40;
            item.height = 40;
          
            item.knockBack = 5.5f;
            item.magic = true;
            item.autoReuse = true;
            item.value = Item.sellPrice(platinum: 1);
            item.rare = ItemRarityID.Purple;
            item.noMelee = true;
            item.shoot = mod.ProjectileType("ApexBolt");
            item.shootSpeed = 20;
            Item.staff[item.type] = true;
        }
        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            float numberProjectiles = 10;
            for (int i = 0; i < numberProjectiles; i++)
            {
                Vector2 spawn = new Vector2(position.X + Main.rand.Next(-200, 200), position.Y + Main.rand.Next(-100, 100));
                Vector2 speed = Main.MouseWorld - spawn;
                speed.Normalize();
                speed *= 15f;
                Projectile.NewProjectile(spawn, speed * 2, ModContent.ProjectileType<Projectiles.MagicProjectiles.ApexBolt>(), damage, 1f, Main.myPlayer);
            }
            return false;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<DivineCaster>(), 1);
            recipe.AddIngredient(ItemID.WandofSparking, 1);
            recipe.AddIngredient(ItemID.NebulaArcanum, 1);
            recipe.AddIngredient(ItemID.NebulaBlaze, 1);
            recipe.AddIngredient(ModContent.ItemType<NebulaTome>(), 1);
            recipe.AddIngredient(ModContent.ItemType<RainbowFeather>(), 10);
            recipe.AddTile(TileID.LunarCraftingStation);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
