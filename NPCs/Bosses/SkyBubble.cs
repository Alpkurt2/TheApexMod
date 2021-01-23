using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.Enums;
using Terraria.ID;
using Terraria.ModLoader;

namespace TheApexMod.NPCs.Bosses
{
	public class SkyBubble : ModNPC
	{

		public override void SetDefaults()
		{
			npc.CloneDefaults(NPCID.DetonatingBubble);
		}
	}
}

