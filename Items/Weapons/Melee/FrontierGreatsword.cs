using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using TheApexMod.Buffs;
using TheApexMod.Projectiles;

namespace TheApexMod.Items.Weapons.Melee
{
    public class FrontierGreatsword : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Frontier Greatsword");
            Tooltip.SetDefault("Cool weapon, wonder what game it's from?\nRight Click to True Melee.");
        }
        public override void ModifyTooltips(List<TooltipLine> list)
        {
            foreach (TooltipLine tooltipLine in list)
            {
                if (tooltipLine.mod == "Terraria" && tooltipLine.Name == "ItemName")
                {
                    tooltipLine.overrideColor = new Color(255, 0, 0);
                }
            }
        }
        public override void SetDefaults()
        {
            item.damage = 575;
            item.melee = true;
            item.Size = new Vector2(120f);
            item.useTime = 24;
            item.useAnimation = 24;
            item.useStyle = ItemUseStyleID.HoldingOut;
            item.knockBack = 6.5f;
            item.value = Item.sellPrice(gold: 10);
            item.rare = ItemRarityID.Red;
            item.UseSound = SoundID.Item60;
            item.autoReuse = true;
            item.shoot = mod.ProjectileType("EternityBeam");
            item.shootSpeed = 20f;
            Item.staff[item.type] = true;
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
        public override bool AltFunctionUse(Player player)
        {
            return true;
        }

        public override bool CanUseItem(Player player)
        {
            if (player.altFunctionUse == 2)
            {
                item.useStyle = ItemUseStyleID.SwingThrow;
                item.shoot = ProjectileID.None;
                item.UseSound = SoundID.Item60;
                item.noMelee = false;
                item.damage = 2000;
            }
            else
            {
                item.useStyle = ItemUseStyleID.HoldingOut;
                item.shoot = mod.ProjectileType("EternityBeam");
                item.channel = true;
                item.UseSound = SoundID.Item13;
                item.noMelee = true;
                item.damage = 575;
            }
            return base.CanUseItem(player);
        }
    }
}
