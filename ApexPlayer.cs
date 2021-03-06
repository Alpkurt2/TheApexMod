using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Terraria;
using Terraria.DataStructures;
using Terraria.GameInput;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;
using TheApexMod.Buffs;
using TheApexMod.Projectiles;
using TheApexMod.Projectiles.ArmorProjectiles;

namespace TheApexMod
{

    public class ApexPlayer : ModPlayer
    {
        public int constantDamage;

        public bool WhiteFlames;
        public bool FOH;
        public bool RC;

        public bool NatureBand;
        public bool ApexScope;
        public bool ApexGauntlet;
        public bool ApexCuffs;
        public bool ApexScroll;

        public bool WMinion;
        public bool EWMinion;
        public bool PMinion;
        public bool DMinion;
        public bool AMinion;
        public bool FImp;
        public bool NImp;
        public bool GImp;


        public bool PureEffect;
        public bool DivineEffect;
        private int divineCD = 0;
        public bool ApexEffect;
        public int percentDamage;

        public override void ResetEffects()
        {
            PureEffect = false;
            DivineEffect = false;
            ApexEffect = false;
            NatureBand = false;
            ApexScope = false;
            ApexScroll = false;
            ApexGauntlet = false;
            ApexCuffs = false;
        }
        public override void PreUpdate()
        {
            if (WhiteFlames)
            {
                player.statDefense = 0;
                player.endurance = 0;
            }
            if (FOH)
            {
                player.statDefense = -100;
                player.endurance = -100;
            }
            if (DivineEffect && divineCD > 0)
                divineCD--;
        }
        public override void UpdateDead()
        {
            NatureBand = false;
            ApexScope = false;
            ApexGauntlet = false;
            ApexCuffs = false;
            ApexScroll = false;
        }
        public override void FrameEffects()
        {
            if (player.statLife < player.statLifeMax2)
            {
                if (player.lifeRegen > 40)
                {
                    if (NatureBand)
                    {
                        for (int nature = 0; nature < 2; nature++)
                        {
                            int dust = Dust.NewDust(player.position, player.width, player.height, 222, 0f, 0f, 175, default(Color), 1);
                            Main.dust[dust].noGravity = true;
                            Main.dust[dust].velocity *= 0.75f;
                            int rando1 = Main.rand.Next(-40, 41);
                            int rando2 = Main.rand.Next(-40, 41);
                            Main.dust[dust].position.X += rando1;
                            Main.dust[dust].position.Y += rando2;
                            Main.dust[dust].velocity.X = (float)(-rando1) * 0.075f;
                            Main.dust[dust].velocity.Y = (float)(-rando2) * 0.075f;
                        }
                    }
                }
            }
        }
        public override void MeleeEffects(Item item, Rectangle hitbox)
        {
            if (ApexGauntlet == true)
            {
                int dust2 = Dust.NewDust(new Vector2(hitbox.X, hitbox.Y), hitbox.Width, hitbox.Height, DustID.AncientLight);
                Main.dust[dust2].noGravity = true;
            }
        }

        public override bool PreHurt(bool pvp, bool quiet, ref int damage, ref int hitDirection, ref bool crit,
        ref bool customDamage, ref bool playSound, ref bool genGore, ref PlayerDeathReason damageSource)
        {
            if (constantDamage > 0 || percentDamage > 0f)
            {
                int damageFromPercent = (int)(player.statLifeMax2 * percentDamage);
                damage = Math.Max(constantDamage, damageFromPercent);
                customDamage = true;
            }
            return base.PreHurt(pvp, quiet, ref damage, ref hitDirection, ref crit, ref customDamage, ref playSound, ref genGore, ref damageSource);
        }
        public override void OnHitNPC(Item item, NPC target, int damage, float knockback, bool crit)
        {
            OnHitNPCEither(target, damage, knockback, crit);
            if (item.melee)
            {
                if (ApexGauntlet == true)
                {
                    target.AddBuff(ModContent.BuffType<WhiteFlames>(), Main.rand.Next(120, 360));
                }
            }
        }
        public override void OnHitNPCWithProj(Projectile proj, NPC target, int damage, float knockback, bool crit)
        {
            OnHitNPCEither(target, damage, knockback, crit, proj.type);
            if (proj.melee)
            {
                if (ApexGauntlet == true)
                {
                    target.AddBuff(ModContent.BuffType<WhiteFlames>(), Main.rand.Next(120, 360));
                }
            }
        }

        public void OnHitNPCEither(NPC target, int damage, float knockback, bool crit, int projectile = -1)
        {
            if (DivineEffect && divineCD == 0 && projectile != ModContent.ProjectileType<DivineArmorProjectile>() && projectile != mod.ProjectileType("DivineStar"))
            {
                if (Main.myPlayer == player.whoAmI)
                {
                    Vector2 spawn = new Vector2(target.Center.X + Main.rand.Next(-150, 151), target.Center.Y - Main.rand.Next(600, 801));
                    Vector2 speed = target.Center - spawn;
                    speed.Normalize();
                    speed *= 15f;
                    if (Main.rand.Next(3) == 0)
                        Projectile.NewProjectile(spawn, speed * 2, ModContent.ProjectileType<DivineArmorProjectile>(), damage / 3, 1f, Main.myPlayer);

                }
            }
        }
        public override bool ConsumeAmmo(Item weapon, Item ammo)
        {
            if (weapon.ranged)
            {
                if (ApexScope && Main.rand.Next(2) == 0)
                    return false;
            }
            return true;
        }
        public override bool Shoot(Item item, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            if (PureEffect)
            {
                Projectile.NewProjectile(position.X, position.Y, speedX * 1.5f, speedY * 1.5f, mod.ProjectileType("PureWoodSwordProjectile"), damage, knockBack, player.whoAmI);
            }
            return true;
        }
        
        public override bool PreKill(double damage, int hitDirection, bool pvp, ref bool playSound, ref bool genGore, ref PlayerDeathReason damageSource)
        {
            bool revive = true;
            if (player.whoAmI == Main.myPlayer && revive && player.FindBuffIndex(ModContent.BuffType<ReviveCooldown>()) == -1 && ApexEffect)
            {
                player.statLife = player.statLifeMax2;
                player.HealEffect(player.statLifeMax2);
                player.immune = true;
                player.immuneTime = 180;
                player.AddBuff(ModContent.BuffType<ReviveCooldown>(), 10800);
                CombatText.NewText(player.Hitbox, Color.Purple, "You've been revived!");
                revive = false;
                return false;
            }
            return true;
        }
    }
}
    


