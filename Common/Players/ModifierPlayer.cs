using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ModLoader;

namespace BlessingsMod.Common.Players {

    /// <summary> ModPlayer that handles all the modifications (Blesings & Curses) that apply to
    /// players. </summary>
    public class ModifierPlayer : ModPlayer {

        #region Hurt & Kill Hooks

        public override bool PreHurt(bool pvp, bool quiet, ref int damage, ref int hitDirection, ref bool crit, ref bool customDamage, ref bool playSound, ref bool genGore, ref PlayerDeathReason damageSource) {
            bool returnPreHurt = base.PreHurt(pvp, quiet, ref damage, ref hitDirection, ref crit, ref customDamage, ref playSound, ref genGore, ref damageSource);
            for (int i = 0; i < BlessingsMod.activeModifiers.Count; i++) {
                if (!BlessingsMod.activeModifiers[i].PlayerPreHurt(player, pvp, quiet, ref damage, ref hitDirection, ref crit, ref customDamage, ref playSound, ref genGore, ref damageSource)) {
                    returnPreHurt = false;
                }
            }
            return returnPreHurt;
        }

        public override void Hurt(bool pvp, bool quiet, double damage, int hitDirection, bool crit) {
            for (int i = 0; i < BlessingsMod.activeModifiers.Count; i++) {
                BlessingsMod.activeModifiers[i].PlayerHurt(player, pvp, quiet, damage, hitDirection, crit);
            }
        }

        public override void PostHurt(bool pvp, bool quiet, double damage, int hitDirection, bool crit) {
            for (int i = 0; i < BlessingsMod.activeModifiers.Count; i++) {
                BlessingsMod.activeModifiers[i].PlayerPostHurt(player, pvp, quiet, damage, hitDirection, crit);
            }
        }

        public override bool PreKill(double damage, int hitDirection, bool pvp, ref bool playSound, ref bool genGore, ref PlayerDeathReason damageSource) {
            bool returnPreKill = base.PreKill(damage, hitDirection, pvp, ref playSound, ref genGore, ref damageSource);
            for (int i = 0; i < BlessingsMod.activeModifiers.Count; i++) {
                if (!BlessingsMod.activeModifiers[i].PlayerPreKill(player, damage, hitDirection, pvp, ref playSound, ref genGore, ref damageSource)) {
                    returnPreKill = false;
                }
            }
            return returnPreKill;
        }

        public override void Kill(double damage, int hitDirection, bool pvp, PlayerDeathReason damageSource) {
            for (int i = 0; i < BlessingsMod.activeModifiers.Count; i++) {
                BlessingsMod.activeModifiers[i].PlayerKill(player, damage, hitDirection, pvp, damageSource);
            }
        }

        #endregion

        #region Update Hooks

        public override void PreUpdate() {
            for (int i = 0; i < BlessingsMod.activeModifiers.Count; i++) {
                BlessingsMod.activeModifiers[i].PlayerPreUpdate(player);
            }
        }

        public override void PreUpdateBuffs() {
            for (int i = 0; i < BlessingsMod.activeModifiers.Count; i++) {
                BlessingsMod.activeModifiers[i].PlayerPreUpdateBuffs(player);
            }
        }

        public override void PreUpdateMovement() {
            for (int i = 0; i < BlessingsMod.activeModifiers.Count; i++) {
                BlessingsMod.activeModifiers[i].PlayerPreUpdateMovement(player);
            }
        }

        public override void PostUpdateBuffs() {
            for (int i = 0; i < BlessingsMod.activeModifiers.Count; i++) {
                BlessingsMod.activeModifiers[i].PlayerPostUpdateBuffs(player);
            }
        }

        public override void PostUpdateEquips() {
            for (int i = 0; i < BlessingsMod.activeModifiers.Count; i++) {
                BlessingsMod.activeModifiers[i].PlayerPostUpdateEquips(player);
            }
        }

        public override void PostUpdateMiscEffects() {
            for (int i = 0; i < BlessingsMod.activeModifiers.Count; i++) {
                BlessingsMod.activeModifiers[i].PlayerPostUpdateMiscEffects(player);
            }
        }

        public override void PostUpdateRunSpeeds() {
            for (int i = 0; i < BlessingsMod.activeModifiers.Count; i++) {
                BlessingsMod.activeModifiers[i].PlayerPostUpdateRunSpeeds(player);
            }
        }

        public override void PostUpdate() {
            for (int i = 0; i < BlessingsMod.activeModifiers.Count; i++) {
                BlessingsMod.activeModifiers[i].PlayerPostUpdate(player);
            }
        }

        public override void UpdateLifeRegen() {
            for (int i = 0; i < BlessingsMod.activeModifiers.Count; i++) {
                BlessingsMod.activeModifiers[i].PlayerLifeRegen(player);
            }
        }

