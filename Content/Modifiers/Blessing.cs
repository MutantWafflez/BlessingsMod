using BlessingsMod.Custom.Interfaces;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;

namespace BlessingsMod.Content.Modifiers {

    /// <summary>
    /// Class that can be extended to create a new type of Blessing.
    /// </summary>
    public abstract class Blessing : IModifier {
        public virtual string BlessingDisplayName => null;

        public virtual string BlessingDescription => null;

        public virtual void PlayerBadLifeRegen(Player player) { }

        public virtual bool PlayerConsumeAmmo(Player player, Item weapon, Item ammo) => true;

        public virtual void PlayerGetWeaponCrit(Player player, Item item, ref int crit) { }

        public virtual void PlayerGetWeaponKnockback(Player player, Item item, ref float knockback) { }

        public virtual void PlayerHealLife(Player player, Item item, bool quickHeal, ref int healValue) { }

        public virtual void PlayerHealMana(Player player, Item item, bool quickHeal, ref int healValue) { }

        public virtual void PlayerHitAnything(Player player, float x, float y, Entity victim) { }

        public virtual void PlayerHitNPC(Player player, Item item, NPC target, int damage, float knockback, bool crit) { }

        public virtual void PlayerHitNPCWithProjectile(Player player, Projectile proj, NPC target, int damage, float knockback, bool crit) { }

        public virtual void PlayerHurt(Player player, bool pvp, bool quiet, double damage, int hitDirection, bool crit) { }

        public virtual void PlayerKill(Player player, double damage, int hitDirection, bool pvp, PlayerDeathReason damageSource) { }

        public virtual void PlayerLifeRegen(Player player) { }

        public virtual void PlayerMeleeEffects(Player player, Item item, Rectangle hitbox) { }

        public virtual float PlayerMeleeSpeed(Player player, Item item) => 0f;

        public virtual void PlayerModifyHitByNPC(Player player, NPC npc, ref int damage, ref bool crit) { }

        public virtual void PlayerModifyHitByProjectile(Player player, Projectile proj, ref int damage, ref bool crit) { }

        public virtual void PlayerModifyHitNPC(Player player, Item item, NPC target, ref int damage, ref float knockback, ref bool crit) { }

        public virtual void PlayerModifyHitNPCWithProj(Player player, Projectile proj, NPC target, ref int damage, ref float knockback, ref bool crit, ref int hitDirection) { }

        public virtual void PlayerModifyManaCost(Player player, Item item, ref float reduce, ref float mult) { }

        public virtual bool PlayerModifyNurseHeal(Player player, NPC nurse, ref int health, ref bool removeDebuffs, ref string chatText) => true;

        public virtual void PlayerModifyNursePrice(Player player, NPC nurse, int health, bool removeDebuffs, ref int price) { }

        public virtual void PlayerModifyWeaponDamage(Player player, Item item, ref float add, ref float mult, ref float flat) { }

        public virtual void PlayerNaturalLifeRegen(Player player, ref float regen) { }

        public virtual void PlayerOnConsumeAmmo(Player player, Item weapon, Item ammo) { }

        public virtual void PlayerOnHitByNPC(Player player, NPC npc, int damage, bool crit) { }

        public virtual void PlayerOnHitByProjectile(Player player, Projectile proj, int damage, bool crit) { }

        public virtual void PlayerOnManaConsume(Player player, Item item, int manaConsumed) { }

        public virtual void PlayerOnMissingMana(Player player, Item item, int neededMana) { }

        public virtual void PlayerPostHurt(Player player, bool pvp, bool quiet, double damage, int hitDirection, bool crit) { }

        public virtual void PlayerPostItemCheck(Player player) { }

        public virtual void PlayerPostNurseHeal(Player player, NPC nurse, int health, bool removeDebuffs, int price) { }

        public virtual void PlayerPostUpdate(Player player) { }

        public virtual void PlayerPostUpdateBuffs(Player player) { }

        public virtual void PlayerPostUpdateEquips(Player player) { }

        public virtual void PlayerPostUpdateMiscEffects(Player player) { }

        public virtual void PlayerPostUpdateRunSpeeds(Player player) { }

        public virtual bool PlayerPreHurt(Player player, bool pvp, bool quiet, ref int damage, ref int hitDirection, ref bool crit, ref bool customDamage, ref bool playSound, ref bool genGore, ref PlayerDeathReason damageSource) => true;

        public virtual bool PlayerPreItemCheck(Player player) => true;

        public virtual bool PlayerPreKill(Player player, double damage, int hitDirection, bool pvp, ref bool playSound, ref bool genGore, ref PlayerDeathReason damageSource) => true;

        public virtual void PlayerPreUpdate(Player player) { }

        public virtual void PlayerPreUpdateBuffs(Player player) { }

        public virtual void PlayerPreUpdateMovement(Player player) { }

        public virtual bool PlayerShoot(Player player, Item item, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack) => true;

        public virtual float PlayerUseTime(Player player, Item item) => 0f;
    }
}