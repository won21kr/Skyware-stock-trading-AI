using Terraria;
using System;
using Microsoft.Xna.Framework;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpiritMod.Items.Weapon.Magic
{
	public class AdamantiteStaff : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Adamantite Staff");
			Tooltip.SetDefault("Shoots out a cluster of energy that splits into different directions");
		}


		public override void SetDefaults()
		{
			item.damage = 50;
			item.magic = true;
			item.mana = 8;
			item.width = 40;
			item.height = 40;
			item.useTime = 28;
			item.useAnimation = 28;
			item.useStyle = 5;
			Item.staff[item.type] = true;
			item.noMelee = true; 
			item.knockBack = 0;
            item.value = Terraria.Item.sellPrice(0, 1, 0, 0);
            item.rare = 7;
			item.UseSound = SoundID.Item20;
			item.autoReuse = true;
			item.shoot = mod.ProjectileType("AdamantiteStaffProj");
			item.shootSpeed = 30f;
		}
		
		public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.AdamantiteBar, 12);
             recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(this, 1);
            recipe.AddRecipe();
        }
	}
}
