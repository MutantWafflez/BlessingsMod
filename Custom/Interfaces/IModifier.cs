using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.DataStructures;

namespace BlessingsMod.Custom.Interfaces {

    public interface IModifier {

        #region Player Methods

        bool PlayerPreHurt(Player player, bool pvp, bool quiet, ref int damage, ref int hitDirection, ref bool crit, ref bool customDamage, ref bool playSound, ref bool genGore, ref PlayerDeathReason damageSource);

        void PlayerHurt(Player player, bool pvp, bool quiet, double damage, int hitDirection, bool crit);

        void PlayerPostHurt(Player player, bool pvp, bool quiet, double damage, int hitDirection, bool crit);

        bool PlayerPreKill(Player player, double damage, int hitDirection, bool pvp, ref bool playSound, ref bool genGore, ref PlayerDeathReason damageSource);

        void PlayerKill(Player player, double damage, int hitDirection, bool pvp, PlayerDeathReason damageSource);

        void PlayerPreUpdate(Player player);

        void PlayerPreUpdateBuffs(Player player);

        void PlayerPreUpdateMovement(Player player);

        void PlayerPostUpdateBuffs(Player player);

        void PlayerPostUpdateEquips(Player player);

        void PlayerPostUpdateMiscEffects(Player player);

        void PlayerPostUpdateRunSpeeds(Player player);

        void PlayerPostUpdate(Player player);

        void PlayerLifeRegen(Player player);

        void PlayerNaturalLifeRegen(Player player, ref float regen);

        void PlayerBadLifeRegen(Player player);

        bool PlayerShoot(Player player, Item item, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack);

        void PlayerGetWeaponCrit(Player player, Item item, ref int crit);

        void PlayerGetWeaponKnockback(Player player, Item item, ref float knockback);

        void PlayerModifyWeaponDamage(Player player, Item item, ref float add, ref float mult, ref float flat);

        bool PlayerPreItemCheck(Player player);

        void PlayerPostItemCheck(Player player);

        void PlayerMeleeEffects(Player player, Item item, Rectangle hitbox);

        float PlayerMeleeSpeed(Player player, Item item);

        float PlayerUseTime(Player player, Item item);

        void PlayerHealLife(Player player, Item item, bool quickHeal, ref int healValue);

        void PlayerHealMana(Player player, Item item, bool quickHeal, ref int healValue);

        void PlayerModifyManaCost(Player player, Item item, ref float reduce, ref float mult);

        void PlayerOnManaConsume(Player player, Item item, int manaConsumed);

        void PlayerOnMissingMana(Player player, Item item, int neededMana);

        void PlayerOnConsumeAmmo(Player player, Item weapon, Item ammo);

        bool PlayerConsumeAmmo(Player player, Item weapon, Item ammo);

        void PlayerHitAnything(Player player, float x, float y, Entity victim);

        void PlayerHitNPC(Player player, Item item, NPC target, int damage, float knockback, bool crit);

        void PlayerHitNPCWithProjectile(Player player, Projectile proj, NPC target, int damage, float knockback, bool crit);

        void PlayerModifyHitByNPC(Player player, NPC npc, ref int damage, ref bool crit);

        void PlayerModifyHitByProjectile(Player player, Projectile proj, ref int damage, ref bool crit);

        void PlayerOnHitByNPC(Player player, NPC npc, int damage, bool crit);

        void PlayerOnHitByProjectile(Player player, Projectile proj, int damage, bool crit);

        void PlayerModifyHitNPC(Player player, Item item, NPC target, ref int damage, ref float knockback, ref bool crit);

        void PlayerModifyHitNPCWithProj(Player player, Projectile proj, NPC target, ref int damage, ref float knockback, ref bool crit, ref int hitDirection);

        bool PlayerModifyNurseHeal(Player player, NPC nurse, ref int health, ref bool removeDebuffs, ref string chatText);

        void PlayerModifyNursePrice(Player player, NPC nurse, int health, bool removeDebuffs, ref int price);

        void PlayerPostNurseHeal(Player player, NPC nurse, int health, bool removeDebuffs, int price);

        #endregion

        #region NPC Methods

        void NPCSetDefaults(NPC npc);

        bool NPCPreAI(NPC npc);

        void NPCAI(NPC npc);

        void NPCPostAI(NPC npc);

        bool NPCPreDraw(NPC npc, SpriteBatch spriteBatch, Color drawColor);

        void NPCPostDraw(NPC npc, SpriteBatch spriteBatch, Color drawColor);

        void NPCDrawBehind(NPC npc, int index);

        void NPCDrawEffects(NPC npc, ref Color drawColor);

        void NPCModifyHitByItem(NPC npc, Player player, Item item, ref int damage, ref float knockback, ref bool crit);

        void NPCModifyHitByProjectile(NPC npc, Projectile projectile, ref int damage, ref float knockback, ref bool crit, ref int hitDirection);

        void NPCModifyHitNPC(NPC npc, NPC target, ref int damage, ref float knockback, ref bool crit);

        void NPCModifyHitPlayer(NPC npc, Player target, ref int damage, ref bool crit);

        void NPCOnHitByItem(NPC npc, Player player, Item item, int damage, float knockback, bool crit);

        void NPCOnHitByProjectile(NPC npc, Projectile projectile, int damage, float knockback, bool crit);

        void NPCOnHitNPC(NPC npc, NPC target, int damage, float knockback, bool crit);

        void NPCOnHitPlayer(NPC npc, Player target, int damage, bool crit);

        void NPCUpdateLifeRegen(NPC npc, ref int damage);

        bool NPCCheckDead(NPC npc);

        bool NPCCheckActive(NPC npc);

        bool NPCPreLoot(NPC npc);

        void NPCLoot(NPC npc);

        bool NPCSpecialLoot(NPC npc);

        #endregion
    }
}