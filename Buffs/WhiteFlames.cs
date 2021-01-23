using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace TheApexMod.Buffs
{
    public class WhiteFlames : ModBuff
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("White Flames");
            Description.SetDefault("You're getting incinerated by white flames");
            Main.debuff[Type] = true;
            Main.pvpBuff[Type] = true;
            Main.buffNoSave[Type] = true;
        }
        public override void Update(Player player, ref int buffIndex)
        {
            player.GetModPlayer<ApexPlayer>().WhiteFlames = true;
        }
        public override void Update(NPC npc, ref int buffIndex)
        {
            if (npc.defense > 0)
            {
                npc.defense = 0;
            }
            if (npc.defDefense > 0)
            {
                npc.defDefense = 0;
            }
            npc.GetGlobalNPC<NPCs.ApexGlobalNPCs>().WhiteFlames = true;
        }
    }
}
