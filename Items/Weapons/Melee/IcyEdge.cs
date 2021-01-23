using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace TheApexMod.Items.Weapons.Melee
{
    public class IcyEdge : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Icy Edge");
            Tooltip.SetDefault("A blade looted from the chests of the deep snow upgraded with concentrated snow.");
        }

        public override void SetDefaults()
        {
            item.damage = 46;
            item.melee = true;
            item.Size = new Vector2(120f);
            item.useTime = 16;
            item.useAnimation = 16;
            item.useStyle = ItemUseStyleID.SwingThrow;
            item.knockBack = 5;
            item.value = Item.sellPrice(gold: 8);
            item.rare = ItemRarityID.Pink;
            item.UseSound = SoundID.Item28;
            item.autoReuse = true;
            item.shoot = ModContent.ProjectileType<Projectiles.MeleeProjectiles.IceEP>();
            item.shootSpeed = 15;
        }
        public override void MeleeEffects(Player player, Rectangle hitbox)
        {
            if (Main.rand.Next(3) == 0)
                Dust.NewDust(new Vector2(hitbox.X, hitbox.Y), hitbox.Width, hitbox.Height, 135);
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.IceBlade, 1);
            recipe.AddIngredient(ModContent.ItemType<Materials.ConcentratedSnow>(), 1);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
