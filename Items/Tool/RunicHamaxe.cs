using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpiritMod.Items.Tool
{
    public class RunicHamaxe : ModItem
    {
        public override void SetDefaults()
        {
            item.name = "Runic Hamaxe";
            item.width = 44;
            item.height = 40;
            item.value = 10000;
            item.rare = 4;

            item.axe = 16;
            item.hammer = 110;

            item.damage = 30;
            item.knockBack = 6;

            item.useStyle = 1;
            item.useTime = 24;
            item.useAnimation = 24;

            item.melee = true;
            item.useTurn = true;
            item.autoReuse = true;

            item.useSound = 1;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "Rune", 12);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
