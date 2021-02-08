using BlessingsMod.Content.Modifiers;
using BlessingsMod.Content.UI;
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

        #region UI Fields

        internal UserInterface modifierRevealInterface;

        internal ModifierRevealUI revealUIState;

        internal GameTime lastGameTime;

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

            #region UI Initialization

            if (Main.netMode != NetmodeID.Server) {
                modifierRevealInterface = new UserInterface();
                revealUIState = new ModifierRevealUI();
                revealUIState.Activate();
                modifierRevealInterface.SetState(revealUIState);
            }

            #endregion
        }

        public override void Unload() {
            possibleBlessings = null;
            possibleCurses = null;
            activeModifiers = null;
        }

        #endregion

        #region UI

        public override void UpdateUI(GameTime gameTime) {
            lastGameTime = gameTime;
            if (modifierRevealInterface?.CurrentState != null) {
                modifierRevealInterface.Update(gameTime);
            }
        }

        public override void ModifyInterfaceLayers(List<GameInterfaceLayer> layers) {
            int mouseTextIndex = layers.FindIndex(layer => layer.Name.Equals("Vanilla: Mouse Text"));
            if (mouseTextIndex != -1) {
                layers.Insert(mouseTextIndex, new LegacyGameInterfaceLayer(
                    "BlessingsMod: Modifier Reveal Panel",
                    delegate {
                        if (lastGameTime != null && modifierRevealInterface?.CurrentState != null) {
                            modifierRevealInterface.Draw(Main.spriteBatch, lastGameTime);
                        }
                        return true;
                    },
                       InterfaceScaleType.UI));
            }
        }

        #endregion
    }
}