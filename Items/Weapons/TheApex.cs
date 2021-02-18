using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using TheApexMod.Buffs;
using TheApexMod.Items.Weapons.Magic;
using TheApexMod.Items.Weapons.Melee;
using TheApexMod.Items.Weapons.Ranged;
using TheApexMod.Items.Weapons.Summoner;
using TheApexMod.Projectiles;
using Terraria.Localization;
using System.Linq;
using TheApexMod;

namespace TheApexMod.Items.Weapons
{
    public class TheApex : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("The Apex");
            Tooltip.SetDefault("The weapon that stands on top of all");
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
                    list[k].text = "∞" + Language.GetTextValue("LegacyTooltip.2");
                }
            }
            TooltipLine tt = list.FirstOrDefault(x => x.Name == "Damage" && x.mod == "Terraria");
            if (tt != null)
            {
                string[] splitText = tt.text.Split(' ');
                string damageValue = splitText.First();
                string damageWord = splitText.Last();
                tt.text = damageValue + " " + damageWord;
            }
        }
        public virtual void SafeSetDefaults()
        {
        }

        public sealed override void SetDefaults()
        {
            SafeSetDefaults();
            item.damage = 50000; 
            item.melee = false;
            item.ranged = false;
            item.magic = false;
            item.summon = false;
            item.thrown = false;
            item.Size = new Vector2(120f);
            item.useTime = 8;
            item.useAnimation = 8;
            item.crit = 100;
            item.useStyle = ItemUseStyleID.HoldingOut;
            item.knockBack = 8;
            item.value = Item.sellPrice(platinum: 100);
            item.rare = ItemRarityID.Purple;
            item.UseSound = SoundID.Item60;
            item.autoReuse = true;
            item.shoot = mod.ProjectileType("ApexBeam");
            item.shootSpeed = 20f;
            item.channel = true;
            item.UseSound = SoundID.Item13;
            item.noMelee = true;
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
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<ApexBlade>(), 1);
            recipe.AddIngredient(ModContent.ItemType<ApexShooter>(), 1);
            recipe.AddIngredient(ModContent.ItemType<ApexCaster>(), 1);
            recipe.AddIngredient(ModContent.ItemType<ApexStaff>(), 1);
            recipe.AddTile(TileID.LunarCraftingStation);
            recipe.SetResult(this);
            recipe.AddRecipe();
		}
    }
}
