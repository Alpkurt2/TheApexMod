using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace TheApexMod.Tiles
{
	public class FrozenAshTile : ModTile
	{
		public override void SetDefaults()
		{
			TileID.Sets.Ore[Type] = true;
			Main.tileMergeDirt[Type] = true;
			Main.tileSolid[Type] = true;
			Main.tileBlockLight[Type] = true;

			ModTranslation name = CreateMapEntryName();
			name.SetDefault("Frozen Ash");
			AddMapEntry(new Color(117, 117, 143), name);

			dustType = 135;
			drop = ModContent.ItemType<Items.Placeable.Froststone>();
			soundType = SoundID.Dig;
			soundStyle = 1;
			mineResist = 1f;
			minPick = 0;
		}
	}
}