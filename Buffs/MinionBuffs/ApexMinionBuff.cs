using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace TheApexMod.Buffs.MinionBuffs
{
	public class ApexMinionBuff : ModBuff
	{
		public override void SetDefaults()
		{
			DisplayName.SetDefault("Apex Minion");
			Description.SetDefault("A minion full of light that can destroy everything");
			Main.buffNoSave[Type] = true;
			Main.buffNoTimeDisplay[Type] = true;
		}

		public override void Update(Player player, ref int buffIndex)
		{
			ApexPlayer modPlayer = player.GetModPlayer<ApexPlayer>();
			if (player.ownedProjectileCounts[ModContent.ProjectileType<Projectiles.SummonerProjectiles.ApexMinion>()] > 0) modPlayer.AMinion = true;
			if (!modPlayer.AMinion)
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
