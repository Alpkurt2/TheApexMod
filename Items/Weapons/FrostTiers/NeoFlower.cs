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
    public class NeoFlower : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Neo Flower");
        }
        public override void SetDefaults()
        {
            item.CloneDefaults(ItemID.FlowerofFrost);
            item.damage = 65;
            item.useTime = 16;
            item.useAnimation = 16;
            item.useStyle = ItemUseStyleID.SwingThrow;
            item.knockBack = 6.5f;
            item.value = Item.sellPrice(gold: 1);
            item.rare = ItemRarityID.Pink;
            item.UseSound = SoundID.Item20;
            item.scale = 1.4f;
            item.autoReuse = true;
            item.shoot = mod.ProjectileType("NFlowerProj");
            item.shootSpeed = 8f;
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.FlowerofFire, 1);
            recipe.AddIngredient(ItemID.FlowerofFrost, 1);
            recipe.AddIngredient(ItemID.SoulofLight, 12);
            recipe.AddIngredient(ItemID.SoulofNight, 12);
            recipe.AddIngredient(ItemID.DarkShard, 1);
            recipe.AddIngredient(ItemID.LightShard, 1);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
