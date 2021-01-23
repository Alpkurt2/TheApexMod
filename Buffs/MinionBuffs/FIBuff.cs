using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace TheApexMod.Buffs.MinionBuffs
{
	public class FIBuff : ModBuff
	{
		public override void SetDefaults()
		{
			DisplayName.SetDefault("Frozen Imp");
			Description.SetDefault("This frozen imp will fight for you");
			Main.buffNoSave[Type] = true;
			Main.buffNoTimeDisplay[Type] = true;
		}

		public override void Update(Player player, ref int buffIndex)
		{
			ApexPlayer modPlayer = player.GetModPlayer<ApexPlayer>();
			if (player.ownedProjectileCounts[ModContent.ProjectileType<Projectiles.SummonerProjectiles.FrozenImp>()] > 0) modPlayer.FImp = true;
			if (!modPlayer.FImp)
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
