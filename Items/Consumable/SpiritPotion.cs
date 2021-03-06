using System;

using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpiritMod.Items.Consumable
{
    public class SpiritPotion : ModItem
    {
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Spirit Potion");
			Tooltip.SetDefault("Increases damage and critical strike chance by 5% \n Getting hurt occasionally spawns a damaging bolt to chase enemies");
		}


        public override void SetDefaults()
        {
            item.width = 20; 
            item.height = 30;
            item.rare = 5;
            item.maxStack = 99;

            item.useStyle = 5;
            item.useTime = item.useAnimation = 45;

            item.noMelee = true;
            item.consumable = true;
            item.autoReuse = false;

            item.buffType = mod.BuffType("SpiritBuff");
            item.buffTime = 7200;

            item.UseSound = SoundID.Item3;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "SpiritKoi", 1);
            recipe.AddIngredient(ItemID.SoulofLight, 1);
            recipe.AddIngredient(ItemID.BottledWater, 1);
            recipe.AddTile(TileID.Bottles);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
