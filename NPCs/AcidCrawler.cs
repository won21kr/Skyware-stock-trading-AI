using Terraria;
using System;
using Terraria.ID;
using System.Diagnostics;
using Microsoft.Xna.Framework;
using Terraria.ModLoader;

namespace SpiritMod.NPCs
{
    public class AcidCrawler : ModNPC
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Acid Crawler");
            Main.npcFrameCount[npc.type] = Main.npcFrameCount[NPCID.BlueSlime];
        }
        public override void SetDefaults()
        {
            npc.width = 38;
            npc.height = 28;
            npc.damage = 44;
            npc.defense = 16;
            npc.lifeMax = 320;
            npc.HitSound = SoundID.NPCHit1;
            npc.DeathSound = SoundID.NPCDeath1;
            npc.value = 11239f;
            npc.knockBackResist = .25f;
            npc.aiStyle = 1;
            aiType = NPCID.ToxicSludge;
            animationType = NPCID.BlueSlime;
        }

        public override float SpawnChance(NPCSpawnInfo spawnInfo)
        {
            if (spawnInfo.playerSafe || !Main.hardMode)
            {
                return 0f;
            }
            return SpawnCondition.Cavern.Chance * 0.08f;
        }
        public override void HitEffect(int hitDirection, double damage)
        {
            int dust = Dust.NewDust(new Vector2(npc.position.X, npc.position.Y), npc.width, npc.height, 107, 0f, 0f, 100, default(Color), 2f);

            for (int i = 0; i < 10; i++) ;
            if (npc.life <= 0)
            {
                Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/Acid_Leg"), 1f);
                Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/Acid_Leg"), 1f);
                Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/Acid_Eye"), 1f);
            }
        }
        public override void OnHitPlayer(Player target, int damage, bool crit)
        {
            if (Main.rand.Next(4) == 0)
            {
                target.AddBuff(BuffID.Poisoned, 240);
            }
        }
        public override void NPCLoot()
        {
            if (Main.rand.Next(2) == 1)
                Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("Acid"));
        }
    }
}
