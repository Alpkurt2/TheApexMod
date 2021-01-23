using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace TheApexMod.Buffs.MinionBuffs
{
	public class WoodMinionBuff : ModBuff
	{
		public override void SetDefaults()
		{
			DisplayName.SetDefault("Wood Minion");
			Description.SetDefault("The Wood Minion will fight for you");
			Main.buffNoSave[Type] = true;
			Main.buffNoTimeDisplay[Type] = true;
		}

		public override void Update(Player player, ref int buffIndex)
		{
			ApexPlayer modPlayer = player.GetModPlayer<ApexPlayer>();
			if (player.ownedProjectileCounts[ModContent.ProjectileType<Projectiles.SummonerProjectiles.WoodMinion>()] > 0) modPlayer.WMinion = true;
			if (!modPlayer.WMinion)
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
