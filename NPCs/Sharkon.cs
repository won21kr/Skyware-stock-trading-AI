using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpiritMod.NPCs
{
    public class Sharkon : ModNPC
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Sharkon");
            Main.npcFrameCount[npc.type] = Main.npcFrameCount[NPCID.Shark];
        }
        public override void SetDefaults()
        {
            npc.width = 118;
            npc.height = 42;
            npc.damage = 60;
            npc.defense = 12;
            npc.lifeMax = 600;
            npc.HitSound = SoundID.NPCHit1;
			npc.DeathSound = SoundID.NPCDeath1;
			npc.noGravity = true;
            npc.value = 60f;
            npc.knockBackResist = .55f;
            npc.aiStyle = 16;
            aiType = NPCID.Shark;
            animationType = NPCID.Shark;
        }

        public override float SpawnChance(NPCSpawnInfo spawnInfo)
        {
            if (spawnInfo.playerSafe || !Main.hardMode)
            {
                return 0f;
            }
            return SpawnCondition.OceanMonster.Chance * 0.07f;
        }
        public override void HitEffect(int hitDirection, double damage)
        {
            for (int i = 0; i < 10; i++) ;
			if (npc.life <= 0)
            {
				Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/Shark_Gore"), 1f);
                Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/Gore_577"), 1f);
				Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/Gore_578"), 1f);
			}
        }
    }
}
