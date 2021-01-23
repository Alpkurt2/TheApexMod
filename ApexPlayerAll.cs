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

    public class ApexPlayerAll : ModPlayer
    {
        public static ApexPlayerAll ModPlayer(Player player)
        {
            return player.GetModPlayer<ApexPlayerAll>();
        }
        public int AllCrit;
        public float AllDamageAdd;
        public float AllDamageMult = 1f;
        public float AllKnockback;
        public override void ResetEffects()
        {
            ResetVariables();
        }

        public override void UpdateDead()
        {
            ResetVariables();
        }
        private void ResetVariables()
        {
            AllDamageAdd = 0f;
            AllDamageMult = 1f;
            AllKnockback = 0f;
            AllCrit = 0;
        }
    }
}
    


