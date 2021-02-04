using BlessingsMod.Content.Modifiers;
using BlessingsMod.Custom;
using System;
using System.Collections.Generic;
using Terraria.ModLoader;

namespace BlessingsMod {

    public class BlessingsMod : Mod {
        public static List<Blessing> possibleBlessings;

        public static List<Curse> possibleCurses;

        public override void Load() {
            possibleBlessings = new List<Blessing>();
            possibleCurses = new List<Curse>();

            foreach (Type blessingType in BlessingUtilities.GetAllChildrenOfClass<Blessing>()) {
                possibleBlessings.Add((Blessing)Activator.CreateInstance(blessingType));
            }

            foreach (Type curseType in BlessingUtilities.GetAllChildrenOfClass<Curse>()) {
                possibleCurses.Add((Curse)Activator.CreateInstance(curseType));
            }
        }

        public override void Unload() {
            possibleBlessings = null;
            possibleCurses = null;
        }
    }
}