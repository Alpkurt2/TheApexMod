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
    public class PumpkingScythe : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Pumpking's Scythe");
            Tooltip.SetDefault("The scythe taken directly from Pumpking himself.");
        }
        public override void SetDefaults()
        {
            item.damage = 86;
            item.melee = true;
            item.Size = new Vector2(120f);
            item.useTime = 23;
            item.useAnimation = 23;
            item.useStyle = ItemUseStyleID.SwingThrow;
            item.knockBack = 3;
            item.value = Item.sellPrice(gold: 10);
            item.rare = ItemRarityID.Yellow;
            item.UseSound = SoundID.Item71;
            item.autoReuse = true;
            item.shoot = ProjectileID.FlamingScythe;
            item.shootSpeed = 8f;
            item.scale = 2f;
        }
        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            int proj = Projectile.NewProjectile(position.X, position.Y, speedX, speedY, ProjectileID.FlamingScythe, damage, knockBack, player.whoAmI);
            Main.projectile[proj].friendly = true;
            Main.projectile[proj].hostile = false;
            return false;
        }
    }
}
