using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using TheApexMod.Items.Materials;
using Terraria.Localization;
using System.Linq;
using TheApexMod.Projectiles.MeleeProjectiles;


namespace TheApexMod.Items.Weapons.Melee
{
    public class Spoon : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Comically Large Spoon");
            Tooltip.SetDefault("'As we can see king Bach has presented a rather large spoon to his friend.\n" +
                "The humor in this video stems from the fact that king Bach would like to consume ice cream but his friend retorts at him saying,\n" +
                "he can only have a spoonful, nothing more. Bach then suddenly changes his expression and body language and reveals he is indeed in possession of a spoon. And not just any spoon,\n" +
                "it is a massive stainless steel spoon. This is funny beacuse you would never expect someone to be casually in possession of a massive spoon to eat ice cream with.\n" +
                "It is completely unorthodox and uncalled for. This is why the video is so humorous and was put on the 2012 Epic Vine Compilation playlist on Youtube'");
        }

        public override void SetDefaults()
        {
            item.damage = 600;
            item.melee = true;
            item.Size = new Vector2(120f);
            item.useTime = 32;
            item.useAnimation = 32;
            item.useStyle = ItemUseStyleID.SwingThrow;
            item.knockBack = 100f;
            item.value = Item.sellPrice(platinum: 1);
            item.rare = ItemRarityID.Red;
            item.UseSound = SoundID.Item1;
            item.autoReuse = true;
            item.scale = 10f;
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.LunarBar, 50);
            recipe.AddTile(TileID.LunarCraftingStation);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
