using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace TheApexMod.Buffs
{
    public class ReviveCooldown : ModBuff
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("Revive Cooldown");
            Description.SetDefault("You can't revive anymore");
            Main.debuff[Type] = true;
            Main.pvpBuff[Type] = true;
            Main.buffNoSave[Type] = true;
        }
        public override void Update(Player player, ref int buffIndex)
        {
            player.GetModPlayer<ApexPlayer>().RC = true;
        }
    }
}
