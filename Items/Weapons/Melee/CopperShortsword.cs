using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using TheApexMod.Buffs;
using Terraria.DataStructures;
using TheApexMod.Projectiles;
using Terraria.Localization;
using System.Linq;
using TheApexMod;
using TheApexMod.Projectiles.MeleeProjectiles;
using TheApexMod.Items.Materials;

namespace TheApexMod.Items.Weapons.Melee
{
    public class CopperShortsword : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Copper Shortsword?");
            Tooltip.SetDefault("???");
            Main.RegisterItemAnimation(item.type, new DrawAnimationVertical(4, 6));
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
            for (int k = 0; k < list.Count; k++)
            {
                if (list[k].mod == "Terraria" && list[k].Name == "Damage")
                {
                    list[k].text = "???" + Language.GetTextValue("LegacyTooltip.2");
                }
            }
        }
        public override void SetDefaults()
        {
            item.damage = 2500;
            item.useStyle = ItemUseStyleID.HoldingOut;
            item.useAnimation = 20;
            item.useTime = 20;
            item.shootSpeed = 3.7f;
            item.knockBack = 6.5f;
            item.width = 32;
            item.height = 32;
            item.scale = 1f;
            item.rare = ItemRarityID.Purple;
            item.value = Item.sellPrice(platinum: 5);

            item.melee = true;
            item.noMelee = true;
            item.noUseGraphic = true;
            item.autoReuse = true;

            item.UseSound = SoundID.Item1;
            item.shoot = ModContent.ProjectileType<CopperShortswordP>();
        }
        public override void OnHitNPC(Player player, NPC target, int damage, float knockBack, bool crit)
        {
            target.AddBuff(mod.BuffType("White Flames"), 300);
        }
        public override void MeleeEffects(Player player, Rectangle hitbox)
        {
            if (Main.rand.Next(3) == 0)
                Dust.NewDust(new Vector2(hitbox.X, hitbox.Y), hitbox.Width, hitbox.Height, DustID.AncientLight);
        }
        public override bool CanUseItem(Player player)
        {
            return player.ownedProjectileCounts[item.shoot] < 1;
        }
        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            Vector2 spawn = new Vector2(position.X - 200, position.Y);
            Vector2 speed = Main.MouseWorld - spawn;
            speed.Normalize();
            speed *= 15f;
            Projectile.NewProjectile(spawn, speed * 2, ModContent.ProjectileType<CopperShortswordPR>(), damage*5, 1f, Main.myPlayer);
            for (int i = 0; i < 5; i++)
            {
                Vector2 spawn2 = new Vector2(position.X + Main.rand.Next(-200, 200), position.Y + Main.rand.Next(-100, 100));
                Vector2 speed2 = Main.MouseWorld - spawn2;
                speed2.Normalize();
                speed2 *= 15f;
                Projectile.NewProjectile(spawn2, speed2 * 2, ModContent.ProjectileType<CopperShortswordPRO>(), damage, 1f, Main.myPlayer);
            }
            return true;
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.CopperShortsword, 1);
            recipe.AddIngredient(ModContent.ItemType<ApexEssence>(), 1);
            recipe.AddTile(TileID.LunarCraftingStation);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
