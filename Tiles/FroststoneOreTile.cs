using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace TheApexMod.Tiles
{
	public class FroststoneOreTile : ModTile
	{
		public override void SetDefaults()
		{
			TileID.Sets.Ore[Type] = true;
			Main.tileSpelunker[Type] = true;
			Main.tileValue[Type] = 410;
			Main.tileShine2[Type] = true;
			Main.tileShine[Type] = 200;
			Main.tileMergeDirt[Type] = true;
			Main.tileSolid[Type] = true;
			Main.tileBlockLight[Type] = true;

			ModTranslation name = CreateMapEntryName();
			name.SetDefault("Froststone Ore");
			AddMapEntry(new Color(0, 200, 255), name);

			dustType = 135;
			drop = ModContent.ItemType<Items.Placeable.Froststone>();
			soundType = SoundID.Tink;
			soundStyle = 1;
			mineResist = 3f;
			minPick = 65;
		}
	}
}