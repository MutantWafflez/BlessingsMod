using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ModLoader;

namespace BlessingsMod.Common.GlobalNPCs {

    /// <summary>
    /// Global NPC that handles all of the changes imposed by Blessings and Curses.
    /// </summary>
    public class ModifierGlobalNPC : GlobalNPC {

        #region Stat/Defaults Related

        public override void SetDefaults(NPC npc) {
            for (int i = 0; i < BlessingsMod.activeModifiers.Count; i++) {
                BlessingsMod.activeModifiers[i].NPCSetDefaults(npc);
            }
        }

        #endregion

        #region AI Related

        public override bool PreAI(NPC npc) {
            bool returnPreAI = base.PreAI(npc);
            for (int i = 0; i < BlessingsMod.activeModifiers.Count; i++) {
                if (!BlessingsMod.activeModifiers[i].NPCPreAI(npc)) {
                    returnPreAI = false;
                }
            }
            return returnPreAI;
        }

        public override void AI(NPC npc) {
            for (int i = 0; i < BlessingsMod.activeModifiers.Count; i++) {
                BlessingsMod.activeModifiers[i].NPCAI(npc);
            }
        }

        public override void PostAI(NPC npc) {
            for (int i = 0; i < BlessingsMod.activeModifiers.Count; i++) {
                BlessingsMod.activeModifiers[i].NPCPostAI(npc);
            }
        }

        #endregion

        #region Drawing/Effect Related

        public override bool PreDraw(NPC npc, SpriteBatch spriteBatch, Color drawColor) {
            bool returnPreDraw = base.PreDraw(npc, spriteBatch, drawColor);
            for (int i = 0; i < BlessingsMod.activeModifiers.Count; i++) {
                if (!BlessingsMod.activeModifiers[i].NPCPreDraw(npc, spriteBatch, drawColor)) {
                    returnPreDraw = false;
                }
            }
            return returnPreDraw;
        }

        public override void PostDraw(NPC npc, SpriteBatch spriteBatch, Color drawColor) {
            for (int i = 0; i < BlessingsMod.activeModifiers.Count; i++) {
                BlessingsMod.activeModifiers[i].NPCPostDraw(npc, spriteBatch, drawColor);
            }
        }

        public override void DrawBehind(NPC npc, int index) {
            for (int i = 0; i < BlessingsMod.activeModifiers.Count; i++) {
                BlessingsMod.activeModifiers[i].NPCDrawBehind(npc, index);
            }
        }

        public override void DrawEffects(NPC npc, ref Color drawColor) {
            for (int i = 0; i < BlessingsMod.activeModifiers.Count; i++) {
                BlessingsMod.activeModifiers[i].NPCDrawEffects(npc, ref drawColor);
            }
        }

        #endregion

        #region Combat Related

        public override void ModifyHitByItem(NPC npc, Player player, Item item, ref int damage, ref float knockback, ref bool crit) {
            for (int i = 0; i < BlessingsMod.activeModifiers.Count; i++) {
                BlessingsMod.activeModifiers[i].NPCModifyHitByItem(npc, player, item, ref damage, ref knockback, ref crit);
            }
        }

        public override void ModifyHitByProjectile(NPC npc, Projectile projectile, ref int damage, ref float knockback, ref bool crit, ref int hitDirection) {
            for (int i = 0; i < BlessingsMod.activeModifiers.Count; i++) {
                BlessingsMod.activeModifiers[i].NPCModifyHitByProjectile(npc, projectile, ref damage, ref knockback, ref crit, ref hitDirection);
            }
        }

        public override void ModifyHitNPC(NPC npc, NPC target, ref int damage, ref float knockback, ref bool crit) {
            for (int i = 0; i < BlessingsMod.activeModifiers.Count; i++) {
                BlessingsMod.activeModifiers[i].NPCModifyHitNPC(npc, target, ref damage, ref knockback, ref crit);
            }
        }

        public override void ModifyHitPlayer(NPC npc, Player target, ref int damage, ref bool crit) {
            for (int i = 0; i < BlessingsMod.activeModifiers.Count; i++) {
                BlessingsMod.activeModifiers[i].NPCModifyHitPlayer(npc, target, ref damage, ref crit);
            }
        }

        public override void OnHitByItem(NPC npc, Player player, Item item, int damage, float knockback, bool crit) {
            for (int i = 0; i < BlessingsMod.activeModifiers.Count; i++) {
                BlessingsMod.activeModifiers[i].NPCOnHitByItem(npc, player, item, damage, knockback, crit);
            }
        }

        public override void OnHitByProjectile(NPC npc, Projectile projectile, int damage, float knockback, bool crit) {
            for (int i = 0; i < BlessingsMod.activeModifiers.Count; i++) {
                BlessingsMod.activeModifiers[i].NPCOnHitByProjectile(npc, projectile, damage, knockback, crit);
            }
        }

        public override void OnHitNPC(NPC npc, NPC target, int damage, float knockback, bool crit) {
            for (int i = 0; i < BlessingsMod.activeModifiers.Count; i++) {
                BlessingsMod.activeModifiers[i].NPCOnHitNPC(npc, target, damage, knockback, crit);
            }
        }

        public override void OnHitPlayer(NPC npc, Player target, int damage, bool crit) {
            for (int i = 0; i < BlessingsMod.activeModifiers.Count; i++) {
                BlessingsMod.activeModifiers[i].NPCOnHitPlayer(npc, target, damage, crit);
            }
        }

        public override void UpdateLifeRegen(NPC npc, ref int damage) {
            for (int i = 0; i < BlessingsMod.activeModifiers.Count; i++) {
                BlessingsMod.activeModifiers[i].NPCUpdateLifeRegen(npc, ref damage);
            }
        }

        public override bool CheckDead(NPC npc) {
            bool returnCheckDead = base.PreAI(npc);
            for (int i = 0; i < BlessingsMod.activeModifiers.Count; i++) {
                if (!BlessingsMod.activeModifiers[i].NPCCheckDead(npc)) {
                    returnCheckDead = false;
                }
            }
            return returnCheckDead;
        }

        public override bool CheckActive(NPC npc) {
            bool returnCheckActive = base.PreAI(npc);
            for (int i = 0; i < BlessingsMod.activeModifiers.Count; i++) {
                if (!BlessingsMod.activeModifiers[i].NPCCheckActive(npc)) {
                    returnCheckActive = false;
                }
            }
            return returnCheckActive;
        }

        #endregion

        #region Loot Related

        public override bool PreNPCLoot(NPC npc) {
            bool returnPreNPCLoot = base.PreNPCLoot(npc);
            for (int i = 0; i < BlessingsMod.activeModifiers.Count; i++) {
                if (!BlessingsMod.activeModifiers[i].NPCPreLoot(npc)) {
                    returnPreNPCLoot = false;
                }
            }
            return returnPreNPCLoot;
        }

        public override void NPCLoot(NPC npc) {
            for (int i = 0; i < BlessingsMod.activeModifiers.Count; i++) {
                BlessingsMod.activeModifiers[i].NPCLoot(npc);
            }
        }

        public override bool SpecialNPCLoot(NPC npc) {
            bool returnSpecialLoot = base.SpecialNPCLoot(npc);
            for (int i = 0; i < BlessingsMod.activeModifiers.Count; i++) {
                if (BlessingsMod.activeModifiers[i].NPCSpecialLoot(npc)) {
                    returnSpecialLoot = true;
                }
            }
            return returnSpecialLoot;
        }

        #endregion
    }
}