
﻿using System;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SpiritMod.Projectiles;

using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpiritMod.Items.Weapon.Swung
{
    public class PalmSword : ModItem
    {
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Oasis Blade");
			Tooltip.SetDefault("Shoots out clusters of poisonous seeds");
		}


        public override void SetDefaults()
        {
            item.width = 54;
            item.height = 54;
            item.rare = 5;

            item.damage = 49;
            item.knockBack = 9;

            item.useStyle = 1;
            item.useTime = item.useAnimation = 35;

            item.melee = true;
            item.autoReuse = true;
            this.projOnSwing = true;

            item.shoot = mod.ProjectileType("GeodeStaveProjectile");
            item.shootSpeed = 9;
            item.UseSound = SoundID.Item1;
            item.value = Terraria.Item.sellPrice(0, 3, 0, 0);
        }
        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            for (int I = 0; I < 3; I++)
            {
                int projectileFired = Projectile.NewProjectile(position.X, position.Y, speedX * (Main.rand.Next(500, 900) / 100), speedY * (Main.rand.Next(500, 900) / 100), ProjectileID.PoisonSeedPlantera, item.damage, item.knockBack, item.owner);
                Main.projectile[projectileFired].friendly = true;
                Main.projectile[projectileFired].GetGlobalProjectile<SpiritGlobalProjectile>(mod).shotFromPalmSword = true;
                Main.projectile[projectileFired].hostile = false;
            }
            return false;
        }
    }
}