using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using TheApexMod.Items.Materials;

namespace TheApexMod.Items.Weapons.Ranged
{
    public class CoconutGun : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Coconut Gun");
            Tooltip.SetDefault("DK! DONKEY KONG!");
        }

        public override void SetDefaults()
        {
            item.damage = 115;
            item.noMelee = true;
            item.ranged = true;
            item.Size = new Vector2(120f);
            item.useAnimation = 29;
            item.useTime = 29;
            item.useStyle = ItemUseStyleID.HoldingOut;
            item.knockBack = 4;
            item.value = Item.sellPrice(gold: 8);
            item.rare = ItemRarityID.LightPurple;
            item.UseSound = SoundID.Item36;
            item.autoReuse = true;
            item.shoot = ModContent.ProjectileType<Projectiles.RangedProjectiles.CoconutProj>();
            item.shootSpeed = 30;

        }
        public override Vector2? HoldoutOffset()
        {
            return new Vector2(-3f, -1);
        }
    }
}
