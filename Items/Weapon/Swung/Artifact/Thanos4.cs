using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Graphics.Effects;
using Terraria.Graphics.Shaders;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpiritMod.Items.Weapon.Swung.Artifact
{
    public class Thanos4 : ModItem
    {
        int charger;
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Shard of Thanos");
            Tooltip.SetDefault("'You have become the Artifact Keeper of Thanos'\nShoots out an afterimage of the Shard\nRight-click to summon four storms of rotating crystals around the player\nMelee or afterimage attacks may crystallize enemies, stopping them in place\nHit enemies may release multiple Ancient Crystal Shards\nAttacks with the Shard may cause multiple bolts of Primordial Energy to rain toward the cursor position\n~Artifact Weapon~");

        }


        public override void SetDefaults()
        {
            item.damage = 94;            
            item.melee = true;            
            item.width = 52;              
            item.height = 50;
            item.useTime = 16;
            item.useAnimation = 16;     
            item.useStyle = 1;        
            item.knockBack = 8;
            item.value = Terraria.Item.sellPrice(0, 11, 0, 50);
            item.shoot = mod.ProjectileType("Thanos4Proj");
            item.rare = 10;
            item.shootSpeed = 9f;
            item.UseSound = SoundID.Item69;
            item.autoReuse = true;
            item.useTurn = true;
        }
        public override bool AltFunctionUse(Player player)
        {
            return true;
        }
        public override void MeleeEffects(Player player, Rectangle hitbox)
        {
            if (player.altFunctionUse == 2)
            {
                int dust = Dust.NewDust(new Vector2(hitbox.X, hitbox.Y), hitbox.Width, hitbox.Height, mod.DustType("Crystal"));
                int dust1 = Dust.NewDust(new Vector2(hitbox.X, hitbox.Y), hitbox.Width, hitbox.Height, 187);

            }
            else
            {
                int dust = Dust.NewDust(new Vector2(hitbox.X, hitbox.Y), hitbox.Width, hitbox.Height, 187);
                int dust1 = Dust.NewDust(new Vector2(hitbox.X, hitbox.Y), hitbox.Width, hitbox.Height, mod.DustType("Crystal"));

            }
        }
        public override void OnHitNPC(Player player, NPC target, int damage, float knockBack, bool crit)
        {
            if (Main.rand.Next(12) == 1)
            {
                target.AddBuff(mod.BuffType("Crystallize"), 180);
            }
            if (Main.rand.Next(6) == 1)
            {
                for (int h = 0; h < 6; h++)
                {
                    Vector2 vel = new Vector2(0, -1);
                    float rand = Main.rand.NextFloat() * 6.283f;
                    vel = vel.RotatedBy(rand);
                    vel *= 8f;
                    Projectile.NewProjectile(player.position.X, player.position.Y, vel.X, vel.Y, mod.ProjectileType("AncientCrystal"), 54, 1, player.whoAmI, 0f, 0f);

                }
            }
        }
        public override bool CanUseItem(Player player)
        {
            if (player.altFunctionUse == 2)
            {
                item.damage = 91;
                item.knockBack = 1;
            }
            else
            {
                item.damage = 94;
                item.knockBack = 8;
            }
            return base.CanUseItem(player);
        }
        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            if (player.altFunctionUse == 2)
            {
                Terraria.Projectile.NewProjectile(player.Center.X - 40, player.Center.Y, speedX, speedY, mod.ProjectileType("Thanos1Crystal"), 30, 0, item.owner);
                Terraria.Projectile.NewProjectile(player.Center.X + 40, player.Center.Y, speedX, speedY, mod.ProjectileType("Thanos1Crystal"), 30, 0, item.owner);
                Terraria.Projectile.NewProjectile(player.Center.X + 45, player.Center.Y -45, speedX, speedY, mod.ProjectileType("Thanos1Crystal"), 30, 0, item.owner);
                Terraria.Projectile.NewProjectile(player.Center.X - 45, player.Center.Y +45, speedX, speedY, mod.ProjectileType("Thanos1Crystal"), 30, 0, item.owner);
                Terraria.Projectile.NewProjectile(player.Center.X, player.Center.Y +40, speedX, speedY, mod.ProjectileType("Thanos1Crystal"), 30, 0, item.owner);
                Terraria.Projectile.NewProjectile(player.Center.X, player.Center.Y -40, speedX, speedY, mod.ProjectileType("Thanos1Crystal"), 30, 0, item.owner);

                Terraria.Projectile.NewProjectile(player.Center.X - 40, player.Center.Y, speedX, speedY, mod.ProjectileType("Thanos2Crystal"), 40, 0, item.owner);
                Terraria.Projectile.NewProjectile(player.Center.X + 40, player.Center.Y, speedX, speedY, mod.ProjectileType("Thanos2Crystal"), 40, 0, item.owner);
                Terraria.Projectile.NewProjectile(player.Center.X + 45, player.Center.Y - 45, speedX, speedY, mod.ProjectileType("Thanos2Crystal"), 40, 0, item.owner);
                Terraria.Projectile.NewProjectile(player.Center.X + 45, player.Center.Y - 45, speedX, speedY, mod.ProjectileType("Thanos2Crystal"), 40, 0, item.owner);

                Terraria.Projectile.NewProjectile(player.Center.X - 40, player.Center.Y, speedX, speedY, mod.ProjectileType("Thanos3Crystal"), 60, 0, item.owner);
                Terraria.Projectile.NewProjectile(player.Center.X + 40, player.Center.Y, speedX, speedY, mod.ProjectileType("Thanos3Crystal"), 60, 0, item.owner);
                Terraria.Projectile.NewProjectile(player.Center.X + 45, player.Center.Y - 45, speedX, speedY, mod.ProjectileType("Thanos3Crystal"), 60, 0, item.owner);
                Terraria.Projectile.NewProjectile(player.Center.X + 45, player.Center.Y - 45, speedX, speedY, mod.ProjectileType("Thanos3Crystal"), 60, 0, item.owner);

                Terraria.Projectile.NewProjectile(player.Center.X - 40, player.Center.Y, speedX, speedY, mod.ProjectileType("Thanos4Crystal"), 87, 0, item.owner);
                Terraria.Projectile.NewProjectile(player.Center.X + 40, player.Center.Y, speedX, speedY, mod.ProjectileType("Thanos4Crystal"), 87, 0, item.owner);
                Terraria.Projectile.NewProjectile(player.Center.X + 45, player.Center.Y - 45, speedX, speedY, mod.ProjectileType("Thanos4Crystal"), 87, 0, item.owner);

  

            }
            else
            {
                {
                    return true;

                }
            }
            return false;
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "Thanos3", 1);
            recipe.AddIngredient(null, "RadiantEmblem", 1);
            recipe.AddIngredient(null, "PlanteraBloom", 1);
            recipe.AddIngredient(null, "ApexFeather", 1);
            recipe.AddIngredient(null, "UnrefinedRuneStone", 1);
            recipe.AddIngredient(null, "Catalyst", 1);
            recipe.AddIngredient(null, "PrimordialMagic", 150);
            recipe.AddTile(null, "CreationAltarTile");
            recipe.SetResult(this, 1);
            recipe.AddRecipe();
        }
    }
}