using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using TheApexMod.Items.Weapons.FrostTiers;
using TheApexMod.Items.Weapons.Ranged;

namespace TheApexMod.Items.Weapons.FrostTiers
{
    public class NeoShuriken : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Neo Shuriken");
            Tooltip.SetDefault("A shuriken made out of fire and a shuriken made out of ice combined into a deadly weapon.");
        }

        public override void SetDefaults()
        {
            item.damage = 45;
            item.ranged = true;
            item.Size = new Vector2(120f);
            item.useTime = 10;
            item.useAnimation = 10;
            item.noUseGraphic = true;
            item.useStyle = ItemUseStyleID.SwingThrow;
            item.knockBack = 0;
            item.value = Item.sellPrice(gold: 10);
            item.rare = ItemRarityID.Pink;
            item.noMelee = true;
            item.UseSound = SoundID.Item1;
            item.autoReuse = true;
            item.shoot = mod.ProjectileType("NeoShurikenProjectile");
            item.shootSpeed = 20f;
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<FlamingShuriken>(), 1);
            recipe.AddIngredient(ModContent.ItemType<FrostburnShuriken>(), 1);
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