        public override void NaturalLifeRegen(ref float regen) {
            for (int i = 0; i < BlessingsMod.activeModifiers.Count; i++) {
                BlessingsMod.activeModifiers[i].PlayerNaturalLifeRegen(player, ref regen);
            }
        }

        public override void UpdateBadLifeRegen() {
            for (int i = 0; i < BlessingsMod.activeModifiers.Count; i++) {
                BlessingsMod.activeModifiers[i].PlayerBadLifeRegen(player);
            }
        }

        #endregion

        #region Item Effect Hooks

        public override bool Shoot(Item item, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack) {
            bool returnShoot = base.Shoot(item, ref position, ref speedX, ref speedY, ref type, ref damage, ref knockBack);
            for (int i = 0; i < BlessingsMod.activeModifiers.Count; i++) {
                if (!BlessingsMod.activeModifiers[i].PlayerShoot(player, item, ref position, ref speedX, ref speedY, ref type, ref damage, ref knockBack)) {
                    returnShoot = false;
                }
            }
            return returnShoot;
        }

        public override void GetWeaponCrit(Item item, ref int crit) {
            for (int i = 0; i < BlessingsMod.activeModifiers.Count; i++) {
                BlessingsMod.activeModifiers[i].PlayerGetWeaponCrit(player, item, ref crit);
            }
        }

        public override void GetWeaponKnockback(Item item, ref float knockback) {
            for (int i = 0; i < BlessingsMod.activeModifiers.Count; i++) {
                BlessingsMod.activeModifiers[i].PlayerGetWeaponKnockback(player, item, ref knockback);
            }
        }

        public override void ModifyWeaponDamage(Item item, ref float add, ref float mult, ref float flat) {
            for (int i = 0; i < BlessingsMod.activeModifiers.Count; i++) {
                BlessingsMod.activeModifiers[i].PlayerModifyWeaponDamage(player, item, ref add, ref mult, ref flat);
            }
        }

        public override bool PreItemCheck() {
            bool returnPreItemCheck = base.PreItemCheck();
            for (int i = 0; i < BlessingsMod.activeModifiers.Count; i++) {
                if (!BlessingsMod.activeModifiers[i].PlayerPreItemCheck(player)) {
                    returnPreItemCheck = false;
                }
            }
            return returnPreItemCheck;
        }

        public override void PostItemCheck() {
            for (int i = 0; i < BlessingsMod.activeModifiers.Count; i++) {
                BlessingsMod.activeModifiers[i].PlayerPostItemCheck(player);
            }
        }

        public override void MeleeEffects(Item item, Rectangle hitbox) {
            for (int i = 0; i < BlessingsMod.activeModifiers.Count; i++) {
                BlessingsMod.activeModifiers[i].PlayerMeleeEffects(player, item, hitbox);
            }
        }

        public override float MeleeSpeedMultiplier(Item item) {
            float returnMeleeSpeedMultiplier = base.MeleeSpeedMultiplier(item);
            for (int i = 0; i < BlessingsMod.activeModifiers.Count; i++) {
                returnMeleeSpeedMultiplier += BlessingsMod.activeModifiers[i].PlayerMeleeSpeed(player, item);
            }
            return returnMeleeSpeedMultiplier;
        }

        public override float UseTimeMultiplier(Item item) {
            float returnUseTimeMultiplier = base.UseTimeMultiplier(item);
            for (int i = 0; i < BlessingsMod.activeModifiers.Count; i++) {
                returnUseTimeMultiplier += BlessingsMod.activeModifiers[i].PlayerUseTime(player, item);
            }
            return returnUseTimeMultiplier;
        }

        public override void GetHealLife(Item item, bool quickHeal, ref int healValue) {
            for (int i = 0; i < BlessingsMod.activeModifiers.Count; i++) {
                BlessingsMod.activeModifiers[i].PlayerHealLife(player, item, quickHeal, ref healValue);
            }
        }

        public override void GetHealMana(Item item, bool quickHeal, ref int healValue) {
            for (int i = 0; i < BlessingsMod.activeModifiers.Count; i++) {
                BlessingsMod.activeModifiers[i].PlayerHealMana(player, item, quickHeal, ref healValue);
            }
        }

        public override void ModifyManaCost(Item item, ref float reduce, ref float mult) {
            for (int i = 0; i < BlessingsMod.activeModifiers.Count; i++) {
                BlessingsMod.activeModifiers[i].PlayerModifyManaCost(player, item, ref reduce, ref mult);
            }
        }

        public override void OnConsumeMana(Item item, int manaConsumed) {
            for (int i = 0; i < BlessingsMod.activeModifiers.Count; i++) {
                BlessingsMod.activeModifiers[i].PlayerOnManaConsume(player, item, manaConsumed);
            }
        }

        public override void OnMissingMana(Item item, int neededMana) {
            for (int i = 0; i < BlessingsMod.activeModifiers.Count; i++) {
                BlessingsMod.activeModifiers[i].PlayerOnMissingMana(player, item, neededMana);
            }
        }

