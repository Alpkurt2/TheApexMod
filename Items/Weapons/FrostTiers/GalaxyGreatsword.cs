using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using TheApexMod.Buffs;
using TheApexMod.Items.Weapons.Melee;
using TheApexMod.Projectiles;

namespace TheApexMod.Items.Weapons.FrostTiers
{
    public class GalaxyGreatsword : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Galaxy Greatsword");
        }
        public override void SetDefaults()
        {
            item.damage = 80;
            item.melee = true;
            item.width = 20;
            item.height = 20;
            item.useTime = 18;
            item.useAnimation = 18;
            item.useStyle = ItemUseStyleID.SwingThrow;
            item.knockBack = 6.5f;
            item.value = Item.sellPrice(gold: 10);
            item.rare = ItemRarityID.Red;
            item.UseSound = SoundID.Item1;
            item.scale = 1.4f;
            item.autoReuse = true;
            item.shoot = mod.ProjectileType("GalaxyGP");
            item.shootSpeed = 20f;
        }
        public override void MeleeEffects(Player player, Rectangle hitbox)
        {
            Dust.NewDust(new Vector2(hitbox.X, hitbox.Y), hitbox.Width, hitbox.Height, DustID.Shadowflame, 0f, 0f, 0, default(Color), 1.5f);
        }
        public override void OnHitNPC(Player player, NPC target, int damage, float knockBack, bool crit)
        {
            target.AddBuff(BuffID.ShadowFlame, 300);
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<NeoGreatsword>(), 1);
            recipe.AddIngredient(ModContent.ItemType<Materials.DivineFragment>(), 10);
            recipe.AddTile(TileID.LunarCraftingStation);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
