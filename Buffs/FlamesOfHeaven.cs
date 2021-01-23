using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace TheApexMod.Buffs
{
    public class FlamesOfHeaven : ModBuff
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("Flames Of Heaven");
            Description.SetDefault("You're getting incinerated by the flames of the heavens");
            Main.debuff[Type] = true;
            Main.pvpBuff[Type] = true;
            Main.buffNoSave[Type] = true;
        }
        public override void Update(Player player, ref int buffIndex)
        {
            player.GetModPlayer<ApexPlayer>().FOH = true;
        }
        public override void Update(NPC npc, ref int buffIndex)
        {
            if (npc.defense > -20)
            {
                npc.defense = -20;
            }
            if (npc.defDefense > -20)
            {
                npc.defDefense = -20;
            }
            npc.GetGlobalNPC<NPCs.ApexGlobalNPCs>().FOH = true;
        }
    }
}
