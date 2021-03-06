using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Graphics.Effects;
using Terraria.Graphics.Shaders;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpiritMod.Items.Weapon.Swung
{
    public class FaeSaber : ModItem
    {
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Fae Saber");
            Tooltip.SetDefault("Occasionally shoots out multiple bolts of Fairy energy\nFairy energy may inflict 'Holy Light,' reducing enemy damage and defense\nFairy energy splits into multiple Crystal Shards");

        }


        public override void SetDefaults()
        {
            item.damage = 58;            
            item.melee = true;            
            item.width = 40;              
            item.height = 52;
            item.useTime = 25;           
            item.useAnimation = 25;     
            item.useStyle = 1;        
            item.knockBack = 4;
            item.value = Terraria.Item.sellPrice(0, 2, 0, 0);
            item.rare = 7;
            item.UseSound = SoundID.Item1;         
            item.shoot = mod.ProjectileType("Fae1");
            item.shootSpeed = 7f;            
            item.crit = 2;                     
			 item.autoReuse = true;
        }
        public override void MeleeEffects(Player player, Rectangle hitbox)
        {
            {
                if (Main.rand.Next(5) == 0)
                {
                    int dust = Dust.NewDust(new Vector2(hitbox.X, hitbox.Y), hitbox.Width, hitbox.Height, 242);
                }
            }
        }
        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
    {
            if (Main.rand.Next(10) > 6)
            {
                return false;
            }
            else
            {
                for (int I = 0; I < 2; I++)
                {
                    Terraria.Projectile.NewProjectile(position.X, position.Y, speedX * (Main.rand.Next(400, 900) / 100), speedY * (Main.rand.Next(300, 600) / 100), mod.ProjectileType("Fae1"), damage, knockBack, item.owner);
                }

                return false;
            }
	   }
    }
}
