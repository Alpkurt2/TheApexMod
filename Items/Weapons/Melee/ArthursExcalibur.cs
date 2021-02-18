using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace TheApexMod.Items.Weapons.Melee
{
    public class ArthursExcalibur : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Arthur's Excalibur");
            Tooltip.SetDefault("The sword from the legends");
        }

        public override void SetDefaults()
        {
            item.damage = 150;
            item.melee = true;
            item.Size = new Vector2(120f);
            item.useTime = 18;
            item.useAnimation = 18;
            item.useStyle = ItemUseStyleID.SwingThrow;
            item.knockBack = 6.5f;
            item.value = Item.sellPrice(gold: 20);
            item.rare = ItemRarityID.Red;
            item.UseSound = SoundID.Item1;
            item.autoReuse = true;
            item.scale = 2f;
        }
        public override void OnHitNPC(Player player, NPC target, int damage, float knockBack, bool crit)
        {
            target.AddBuff(BuffID.Daybreak, 300);
            float x = target.position.X + -1000;
            float y = target.position.Y;
            float velY = 0;
            float velX = 50;
            Projectile.NewProjectile(new Vector2(x, y), new Vector2(velX, velY), mod.ProjectileType("ArthursProjectile"), damage / 2, 0, item.owner);
            float x2 = target.position.X + 1000;
            float velX2 = -50;
            Projectile.NewProjectile(new Vector2(x2, y), new Vector2(velX2, velY), mod.ProjectileType("ArthursProjectile"), damage / 2, 0, item.owner);
        }
        public override void MeleeEffects(Player player, Rectangle hitbox)
        {
            if (Main.rand.Next(3) == 0)
            {
                int dust2 = Dust.NewDust(new Vector2(hitbox.X, hitbox.Y), hitbox.Width, hitbox.Height, DustID.AmberBolt);
                Main.dust[dust2].noGravity = true;
            }
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(mod.ItemType("HeroSword"), 1);
            recipe.AddIngredient(ItemID.Excalibur, 1);
            recipe.AddIngredient(ItemID.Ectoplasm, 15);
            recipe.AddIngredient(ItemID.FragmentSolar, 10);
            recipe.AddIngredient(ItemID.HallowedBar, 10);
            recipe.AddIngredient(ItemID.SoulofMight, 5);
            recipe.AddIngredient(ItemID.SoulofFright, 5);
            recipe.AddIngredient(ItemID.SoulofSight, 5);
            recipe.AddTile(TileID.LunarCraftingStation);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
