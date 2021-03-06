using System.Collections.Generic;
using Microsoft.Xna.Framework;
using System;
using System;
using System.Linq;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpiritMod.NPCs.Spirit
{
    public class SoulCrusher : ModNPC
    {
        int frame = 0;
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Soul Crusher");
            Main.npcFrameCount[npc.type] = 7;
        }
        public override void SetDefaults()
        {
            npc.width = 64;
            npc.height = 52;
            npc.damage = 35;
            npc.defense = 15;
            npc.lifeMax = 250;
            npc.HitSound = SoundID.NPCHit3;
			npc.DeathSound = SoundID.NPCDeath6;
            npc.value = 60f;
            npc.knockBackResist = .35f;
            npc.noGravity = true;
            npc.noTileCollide = true;
        }
        public override void NPCLoot()
        {
            Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("SpiritOre"), Main.rand.Next(3) + 2);

        }
        public override float SpawnChance(NPCSpawnInfo spawnInfo)
        {
            int[] TileArray2 = { mod.TileType("SpiritDirt"), mod.TileType("SpiritStone"), mod.TileType("Spiritsand"), mod.TileType("SpiritGrass"), mod.TileType("SpiritIce"), };
           return TileArray2.Contains(Main.tile[spawnInfo.spawnTileX, spawnInfo.spawnTileY].type) && NPC.downedMechBossAny && spawnInfo.spawnTileY > (Main.rockLayer + 150) ? 1.09f : 0f;
        }
        public override void HitEffect(int hitDirection, double damage)
        {
            if (npc.life <= 0)
            {
                Gore.NewGore(npc.position, npc.velocity, 13);
                Gore.NewGore(npc.position, npc.velocity, 12);
                Gore.NewGore(npc.position, npc.velocity, 11);
            }
        }

        public override void FindFrame(int frameHeight)
        {
            npc.frameCounter += .07f;
            npc.frameCounter %= Main.npcFrameCount[npc.type];
            frame = (int)npc.frameCounter;
            npc.frame.Y = frame * frameHeight;
        }
        public override bool PreAI()
        {
            Lighting.AddLight((int)((npc.position.X + (float)(npc.width / 2)) / 16f), (int)((npc.position.Y + (float)(npc.height / 2)) / 16f), 0.05f, 0.05f, 0.4f);
            npc.TargetClosest(true);
            Vector2 direction = Main.player[npc.target].Center - npc.Center;
            npc.rotation = direction.ToRotation();
            direction.Normalize();
            npc.velocity *= 0.98f;
            int dust2 = Dust.NewDust(npc.position + npc.velocity, npc.width, npc.height, 206, npc.velocity.X * 0.5f, npc.velocity.Y * 0.5f);
            Main.dust[dust2].noGravity = true;
          
            if (frame == 0)
            {
                    direction.X = direction.X * Main.rand.Next(10, 15);
                    direction.Y = direction.Y * Main.rand.Next(10, 15);
                    npc.velocity.X = direction.X;
                    npc.velocity.Y = direction.Y;
            }
            return false;

        }
    }
}
