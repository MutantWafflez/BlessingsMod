using Terraria;

namespace BlessingsMod.Content.Modifiers.Blessings {

    public class TestBlessing : Blessing {
        public override string BlessingDisplayName => "Blessing of Defense";

        public override string BlessingDescription => "All players' defense is increased by 30%";

        public override void PlayerPostUpdateEquips(Player player) {
            player.statDefense = (int)(player.statDefense * 1.3f);
        }
    }
}