using Terraria;
using System;
using Terraria.ID;
using System.Diagnostics;
using Microsoft.Xna.Framework;
using Terraria.ModLoader;

namespace SpiritMod.NPCs
{
    public class LihzahrdStatue : ModNPC
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Living Lihzahrd Statue");
            Main.npcFrameCount[npc.type] = 16;
        }
        public override void SetDefaults()
        {
            npc.width = 30;
            npc.height = 48;
            npc.damage = 54;
            npc.defense = 22;
            npc.lifeMax = 300;
            npc.HitSound = SoundID.NPCHit4;
			npc.DeathSound = SoundID.NPCDeath6;
            npc.value = 60f;
            npc.knockBackResist = .8f;
            npc.aiStyle = 25;
            aiType = NPCID.Mimic;

        }
        public override float SpawnChance(NPCSpawnInfo spawnInfo)
        {
            if (spawnInfo.playerSafe || !NPC.downedPlantBoss)
            {
                return 0f;
            }
            return SpawnCondition.JungleTemple.Chance * 0.356f;
        }
        public override void HitEffect(int hitDirection, double damage)
        {
            for (int i = 0; i < 10; i++) ;
        }
        public override void FindFrame(int frameHeight)
        {
            npc.frameCounter += 0.15f;
            npc.frameCounter %= Main.npcFrameCount[npc.type];
            int frame = (int)npc.frameCounter;
            npc.frame.Y = frame * frameHeight;
        }
        public override void AI()
        {
            npc.spriteDirection = npc.direction;

            {
                Player target = Main.player[npc.target];
                int distance = (int)Math.Sqrt((npc.Center.X - target.Center.X) * (npc.Center.X - target.Center.X) + (npc.Center.Y - target.Center.Y) * (npc.Center.Y - target.Center.Y));
                if (distance < 320)
                {
                    npc.ai[0]++;
                    if (npc.ai[0] >= 120)
                    {
                        int type = ProjectileID.EyeBeam;
                        int p = Terraria.Projectile.NewProjectile(npc.position.X, npc.position.Y, -(npc.position.X - target.position.X) / distance * 4, -(npc.position.Y - target.position.Y) / distance * 4, type, (int)((npc.damage * .5)), 0);
                        Main.projectile[p].friendly = false;
                        Main.projectile[p].hostile = true;
                        npc.ai[0] = 0;
                    }
                }
            }
        }
        public override bool CheckDead()
        {
            npc.Transform(mod.NPCType("SunElemental"));
            npc.life = npc.lifeMax;
            return false;
        }
        public override void NPCLoot()
        {
            if (Main.rand.Next(4) == 1)
            {
                Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.LunarTabletFragment, 3);
            }
        }
    }
}
