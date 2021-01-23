using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using TheApexMod.Items.Materials;

namespace TheApexMod.Items.Weapons.Magic
{
    public class ElementalCaster : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Elemental Caster");
        }

        public override void ModifyTooltips(List<TooltipLine> list)
        {
            foreach (TooltipLine line2 in list)
            {
                if (line2.mod == "Terraria" && line2.Name == "ItemName")
                {
                    line2.overrideColor = new Color(0, 255, 0);
                }
            }
        }

        public override void SetDefaults()
        {
            item.damage = 80;
            item.noMelee = true;
            item.melee = true;
            item.Size = new Vector2(120f);
            item.useTime = 12;
            item.useAnimation = 12;
            item.useStyle = ItemUseStyleID.HoldingOut;
            item.knockBack = 5.5f;
            item.value = Item.sellPrice(gold: 25);
            item.rare = ItemRarityID.Cyan;
            item.UseSound = SoundID.Item43;
            item.autoReuse = true;
            item.shoot = ProjectileID.ShadowBeamFriendly;
            item.shootSpeed = 15f;
            Item.staff[item.type] = true;

        }
        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            switch (Main.rand.Next(5))
            {
                case 0:
                    item.shoot = ProjectileID.ShadowBeamFriendly;
                    break;
                case 1:
                    item.shoot = ProjectileID.LostSoulFriendly;
                    break;
                case 2:
                    item.shoot = ProjectileID.InfernoFriendlyBolt;
                    break;
                case 3:
                    item.shoot = ProjectileID.FrostBoltStaff;
                    break;
                case 4:
                    item.shoot = ProjectileID.BoulderStaffOfEarth;
                    break;

            }
            return true;
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.SoulDrain, 1);
            recipe.AddIngredient(ItemID.ClingerStaff, 1);
            recipe.AddIngredient(ItemID.CrystalVileShard, 1);
            recipe.AddIngredient(ModContent.ItemType<SporeInfestation>(), 1);
            recipe.AddIngredient(ItemID.BeetleHusk, 5);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
