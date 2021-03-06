using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpiritMod.Items.Armor
{
    [AutoloadEquip(EquipType.Body)]
    public class SilkRobe : ModItem
    {

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Silk Robe");
            Tooltip.SetDefault("Increases max number of minions by 1");

        }

        public override void SetDefaults()
        {
            item.width = 32;
            item.height = 30;
            item.value = 12000;
            item.rare = 1;
            item.defense = 2;
        }

        public override void UpdateEquip(Player player)
        {
            player.maxMinions += 1;
        }
        public override void AddRecipes()  
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.Silk, 14);
            recipe.AddIngredient(ItemID.GoldBar, 2);
            recipe.AddTile(TileID.Anvils);   
            recipe.SetResult(this, 1);
            recipe.AddRecipe();
            ModRecipe recipe2 = new ModRecipe(mod);
            recipe2.AddIngredient(ItemID.Silk, 14);
            recipe2.AddIngredient(ItemID.PlatinumBar, 2);
            recipe2.AddTile(TileID.Anvils);
            recipe2.SetResult(this, 1);
            recipe2.AddRecipe();
        }
    }
}