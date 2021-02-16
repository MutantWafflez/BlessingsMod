using BlessingsMod.Content.Modifiers;
using BlessingsMod.Custom;
using BlessingsMod.Custom.Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using Terraria;
using Terraria.Graphics.Shaders;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.UI;

namespace BlessingsMod {

    public class BlessingsMod : Mod {

        #region Modifier Lists

        public static List<Blessing> possibleBlessings;

        public static List<Curse> possibleCurses;

        public static List<IModifier> activeModifiers;

        #endregion

        public static BlessingsMod ModInstance {
            internal set;
            get;
        }

        public BlessingsMod() {
            ModInstance = this;

            Properties = new ModProperties() {
                Autoload = true,
                AutoloadGores = true,
                AutoloadSounds = true
            };
        }

        #region Loading

        public override void Load() {

            #region List Initialization

            possibleBlessings = new List<Blessing>();
            possibleCurses = new List<Curse>();
            activeModifiers = new List<IModifier>();

            foreach (Type blessingType in BlessingUtilities.GetAllChildrenOfClass<Blessing>()) {
                possibleBlessings.Add((Blessing)Activator.CreateInstance(blessingType));
            }

            foreach (Type curseType in BlessingUtilities.GetAllChildrenOfClass<Curse>()) {
                possibleCurses.Add((Curse)Activator.CreateInstance(curseType));
            }

            #endregion
        }

        public override void Unload() {
            ModInstance = null;
            possibleBlessings = null;
            possibleCurses = null;
            activeModifiers = null;
        }

        #endregion
    }
}