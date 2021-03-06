using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpiritMod.Projectiles.Thrown.Artifact
{
	public class DeathRot4Proj : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Death Rot");
            ProjectileID.Sets.TrailCacheLength[projectile.type] = 9;
            ProjectileID.Sets.TrailingMode[projectile.type] = 0;

        }
        public override void SetDefaults()
        {
            projectile.width = 12;
            projectile.height = 40;
            projectile.aiStyle = 113;
            projectile.friendly = true;
            projectile.thrown = true;
            projectile.penetrate = 3;
            projectile.timeLeft = 600;
            projectile.alpha = 255;
            projectile.extraUpdates = 1;
            projectile.light = 0;
            aiType = ProjectileID.ThrowingKnife;

        }

        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            if (Main.rand.Next(4) == 0)
                target.AddBuff(mod.BuffType("Necrosis"), 240);
            if (crit && Main.rand.Next(5) == 0)
            {
                Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, 0f, 0f, mod.ProjectileType("RotExplosion1"), 54, projectile.knockBack, projectile.owner, 0f, 0f);
            }
        } 
        public override void AI()
        {
            projectile.tileCollide = true;
            int dust = Dust.NewDust(projectile.position + projectile.velocity, projectile.width, projectile.height, 75, 0f, 0f);
            int dust2 = Dust.NewDust(projectile.position + projectile.velocity, projectile.width, projectile.height, mod.DustType("Pestilence"), 0f, 0f);
            Main.dust[dust].scale = 1.0f;
            Main.dust[dust].noGravity = true;
            Main.dust[dust].velocity *= 0f;
            Main.dust[dust2].scale = 1.0f;
            Main.dust[dust2].noGravity = true;
            Main.dust[dust2].velocity *= 0f;
        }
        public override void Kill(int timeLeft)
        {

            Main.PlaySound(0, (int)projectile.position.X, (int)projectile.position.Y, 1);
            Vector2 vector9 = projectile.position;
            Vector2 value19 = (projectile.rotation - 1.57079637f).ToRotationVector2();
            vector9 += value19 * 16f;
            for (int num257 = 0; num257 < 20; num257++)
            {
                int newDust = Dust.NewDust(vector9, projectile.width, projectile.height, mod.DustType("Pestilence"), 0f, 0f, 0, default(Color), 1f);
                Main.dust[newDust].position = (Main.dust[newDust].position + projectile.Center) / 2f;
                Main.dust[newDust].velocity += value19 * 2f;
                Main.dust[newDust].velocity *= 0.5f;
                Main.dust[newDust].noGravity = true;
                vector9 -= value19 * 8f;
                int newDust1 = Dust.NewDust(vector9, projectile.width, projectile.height, 75, 0f, 0f, 0, default(Color), 1f);
                Main.dust[newDust1].position = (Main.dust[newDust].position + projectile.Center) / 2f;
                Main.dust[newDust1].velocity += value19 * 2f;
                Main.dust[newDust1].velocity *= 0.5f;
                Main.dust[newDust1].noGravity = true;
                vector9 -= value19 * 8f;
            }
            if (Main.rand.Next(4) == 0)
            {
                int n = 2;
                int deviation = Main.rand.Next(0, 300);
                for (int i = 0; i < n; i++)
                {
                    float rotation = MathHelper.ToRadians(270 / n * i + deviation);
                    Vector2 perturbedSpeed = new Vector2(projectile.velocity.X, projectile.velocity.Y).RotatedBy(rotation);
                    perturbedSpeed.Normalize();
                    perturbedSpeed.X *= 5.5f;
                    perturbedSpeed.Y *= 5.5f;
                    Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, perturbedSpeed.X, perturbedSpeed.Y, mod.ProjectileType("PestilentFlame"), 34, 2, projectile.owner);
                }
            }
            Main.PlaySound(4, (int)projectile.position.X, (int)projectile.position.Y, 6);

        }
        public override bool PreDraw(SpriteBatch spriteBatch, Color lightColor)
        {
            Vector2 drawOrigin = new Vector2(Main.projectileTexture[projectile.type].Width * 0.5f, projectile.height * 0.5f);
            for (int k = 0; k < projectile.oldPos.Length; k++)
            {
                Vector2 drawPos = projectile.oldPos[k] - Main.screenPosition + drawOrigin + new Vector2(0f, projectile.gfxOffY);
                Color color = projectile.GetAlpha(lightColor) * ((float)(projectile.oldPos.Length - k) / (float)projectile.oldPos.Length);
                spriteBatch.Draw(Main.projectileTexture[projectile.type], drawPos, null, color, projectile.rotation, drawOrigin, projectile.scale, SpriteEffects.None, 0f);
            }
            return true;
        }
    }
}