        public override void OnConsumeAmmo(Item weapon, Item ammo) {
            for (int i = 0; i < BlessingsMod.activeModifiers.Count; i++) {
                BlessingsMod.activeModifiers[i].PlayerOnConsumeAmmo(player, weapon, ammo);
            }
        }

        public override bool ConsumeAmmo(Item weapon, Item ammo) {
            bool returnConsumeAmmo = base.ConsumeAmmo(weapon, ammo);
            for (int i = 0; i < BlessingsMod.activeModifiers.Count; i++) {
                if (!BlessingsMod.activeModifiers[i].PlayerConsumeAmmo(player, weapon, ammo)) {
                    returnConsumeAmmo = false;
                }
            }
            return returnConsumeAmmo;
        }

        #endregion

        #region NPC Related Hooks

        public override void OnHitAnything(float x, float y, Entity victim) {
            for (int i = 0; i < BlessingsMod.activeModifiers.Count; i++) {
                BlessingsMod.activeModifiers[i].PlayerHitAnything(player, x, y, victim);
            }
        }

        public override void OnHitNPC(Item item, NPC target, int damage, float knockback, bool crit) {
            for (int i = 0; i < BlessingsMod.activeModifiers.Count; i++) {
                BlessingsMod.activeModifiers[i].PlayerHitNPC(player, item, target, damage, knockback, crit);
            }
        }

        public override void OnHitNPCWithProj(Projectile proj, NPC target, int damage, float knockback, bool crit) {
            for (int i = 0; i < BlessingsMod.activeModifiers.Count; i++) {
                BlessingsMod.activeModifiers[i].PlayerHitNPCWithProjectile(player, proj, target, damage, knockback, crit);
            }
        }

        public override void ModifyHitByNPC(NPC npc, ref int damage, ref bool crit) {
            for (int i = 0; i < BlessingsMod.activeModifiers.Count; i++) {
                BlessingsMod.activeModifiers[i].PlayerModifyHitByNPC(player, npc, ref damage, ref crit);
            }
        }

        public override void ModifyHitByProjectile(Projectile proj, ref int damage, ref bool crit) {
            for (int i = 0; i < BlessingsMod.activeModifiers.Count; i++) {
                BlessingsMod.activeModifiers[i].PlayerModifyHitByProjectile(player, proj, ref damage, ref crit);
            }
        }

        public override void OnHitByNPC(NPC npc, int damage, bool crit) {
            for (int i = 0; i < BlessingsMod.activeModifiers.Count; i++) {
                BlessingsMod.activeModifiers[i].PlayerOnHitByNPC(player, npc, damage, crit);
            }
        }

        public override void OnHitByProjectile(Projectile proj, int damage, bool crit) {
            for (int i = 0; i < BlessingsMod.activeModifiers.Count; i++) {
                BlessingsMod.activeModifiers[i].PlayerOnHitByProjectile(player, proj, damage, crit);
            }
        }

        public override void ModifyHitNPC(Item item, NPC target, ref int damage, ref float knockback, ref bool crit) {
            for (int i = 0; i < BlessingsMod.activeModifiers.Count; i++) {
                BlessingsMod.activeModifiers[i].PlayerModifyHitNPC(player, item, target, ref damage, ref knockback, ref crit);
            }
        }

        public override void ModifyHitNPCWithProj(Projectile proj, NPC target, ref int damage, ref float knockback, ref bool crit, ref int hitDirection) {
            for (int i = 0; i < BlessingsMod.activeModifiers.Count; i++) {
                BlessingsMod.activeModifiers[i].PlayerModifyHitNPCWithProj(player, proj, target, ref damage, ref knockback, ref crit, ref hitDirection);
            }
        }

        public override bool ModifyNurseHeal(NPC nurse, ref int health, ref bool removeDebuffs, ref string chatText) {
            bool returnModifyNurseHeal = base.ModifyNurseHeal(nurse, ref health, ref removeDebuffs, ref chatText);
            for (int i = 0; i < BlessingsMod.activeModifiers.Count; i++) {
                if (!BlessingsMod.activeModifiers[i].PlayerModifyNurseHeal(player, nurse, ref health, ref removeDebuffs, ref chatText)) {
                    returnModifyNurseHeal = false;
                }
            }
            return returnModifyNurseHeal;
        }

        public override void ModifyNursePrice(NPC nurse, int health, bool removeDebuffs, ref int price) {
            for (int i = 0; i < BlessingsMod.activeModifiers.Count; i++) {
                BlessingsMod.activeModifiers[i].PlayerModifyNursePrice(player, nurse, health, removeDebuffs, ref price);
            }
        }

        public override void PostNurseHeal(NPC nurse, int health, bool removeDebuffs, int price) {
            for (int i = 0; i < BlessingsMod.activeModifiers.Count; i++) {
                BlessingsMod.activeModifiers[i].PlayerPostNurseHeal(player, nurse, health, removeDebuffs, price);
            }
        }

        #endregion
    }
}