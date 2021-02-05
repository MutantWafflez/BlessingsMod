using Terraria;

namespace BlessingsMod.Content.Modifiers.Curses {

    public class TestCurse : Curse {
        public override string CurseDisplayName => "Curse of Torbidity";

        public override string CurseDescription => "All players' max life is decreased by 20%";

        public override void PlayerPostUpdateEquips(Player player) {
            player.statLifeMax2 = (int)(player.statLifeMax2 * 0.8f);
        }
    }
}