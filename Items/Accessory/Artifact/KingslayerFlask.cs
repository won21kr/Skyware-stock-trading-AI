using System;
using System.Collections.Generic;

using Microsoft.Xna.Framework;

using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpiritMod.Items.Accessory.Artifact
{
    public class KingslayerFlask : ModItem
    {
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Kingslayer Flask");
            Tooltip.SetDefault("'It originates from a long line of assassins, thieves, and bandits'\nThrowing attacks have a 20% chance to shoot out a Venom Dagger at foes\nThrowing attacks may inflict 'Kingslayer Venom' to non-boss foes\n'Kingslayer Venom' reduces enemy defense by 25% and enemy damage by 20%\n'Kingslayer Venom' only affects enemies above half health\nIncreases throwing damage and critical strike chance by 7%\n~Artifact Accessory~");
        }


        public override void SetDefaults()
        {
            item.width = 30;
            item.height = 28;
            item.rare = 6;
            item.value = Item.sellPrice(0, 3, 0, 0);
            item.accessory = true;
        }
        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.thrownDamage += 0.07f;
            player.thrownCrit += 7;
            player.GetModPlayer<MyPlayer>(mod).KingSlayerFlask = true;
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "FrostLotus", 1);
            recipe.AddIngredient(null, "ChaosEmber", 1);
            recipe.AddIngredient(null, "FireLamp", 1);
            recipe.AddIngredient(null, "SpiritBar", 5);
            recipe.AddIngredient(null, "ThrowerEmblem", 1);
            recipe.AddIngredient(null, "PrimordialMagic", 50);
            recipe.AddTile(null, "CreationAltarTile");
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
