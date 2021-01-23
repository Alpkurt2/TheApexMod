using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace TheApexMod.Items.Weapons.Magic
{
    public class SporeInfestation : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Spore Infestation");
        }

        public override void SetDefaults()
        {   
            item.damage = 60;
            item.mana = 8;
            item.UseSound = SoundID.Item43;
            item.useStyle = ItemUseStyleID.HoldingOut;
            
            item.useAnimation = 16;
            item.useTime = 16;
            item.width = 40;
            item.height = 40;
          
            item.knockBack = 5.5f;
            item.magic = true;
            item.autoReuse = true;
            item.value = Item.sellPrice(gold: 8);
            item.rare = ItemRarityID.LightPurple;
            item.noMelee = true;
            item.shoot = ProjectileID.SporeTrap;
            item.shootSpeed = 30;
            Item.staff[item.type] = true;
        }
        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {

            if (Main.rand.Next(2) == 0)
            {
                Projectile.NewProjectile(position.X, position.Y, speedX, speedY, ProjectileID.SporeTrap, damage, knockBack, player.whoAmI);
            }
            else
            {
                Projectile.NewProjectile(position.X, position.Y, speedX, speedY, ProjectileID.SporeTrap2, damage, knockBack, player.whoAmI);
            }
            return false;
        }
    }
}
