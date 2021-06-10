using System;
using Microsoft.Xna.Framework;
using Terraria.GameContent.Events;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using TheApexMod.Items.Materials;
using TheApexMod.Items.Weapons.Magic;
using TheApexMod.Items.Misc;
using TheApexMod.Items.Weapons.Melee;
using TheApexMod.Items.Accessories;
using TheApexMod.Items.Weapons.Ranged;

namespace TheApexMod.NPCs
{
    public class ApexGlobalNPCs : GlobalNPC
    {

        public bool WhiteFlames;
        public bool FOH;
        public override bool InstancePerEntity
        {
            get
            {
                return true;
            }
        }

        public override void ResetEffects(NPC npc)
        {
            WhiteFlames = false;
            FOH = false;
        }
        public override void UpdateLifeRegen(NPC npc, ref int damage)
        {
            Player player = Main.player[Main.myPlayer];
            ApexPlayer modPlayer = player.GetModPlayer<ApexPlayer>();
            if (WhiteFlames)
            {
                if (npc.lifeRegen > 0)
                {
                    npc.lifeRegen = 0;
                }
                npc.lifeRegen -= 200;
                if (damage < 100)
                {
                    damage = 100;
                }

            }
            if (FOH)
            {
                if (npc.lifeRegen > 0)
                {
                    npc.lifeRegen = 0;
                }
                npc.lifeRegen -= 200;
                if (damage < 100)
                {
                    damage = 100;
                }

            }
        }
        public override void DrawEffects(NPC npc, ref Color drawColor)
        {
            if (WhiteFlames)
            {
                if (Main.rand.Next(4) < 3)
                {
                    int dust = Dust.NewDust(npc.position - new Vector2(2f, 2f), npc.width + 4, npc.height + 4, DustID.AncientLight, npc.velocity.X * 0.4f, npc.velocity.Y * 0.4f, 100, default(Color), 3.5f);
                    Main.dust[dust].noGravity = true;
                    Main.dust[dust].velocity *= 1.8f;
                    Main.dust[dust].velocity.Y -= 0.5f;
                    if (Main.rand.Next(4) == 0)
                    {
                        Main.dust[dust].noGravity = false;
                        Main.dust[dust].scale *= 0.5f;
                    }
                }
                Lighting.AddLight(npc.position, 0.1f, 0.2f, 0.7f);
            }
            if (FOH)
            {
                if (Main.rand.Next(4) < 3)
                {
                    int dust = Dust.NewDust(npc.position - new Vector2(2f, 2f), npc.width + 4, npc.height + 4, DustID.Fire, npc.velocity.X * 0.4f, npc.velocity.Y * 0.4f, 100, default(Color), 3.5f);
                    Main.dust[dust].noGravity = true;
                    Main.dust[dust].velocity *= 1.8f;
                    Main.dust[dust].velocity.Y -= 0.5f;
                    if (Main.rand.Next(4) == 0)
                    {
                        Main.dust[dust].noGravity = false;
                        Main.dust[dust].scale *= 0.5f;
                    }
                }
                Lighting.AddLight(npc.position, 0.1f, 0.2f, 0.7f);
            }
        }
        public override void SetupShop(int type, Chest shop, ref int nextSlot)
        {
            if (type == NPCID.Merchant)
            {
                shop.item[nextSlot].SetDefaults(ItemID.Present);
                shop.item[nextSlot].value = 10000;
                nextSlot++;
                shop.item[nextSlot].SetDefaults(ItemID.GoodieBag);
                shop.item[nextSlot].value = 10000;
                nextSlot++;
            }
            if (type == NPCID.Wizard)
            {
                if (ApexWorld.downedSky == true)
                {
                    shop.item[nextSlot].SetDefaults(ModContent.ItemType<Items.Weapons.Melee.FrontierGreatsword>());
                    nextSlot++;
                }
            }
        }
        public override void NPCLoot(NPC npc)
        {
            Player player = Main.player[npc.lastInteraction];
            ApexPlayer modPlayer = player.GetModPlayer<ApexPlayer>();
            if (npc.type == NPCID.PirateShip)
            {
                if (Main.rand.Next(50) == 0)
                    Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ModContent.ItemType<Stazzler>(), 1);
            }
            if (npc.type == NPCID.BigMimicHallow)
            {
                if (Main.rand.Next(10) == 0)
                    Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ModContent.ItemType<CrystalizedSoul>(), 1);
            }
            if (npc.type == NPCID.DukeFishron)
            {
                if (Main.rand.Next(10) == 0)
                    Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ModContent.ItemType<TheDuke>(), 1);
            }
            if (npc.type == NPCID.BigMimicJungle)
            {
                switch (Main.rand.Next(4))
                {
                    case 0:
                        Item.NewItem(npc.Hitbox, ModContent.ItemType<TikiEmblem>());
                        break;
                    case 1:
                        Item.NewItem(npc.Hitbox, ModContent.ItemType<JunglesResolution>());
                        break;
                    case 2:
                        Item.NewItem(npc.Hitbox, ModContent.ItemType<CoconutGun>());
                        break;
                    case 3:
                        Item.NewItem(npc.Hitbox, ModContent.ItemType<SporeInfestation>());
                        break;
                }

            }
            if (npc.type == NPCID.SnowmanGangsta || npc.type == NPCID.MisterStabby || npc.type == NPCID.SnowBalla)
            {
                if (Main.rand.Next(50) == 0)
                    Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ModContent.ItemType<SnowmanHeart>(), 1);
            }
            if (npc.type == NPCID.GoblinSummoner)
            {
                if (Main.rand.Next(10) == 0)
                    Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ModContent.ItemType<ShadowFlames>(), 1);
            }
            if (npc.type == NPCID.Pumpking)
            {
                if (Main.rand.Next(25) == 0)
                    Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ModContent.ItemType<PumpkingScythe>(), 1);
            }
            if (player.ZoneSkyHeight)
            {
                if (NPC.downedMoonlord)
                {
                    if (Main.rand.Next(350) == 0)
                        Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ModContent.ItemType<MysteriousFeather>(), 1);
                }
            }
            if (player.ZoneSnow)
            {
                if (Main.hardMode)
                {
                    if (Main.rand.Next(100) == 0)
                        Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.SnowGlobe, 1);
                }
            }
        }
    }
}
    
