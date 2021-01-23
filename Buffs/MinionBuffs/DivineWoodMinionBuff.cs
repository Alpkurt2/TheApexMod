using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace TheApexMod.Buffs.MinionBuffs
{
	public class DivineWoodMinionBuff : ModBuff
	{
		public override void SetDefaults()
		{
			DisplayName.SetDefault("Divine Wood Minion");
			Description.SetDefault("A minion combined with the celestial fragments.");
			Main.buffNoSave[Type] = true;
			Main.buffNoTimeDisplay[Type] = true;
		}

		public override void Update(Player player, ref int buffIndex)
		{
			ApexPlayer modPlayer = player.GetModPlayer<ApexPlayer>();
			if (player.ownedProjectileCounts[ModContent.ProjectileType<Projectiles.SummonerProjectiles.DWoodMinion>()] > 0) modPlayer.DMinion = true;
			if (!modPlayer.DMinion)
			{
				player.DelBuff(buffIndex);
				buffIndex--;
			}
			else
			{
				player.buffTime[buffIndex] = 18000;
			}
		}
	}
}
