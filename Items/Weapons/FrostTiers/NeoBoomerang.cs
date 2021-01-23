using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using TheApexMod.Items.Weapons.FrostTiers;
using TheApexMod.Projectiles.MeleeProjectiles;

namespace TheApexMod.Items.Weapons.FrostTiers
{
    public class NeoBoomerang : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Neo Boomerang");
            Tooltip.SetDefault("A boomerang made out of fire and a boomerang made out of ice combined into a deadly weapon.\nCan shoot out 2 boomerangs at a time.");
        }

        public override void SetDefaults()
        {
            item.damage = 60;
            item.melee = true;
            item.width = 18;
            item.height = 32;
            item.useTime = 12;
            item.useAnimation = 24;
            item.noUseGraphic = true;
            item.useStyle = ItemUseStyleID.SwingThrow;
            item.knockBack = 8;
            item.value = Item.sellPrice(gold: 3);
            item.rare = ItemRarityID.Pink;
            item.noMelee = true;
            item.UseSound = SoundID.Item1;
            item.autoReuse = true;
            item.shoot = ModContent.ProjectileType<NeoBoomerangProjectile>();
            item.shootSpeed = 15;
        }
        public override bool CanUseItem(Player player)
        {
            return player.ownedProjectileCounts[item.shoot] < 2;
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.Flamarang, 1);
            recipe.AddIngredient(ModContent.ItemType<Frostarang>(), 1);
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
