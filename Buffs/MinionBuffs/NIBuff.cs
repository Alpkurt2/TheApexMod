using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace TheApexMod.Buffs.MinionBuffs
{
	public class NIBuff : ModBuff
	{
		public override void SetDefaults()
		{
			DisplayName.SetDefault("Neo Imp");
			Description.SetDefault("This Neo Imp will fight for you");
			Main.buffNoSave[Type] = true;
			Main.buffNoTimeDisplay[Type] = true;
		}

		public override void Update(Player player, ref int buffIndex)
		{
			ApexPlayer modPlayer = player.GetModPlayer<ApexPlayer>();
			if (player.ownedProjectileCounts[ModContent.ProjectileType<Projectiles.SummonerProjectiles.NeoImp>()] > 0) modPlayer.NImp = true;
			if (!modPlayer.NImp)
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
