using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace SpiritMod.Tiles.Block
{
    public class GraniteOre : ModTile
    {
        public override void SetDefaults()
        {
            Main.tileSpelunker[Type] = true;
            Main.tileSolid[Type] = true;
            Main.tileMergeDirt[Type] = true;
            Main.tileBlockLight[Type] = true;  //true for block to emit light
            Main.tileLighted[Type] = true;
            drop = mod.ItemType("GraniteChunk");   //put your CustomBlock name
				ModTranslation name = CreateMapEntryName();
            name.SetDefault("Enchanted Granite Chunk");
            AddMapEntry(new Color(30, 144, 255), name);
			soundType = 21;
            minPick = 65;
            
        }
        public override void ModifyLight(int i, int j, ref float r, ref float g, ref float b)
        {
            {
                r = 0.63f;
                g = 0.78f;
                b = 1.75f;
            }
        }
    }
}