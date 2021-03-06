using System;
using System.Collections.Generic;

using Microsoft.Xna.Framework;

using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpiritMod.Items.Accessory.Artifact
{
    public class MoonSongBlossom : ModItem
    {
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Moonsong Blossom");
            Tooltip.SetDefault("'Curious how it mimics the shimmer and glow of the moon itself'\nRanged Attacks may release a volley of Blossom Arrows toward foes\nBlossom Arrows may inflict 'Moon Burn'\nThe player is occasionally protected by a Blossom Petal, which regenerates every 7 seconds\nIncreases ranged damage by 10% and ranged critical strike chance by 7%\n~Artifact Accessory~");
        }


        public override void SetDefaults()
        {
            item.width = 38;
            item.height = 34;
            item.rare = 6;
            item.value = Item.sellPrice(0, 3, 0, 0);
            item.accessory = true;
        }
        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.rangedDamage += 0.1f;
            player.rangedCrit += 7;
            player.GetModPlayer<MyPlayer>(mod).MoonSongBlossom = true;
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "FrostLotus", 1);
            recipe.AddIngredient(null, "ChaosEmber", 1);
            recipe.AddIngredient(null, "FireLamp", 1);
            recipe.AddIngredient(ItemID.RangerEmblem, 1);
            recipe.AddIngredient(null, "SpiritBar", 5);
            recipe.AddIngredient(null, "PrimordialMagic", 50);
            recipe.AddTile(null, "CreationAltarTile");
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
