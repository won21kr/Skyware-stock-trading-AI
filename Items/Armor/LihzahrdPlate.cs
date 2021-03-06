using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpiritMod.Items.Armor
{
    [AutoloadEquip(EquipType.Body)]
    public class LihzahrdPlate : ModItem
    {
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Lihzahrd Plate");
            Tooltip.SetDefault("Increased thrown velocity by 15% and movement speed by 15%");

        }

        public override void SetDefaults()
        {
            item.width = 30;
            item.height = 20;
            item.value = 80000;
            item.rare = 7;
            item.defense = 19;
        }

        public override void UpdateEquip(Player player)
        {
            player.moveSpeed += 0.15f;
			player.thrownVelocity += 0.15f;
        }
        public override void AddRecipes()  
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(2766, 18);
            recipe.AddTile(TileID.MythrilAnvil);   
            recipe.SetResult(this, 1);
            recipe.AddRecipe();
        }
    }
}