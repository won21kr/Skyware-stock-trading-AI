using System;

using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpiritMod.Buffs
{
    public class HolyLight : ModBuff
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("Holy Light");

            Main.debuff[Type] = true;
            Main.pvpBuff[Type] = true;
            Main.buffNoTimeDisplay[Type] = false;
        }

        public override void Update(NPC npc, ref int buffIndex)
        {
            npc.defense = (npc.defDefense / 100) * 94;
            npc.damage = (npc.defDamage / 100) * 91;

            Dust.NewDust(npc.position, npc.width, npc.height, 58);
        }
    }
}
