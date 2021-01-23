using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using TheApexMod.Projectiles.MeleeProjectiles;
using TheApexMod.Projectiles.SkyProjectiles;

namespace TheApexMod.Items.Weapons.Ranged
{
    public class SkyBow : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Sky Bow");
            Tooltip.SetDefault("Turns all Arrows into Giant Feathers");
        }

        public override void SetDefaults()
        {
            item.damage = 600;
            item.noMelee = true;
            item.ranged = true;
            item.Size = new Vector2(120f);
            item.useTime = 1;
            item.useAnimation = 1;
            item.useStyle = ItemUseStyleID.HoldingOut;
            item.knockBack = 0;
            item.value = Item.sellPrice(gold: 25);
            item.rare = ItemRarityID.Red;
            item.UseSound = SoundID.Item5;
            item.autoReuse = true;
            item.shoot = ModContent.ProjectileType<NHSkyFeather>();
            item.shootSpeed = 12f;
        }
    }
}
