using TheApexMod.Items;
using TheApexMod.NPCs;
using TheApexMod.Tiles;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using System.IO;
using Terraria;
using Terraria.DataStructures;
using Terraria.GameContent.Generation;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;
using Terraria.World.Generation;

namespace TheApexMod
{
    public class ApexWorld : ModWorld
    {
        public static bool downedSky;
        public override void Initialize()
        {
            downedSky = false;
        }
        public override TagCompound Save()
        {
            List<string> downed = new List<string>();
            if (downedSky) downed.Add("downedSky");

            return new TagCompound
            {
                 {"downed", downed}
            };
        }
        public override void Load(TagCompound tag)
        {
            IList<string> downed = tag.GetList<string>("downed");
            downedSky = downed.Contains("downedSky");
        }
        public override void LoadLegacy(BinaryReader reader)
        {
            int loadVersion = reader.ReadInt32();
            if (loadVersion == 0)
            {
                BitsByte flags = reader.ReadByte();
                downedSky = flags[0];
            }
        }

        public override void NetSend(BinaryWriter writer)
        {
            BitsByte flags = new BitsByte();
            flags[0] = downedSky;
            writer.Write(flags);
        }
        public override void NetReceive(BinaryReader reader)
        {
            BitsByte flags = reader.ReadByte();
            downedSky = flags[0];
        }

        public override void ModifyWorldGenTasks(List<GenPass> tasks, ref float totalWeight)
        {
            int ShiniesIndex = tasks.FindIndex(genpass => genpass.Name.Equals("Shinies"));
            if (ShiniesIndex != -1)
            {
                tasks.Insert(ShiniesIndex + 1, new PassLegacy("Apex Mod Ores", ApexModOres));
            }

        }
        public void ApexModOres(GenerationProgress progress)
        {
            progress.Message = "Apex Mod Ores";
            for (int k = 0; k < (int)((Main.maxTilesX * Main.maxTilesY) * 6E-05); k++)
            {
                int x = WorldGen.genRand.Next(0, Main.maxTilesX);
                int y = WorldGen.genRand.Next((int)WorldGen.rockLayerLow, Main.maxTilesY);
                Tile tile = Framing.GetTileSafely(x, y);
                if (tile.active() && tile.type == TileID.IceBlock)
                {
                	WorldGen.TileRunner(x, y, WorldGen.genRand.Next(3, 6), WorldGen.genRand.Next(2, 6), ModContent.TileType<FroststoneOreTile>());
                }
            }
        }
    }
}