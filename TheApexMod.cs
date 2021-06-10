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
using TheApexMod.Items.Materials;

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
                    ModContent.ItemType<Items.Materials.ApexEssence>() 
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
            recipe.AddRecipeGroup(RecipeGroupID.IronBar, 2);
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
            recipe.AddIngredient(ItemID.GoodieBag, 10);
            recipe.AddIngredient(ItemID.Leather, 5);
            recipe.AddRecipeGroup(RecipeGroupID.IronBar, 2);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(ItemID.BladedGlove);
            recipe.AddRecipe();
            recipe = new ModRecipe(this);
            recipe.AddIngredient(ItemID.GoodieBag, 10);
            recipe.AddIngredient(ItemID.WoodenBoomerang, 1);
            recipe.AddRecipeGroup(RecipeGroupID.IronBar, 5);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(ItemID.BloodyMachete);
            recipe.AddRecipe();
            recipe = new ModRecipe(this);
            recipe.AddIngredient(ItemID.BrainOfConfusion, 1);
            recipe.AddTile(TileID.DemonAltar);
            recipe.SetResult(ItemID.WormScarf);
            recipe.AddRecipe();
            recipe = new ModRecipe(this);
            recipe.AddIngredient(ItemID.WormScarf, 1);
            recipe.AddTile(TileID.DemonAltar);
            recipe.SetResult(ItemID.BrainOfConfusion);
            recipe.AddRecipe();
            recipe = new ModRecipe(this);
            recipe.AddIngredient(ItemID.Ichor, 1);
            recipe.AddTile(TileID.DemonAltar);
            recipe.SetResult(ItemID.CursedFlame);
            recipe.AddRecipe();
            recipe = new ModRecipe(this);
            recipe.AddIngredient(ItemID.CursedFlame, 1);
            recipe.AddTile(TileID.DemonAltar);
            recipe.SetResult(ItemID.Ichor);
            recipe.AddRecipe();
            recipe = new ModRecipe(this);
            recipe.AddIngredient(ItemID.TissueSample, 1);
            recipe.AddTile(TileID.DemonAltar);
            recipe.SetResult(ItemID.ShadowScale);
            recipe.AddRecipe();
            recipe = new ModRecipe(this);
            recipe.AddIngredient(ItemID.ShadowScale, 1);
            recipe.AddTile(TileID.DemonAltar);
            recipe.SetResult(ItemID.TissueSample);
            recipe.AddRecipe();
            recipe = new ModRecipe(this);
            recipe.AddIngredient(ItemID.CrimtaneBar, 1);
            recipe.AddTile(TileID.DemonAltar);
            recipe.SetResult(ItemID.DemoniteBar);
            recipe.AddRecipe();
            recipe = new ModRecipe(this);
            recipe.AddIngredient(ItemID.DemoniteBar, 1);
            recipe.AddTile(TileID.DemonAltar);
            recipe.SetResult(ItemID.CrimtaneBar);
            recipe.AddRecipe();

            List<Recipe> rec = Main.recipe.ToList();
            int numberRecipesRemoved = 0;
            numberRecipesRemoved += rec.RemoveAll(x => x.createItem.type == ItemID.AlphabetStatueU);
            rec.Where(x => x.createItem.type == ItemID.TurtleHelmet).ToList().ForEach(s =>
            {
                for (int i = 0; i < s.requiredItem.Length; i++)
                {
                    s.requiredItem[i] = new Item();
                }
                s.requiredItem[0].SetDefaults(ModContent.ItemType<TurtleBar>(), false);
                s.requiredItem[0].stack = 12;

                s.createItem.SetDefaults(ItemID.TurtleHelmet, false);
                s.createItem.stack = 1;
            });
            rec.Where(x => x.createItem.type == ItemID.TurtleLeggings).ToList().ForEach(s =>
            {
                for (int i = 0; i < s.requiredItem.Length; i++)
                {
                    s.requiredItem[i] = new Item();
                }
                s.requiredItem[0].SetDefaults(ModContent.ItemType<TurtleBar>(), false);
                s.requiredItem[0].stack = 18;

                s.createItem.SetDefaults(ItemID.TurtleLeggings, false);
                s.createItem.stack = 1;
            });
            rec.Where(x => x.createItem.type == ItemID.TurtleScaleMail).ToList().ForEach(s =>
            {
                for (int i = 0; i < s.requiredItem.Length; i++)
                {
                    s.requiredItem[i] = new Item();
                }
                s.requiredItem[0].SetDefaults(ModContent.ItemType<TurtleBar>(), false);
                s.requiredItem[0].stack = 24;

                s.createItem.SetDefaults(ItemID.TurtleScaleMail, false);
                s.createItem.stack = 1;
            });
            Main.recipe = rec.ToArray();
            Array.Resize(ref Main.recipe, Recipe.maxRecipes);
            Recipe.numRecipes -= numberRecipesRemoved;
        }
    }
}