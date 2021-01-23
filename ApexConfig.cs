using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.IO;
using Terraria;
using Terraria.DataStructures;
using Terraria.GameContent.Generation;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;
using Terraria.ModLoader.Config;
using Terraria.ModLoader.Config.UI;

namespace TheApexMod
{
    class ApexConfig : ModConfig
    {
        public override ConfigScope Mode => ConfigScope.ClientSide;
        public static ApexConfig Instance;
        private void SetAll(bool val)
        {
            IEnumerable<FieldInfo> configs = typeof(ApexConfig).GetFields(BindingFlags.Public | BindingFlags.Instance).Where(i => i.FieldType == true.GetType());
            foreach (FieldInfo config in configs)
            {
                config.SetValue(this, val);
            }
        }
        
        [Label("Apex Scope")]
        [DefaultValue(true)]
        public bool ApexScope;
    }
}