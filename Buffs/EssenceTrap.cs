using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Graphics.Effects;
using Terraria.Graphics.Shaders;
using Terraria.ID;
using SpiritMod.NPCs;
using Terraria.ModLoader;

namespace SpiritMod.Buffs
{
    public class EssenceTrap : ModBuff
    {
        public override void SetDefaults()
        {
            Main.buffNoTimeDisplay[Type] = false;
            DisplayName.SetDefault("Essence Trap");
        }
        public override void Update(NPC npc, ref int buffIndex)
        {
            npc.lifeRegen -= 7;
            npc.GetGlobalNPC<GNPC>(mod).Etrap = true;
            if (Main.rand.Next(3) == 0)
            {
                int dust = Dust.NewDust(npc.position, npc.width, npc.height, 229);                
            }
        }
    }
}