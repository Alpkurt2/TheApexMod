using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using TheApexMod.Items.Materials;

namespace TheApexMod.Items.Weapons.Melee
{
    public class DivineWoodSword : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Divinewood Sword");
            Tooltip.SetDefault("Contains the power of nature itself and imbued with the celestial fragments it makes a deadly weapon. Spawns stars from the Sky when you strike an enemy.");
        }

        public override void SetDefaults()
        {
            item.damage = 120;
            item.melee = true;
            item.Size = new Vector2(120f);
            item.useTime = 14;
            item.useAnimation = 14;
            item.useStyle = ItemUseStyleID.SwingThrow;
            item.knockBack = 4;
            item.value = Item.sellPrice(gold: 10);
            item.rare = ItemRarityID.Red;
            item.UseSound = SoundID.Item60;
            item.autoReuse = true;
            item.shoot = mod.ProjectileType("DivineWoodSwordProjectile");
            item.shootSpeed = 20;
        }
        public override void OnHitNPC(Player player, NPC target, int damage, float knockBack, bool crit)
        {
            target.AddBuff(BuffID.ShadowFlame, 300);
        }
        public override void MeleeEffects(Player player, Rectangle hitbox)
        {
            if (Main.rand.Next(3) == 0)
                Dust.NewDust(new Vector2(hitbox.X, hitbox.Y), hitbox.Width, hitbox.Height, DustID.PinkFlame);
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<PureWoodSword>(), 1);
            recipe.AddIngredient(ModContent.ItemType<DivineFragment>(), 10);
            recipe.AddTile(TileID.LunarCraftingStation);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
