using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpiritMod.Projectiles.Magic
{
	public class GeodeStaveProjectile : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Geode Staff Projectile");

        }
        public override void SetDefaults()
		{
			projectile.width = 4;
			projectile.height = 4;
            projectile.alpha = 255;
			projectile.friendly = true;
			projectile.magic = true;
			projectile.penetrate = 1;
			projectile.timeLeft = 1000;
            projectile.light = 0.0f;

        }

		public override void AI()
		{
            projectile.rotation += 0.1f;
            {
                {
                    int dust = Dust.NewDust(projectile.position, projectile.width, projectile.height, 6);
                    int dust1 = Dust.NewDust(projectile.position, projectile.width, projectile.height, 135);
                    int dust2 = Dust.NewDust(projectile.position, projectile.width, projectile.height, 75);
                    Main.dust[dust].noGravity = true;
                    Main.dust[dust].velocity *= 0f;
                    Main.dust[dust].scale = 1.9f;
                    Main.dust[dust1].noGravity = true;
                    Main.dust[dust1].velocity *= 0f;
                    Main.dust[dust1].scale = 1.9f;
                    Main.dust[dust2].noGravity = true;
                    Main.dust[dust2].velocity *= 0f;
                    Main.dust[dust2].scale = 1.9f;
                }
            }
        }

        public override void Kill(int timeLeft)
        {
            {
                 if (Main.rand.Next(2) == 0)
                    {
                        float rotation = (float)(Main.rand.Next(0, 0) * (Math.PI / 180));
                        Vector2 velocity = new Vector2((float)Math.Cos(rotation), (float)Math.Sin(rotation));
                        int proj = Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, velocity.X, velocity.Y, mod.ProjectileType("Blaze"), 13, projectile.owner, 0, 0f);
                        Main.projectile[proj].friendly = true;
                        Main.projectile[proj].hostile = false;
                        Main.projectile[proj].velocity *= 4f;
                    }
                else
                {
                    float rotation = (float)(Main.rand.Next(0, 0) * (Math.PI / 180));
                    Vector2 velocity = new Vector2((float)Math.Cos(rotation), (float)Math.Sin(rotation));
                    int proj = Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, velocity.X, velocity.Y, ProjectileID.CursedFlameFriendly, 13, projectile.owner, 0, 0f);
                    Main.projectile[proj].friendly = true;
                    Main.projectile[proj].hostile = false;
                    Main.projectile[proj].velocity *= 4f;
                }
            }
            for (int i = 0; i < 5; i++)
            {
                int dust = Dust.NewDust(projectile.position, projectile.width, projectile.height, 6);
            }
            Main.PlaySound(0, (int)projectile.position.X, (int)projectile.position.Y);
        }

        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {

            


            if (Main.rand.Next(8) == 0)
            {
                target.AddBuff(BuffID.CursedInferno, 200, true);
                target.AddBuff(BuffID.OnFire, 200, true);
                target.AddBuff(BuffID.Frostburn, 200, true);
            }            
        }
    }
}