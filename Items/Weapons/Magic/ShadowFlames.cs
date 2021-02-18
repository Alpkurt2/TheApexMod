using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace TheApexMod.Items.Weapons.Magic
{
    public class ShadowFlames : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Shadow Flames");
            Tooltip.SetDefault("A book imbued with the power of shadowflame.");
        }

        public override void SetDefaults()
        {
            item.damage = 54;
            item.magic = true;
            item.Size = new Vector2(120f);
            item.useTime = 16;
            item.useAnimation = 16;
            item.useStyle = ItemUseStyleID.HoldingOut;
            item.knockBack = 6.5f;
            item.value = Item.sellPrice(gold: 2);
            item.rare = ItemRarityID.Pink;
            item.UseSound = SoundID.Item8;
            item.autoReuse = true;
            item.shoot = mod.ProjectileType("ShadowFlameBolt");
            item.shootSpeed = 11;
            item.noMelee = true;
            item.mana = 13;
        }
    }
}
