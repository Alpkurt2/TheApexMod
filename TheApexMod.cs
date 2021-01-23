using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ReLogic.Graphics;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using Terraria;
using Terraria.Graphics;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ModLoader.Config;
using Terraria.UI;
using Terraria.UI.Chat;

namespace TheApexMod
{
    public class TheApexMod : Mod
    {
        public override void PostSetupContent()
        {
            Mod bossChecklist = ModLoader.GetMod("BossChecklist");
            if (bossChecklist != null)
            {
                bossChecklist.Call(
                    "AddBoss",
                    14.01f,
                    ModContent.NPCType<NPCs.Bosses.Sky>(),
                    this,
                    "Sky",
                    (Func<bool>)(() => ApexWorld.downedSky),
                    ModContent.ItemType<Items.Misc.MysteriousFeather>(),
                    new List<int> { },
                    new List<int> 
                    { 
                    ModContent.ItemType<Items.Placeable.SkyTrophy>(), 
                    ModContent.ItemType<Items.Weapons.Melee.SkySword>(),  
                    ModContent.ItemType<Items.Weapons.Ranged.SkyBow>() ,
                    ModContent.ItemType<Items.Weapons.Magic.SkyCaster>(), 
                    ModContent.ItemType<Items.Materials.RainbowFeather>() 
                    },
                    "Spawn by using [i:" + ModContent.ItemType<Items.Misc.MysteriousFeather>() + "].",
                    "This bird is happy to have been able to play with you.",
                    "TheApexMod/NPCs/Bosses/Sky_Still",
                    "TheApexMod/NPCs/Bosses/Sky_Head_Boss"
                );
            }
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(this);
            recipe.AddIngredient(ItemID.Wood, 20);
            recipe.AddIngredient(ItemID.IronBar, 2);
            recipe.AddTile(TileID.WorkBenches);
            recipe.SetResult(ItemID.WoodenBoomerang);
            recipe.AddRecipe();
            recipe = new ModRecipe(this);
            recipe.AddIngredient(ItemID.Wood, 20);
            recipe.AddIngredient(ItemID.LeadBar, 2);
            recipe.AddTile(TileID.WorkBenches);
            recipe.SetResult(ItemID.WoodenBoomerang);
            recipe.AddRecipe();
            recipe = new ModRecipe(this);
            recipe.AddIngredient(ItemID.BlueHorseshoeBalloon, 1);
            recipe.AddIngredient(ItemID.WhiteHorseshoeBalloon, 1);
            recipe.AddIngredient(ItemID.YellowHorseshoeBalloon, 1);
            recipe.AddTile(TileID.TinkerersWorkbench);
            recipe.SetResult(ItemID.BundleofBalloons);
            recipe.AddRecipe();
            recipe = new ModRecipe(this);
            recipe.AddIngredient(ItemID.HellstoneBar, 10);
            recipe.AddIngredient(ItemID.MagicMissile, 1);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(ItemID.Flamelash);
            recipe.AddRecipe();
        }
    }
}