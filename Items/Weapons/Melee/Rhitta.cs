using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using TheApexMod.Items.Materials;

namespace TheApexMod.Items.Weapons.Melee
{
    public class Rhitta : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Rhitta");
            Tooltip.SetDefault("A one-handed axe with the power of the sun");
        }

        public override void SetDefaults()
        {
            item.damage = 1500;
            item.melee = true;
            item.Size = new Vector2(120f);
            item.useTime = 50;
            item.useAnimation = 50;
            item.useStyle = ItemUseStyleID.SwingThrow;
            item.knockBack = 8;
            item.value = Item.sellPrice(gold: 25);
            item.rare = ItemRarityID.Red;
            item.UseSound = SoundID.Item60;
            item.autoReuse = true;
            item.shoot = mod.ProjectileType("CruelSun");
            item.shootSpeed = 20;
        }
        public override void OnHitNPC(Player player, NPC target, int damage, float knockBack, bool crit)
        {
            target.AddBuff(mod.BuffType("FlamesOfHeaven"), 300);
        }
        public override void MeleeEffects(Player player, Rectangle hitbox)
        {
            if (Main.rand.Next(3) == 0)
                Dust.NewDust(new Vector2(hitbox.X, hitbox.Y), hitbox.Width, hitbox.Height, DustID.Fire);
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.LunarHamaxeSolar, 1);
            recipe.AddIngredient(ModContent.ItemType<ApexEssence>(), 2);
            recipe.AddTile(TileID.LunarCraftingStation);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
