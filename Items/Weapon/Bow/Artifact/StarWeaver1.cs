using Terraria;
using System;
using Terraria.ID;
using System.Diagnostics;
using SpiritMod.Projectiles;
using Microsoft.Xna.Framework;
using Terraria.ModLoader;

namespace SpiritMod.Items.Weapon.Bow.Artifact
{
    public class StarWeaver1 : ModItem
    {
        int charger;
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Star Weaver");
			Tooltip.SetDefault("'A shard of the Cosmos'\nShoots two arrows at once\nRight click to shoot out an explosive Burning Core every two seconds\nEach Burning Core increases in power, resetting at three\n~Artifact Weapon~");
		}

        public override void SetDefaults()
        {
            item.damage = 17;
            item.noMelee = true;
            item.ranged = true;
            item.width = 22;
            item.height = 56;
            item.useTime = 22;
            item.useAnimation = 22;
            item.useStyle = 5;
            item.shoot = 1;
            item.useAmmo = AmmoID.Arrow;
            item.knockBack = 2;
            item.value = Terraria.Item.sellPrice(0, 3, 0, 50);
            item.rare = 2;
            item.UseSound = SoundID.Item5;
            item.autoReuse = false;
            item.useTurn = false;
            item.shootSpeed = 8f;
        }
        public override bool AltFunctionUse(Player player)
        {
            return true;
        }
        public override Vector2? HoldoutOffset()
        {
            return new Vector2(-10, 0);
        }

        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            if (player.altFunctionUse == 2)
            {

                MyPlayer modPlayer = player.GetModPlayer<MyPlayer>(mod);
                modPlayer.shootDelay = 120;
                charger++;
                if (charger >= 1)
                {
                    for (int I = 0; I < 1; I++)
                    {
                        Projectile.NewProjectile(position.X, position.Y, speedX, speedY, mod.ProjectileType("Stars1"), 24, 4, player.whoAmI, 0f, 0f);
                    }
                }
                if (charger >= 2)
                {
                    for (int I = 0; I < 1; I++)
                    {
                        Projectile.NewProjectile(position.X, position.Y, speedX, speedY, mod.ProjectileType("Stars2"), 30, 5, player.whoAmI, 0f, 0f);
                    }
                }
                if (charger >= 3)
                {
                    for (int I = 0; I < 1; I++)
                    {
                        Projectile.NewProjectile(position.X, position.Y - 10, speedX, speedY, mod.ProjectileType("Stars3"), 35, 6, player.whoAmI, 0f, 0f);
                    }
                    charger = 0;
                }
                return false;
            }
            else
            {
                for (int I = 0; I < 2; I++)
                {
                    Projectile.NewProjectile(position.X, position.Y,  speedX + ((float)Main.rand.Next(-102, 102) / 100), speedY + ((float)Main.rand.Next(-102, 102) / 100), type, damage, knockBack, player.whoAmI, 0f, 0f);
                };
            }
            return false;
        }
        public override bool CanUseItem(Player player)
        {
            if (player.altFunctionUse == 2)
            {
                item.useTime = 35;
                item.useAnimation = 35;
                MyPlayer modPlayer = player.GetModPlayer<MyPlayer>(mod);
                if (modPlayer.shootDelay == 0)
                    return true;
                return false;
            }
            else
            {
                item.useTime = 22;
                item.useAnimation = 22;
                return true;
            }
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "OddKeystone", 1);
            recipe.AddIngredient(null, "RootPod", 1);
            recipe.AddIngredient(null, "GildedIdol", 1);
            recipe.AddIngredient(null, "DemonLens", 1);
            recipe.AddIngredient(null, "PrimordialMagic", 50);
            recipe.AddTile(null, "CreationAltarTile");
            recipe.SetResult(this, 1);
            recipe.AddRecipe();
        }
    }
}