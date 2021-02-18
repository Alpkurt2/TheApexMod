using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace TheApexMod.Items.Weapons.Ranged
{
    public class TheDuke : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("The Duke");
            Tooltip.SetDefault("50% chance to not consume ammo\nOcasionally fires a bubble\n'Duke Fishron's little brother'");
        }

        public override void SetDefaults()
        {
            item.damage = 38;
            item.noMelee = true;
            item.ranged = true;
            item.Size = new Vector2(120f);
            item.useAnimation = 6;
            item.useTime = 6;
            item.useStyle = ItemUseStyleID.HoldingOut;
            item.knockBack = 1.25f;
            item.value = Item.sellPrice(gold: 5);
            item.rare = ItemRarityID.Yellow;
            item.UseSound = SoundID.Item11;
            item.autoReuse = true;
            item.useAmmo = AmmoID.Bullet;
            item.shoot = ProjectileID.Bullet;
            item.shootSpeed = 12f;
        }
        public override Vector2? HoldoutOffset()
        {
            return new Vector2(-3.5f, 1);
        }
        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            if (Main.rand.Next(5) == 0)
            {
                Projectile.NewProjectile(position.X, position.Y, speedX, speedY, ProjectileID.Bubble, damage * 4, knockBack, player.whoAmI);
                return true;
            }
            return true;
        }
        public override bool ConsumeAmmo(Player player)
        {
            return Main.rand.Next(2) == 0;
        }
    }
}
