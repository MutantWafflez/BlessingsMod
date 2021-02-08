using BlessingsMod.Content.Modifiers;
using BlessingsMod.Content.Modifiers.Blessings;
using BlessingsMod.Custom.Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using Terraria;
using Terraria.GameContent.UI.Elements;
using Terraria.ModLoader;
using Terraria.UI;
using Terraria.UI.Chat;

namespace BlessingsMod.Content.UI {

    public class ModifierRevealUI : UIState {
        private const int backPanelWidth = 600;
        private const int backPanelHeight = 400;
        private const int backPanelPadding = 6;

        //Cinematic Float Fields
        private float backPanelHeightMultiplier;

        private float backPanelWidthMultiplier;
        private float contentPanelHeightMultiplier;
        private float contentPanelWidthMultiplier;
        private float cinematicStage;
        private float cinematicTimer;

        private IModifier appliedModifier;
        private Rectangle backPanel;
        private Rectangle contentPanel;

        //Cinematic Bool Fields
        private bool appearanceCinematicRolling;

        private bool useOutlineShader;

        //Misc Cinematic Fields
        private Color targetColor;

        public override void OnInitialize() {
            TriggerAppearance(new TestBlessing());
        }

        public void TriggerAppearance(IModifier newModifer) {
            appliedModifier = newModifer;
            backPanelHeightMultiplier = 0.0125f;
            backPanelWidthMultiplier = 0f;
            contentPanelHeightMultiplier = 0f;
            contentPanelWidthMultiplier = 0f;
            appearanceCinematicRolling = true;
            useOutlineShader = false;
            cinematicStage = 0f;
            cinematicTimer = 0f;
            targetColor = new Color(1f, 1f, 1f, 1f);
        }

        public void RollCinematic() {
            if (cinematicStage == 0f) {
                backPanelWidthMultiplier = MathHelper.Clamp(backPanelWidthMultiplier + (0.0025f * (1 + backPanelWidthMultiplier * 12f)), 0f, 1f);
                if (backPanelWidthMultiplier >= 1f) {
                    cinematicStage = 1f;
                    cinematicTimer = 0f;
                }
            }
            else if (cinematicStage == 1f) {
                if (++cinematicTimer > 15f) {
                    backPanelHeightMultiplier += 0.005f * (1 + backPanelHeightMultiplier * 12f);
                    backPanelHeightMultiplier = MathHelper.Clamp(backPanelHeightMultiplier, 0.0125f, 1f);
                }
                if (backPanelHeightMultiplier >= 1f) {
                    cinematicStage = 2f;
                    cinematicTimer = 0f;
                    contentPanelHeightMultiplier = 0.0125f;
                }
            }
            else if (cinematicStage == 2f) {
                contentPanelWidthMultiplier = MathHelper.Clamp(contentPanelWidthMultiplier + (0.0025f * (1 + contentPanelWidthMultiplier * 12f)), 0f, 1f);
                if (contentPanelWidthMultiplier >= 1f) {
                    cinematicStage = 3f;
                    cinematicTimer = 0f;

                }
            }
            else if (cinematicStage == 3f) {
                if (++cinematicTimer > 15f) {
                    contentPanelHeightMultiplier += 0.005f * (1 + contentPanelHeightMultiplier * 12f);
                    contentPanelHeightMultiplier = MathHelper.Clamp(contentPanelHeightMultiplier, 0.0125f, 1f);
                }
                if (contentPanelHeightMultiplier >= 1f) {
                    cinematicStage = 4f;
                    cinematicTimer = 0f;
                }
            }
            else if (cinematicStage == 4f) {
                if (++cinematicTimer >= 30f) {
                    if (appliedModifier is Blessing) {
                        targetColor = new Color(0.2f, 0.8f, 0.2f);
                        //Happy sound
                    }
                    else if (appliedModifier is Curse) {
                        targetColor = new Color(1f, 0f, 0f);
                        //Anger sound
                    }
                    cinematicStage = 5f;
                }
            }
            else if (cinematicStage == 5f) {
                TriggerAppearance(new TestBlessing());
            }
        }

        protected override void DrawSelf(SpriteBatch spriteBatch) {
            if (appearanceCinematicRolling && !Main.gameInactive) {
                RollCinematic();
            }

            backPanel = new Rectangle((Main.screenWidth / 2) - (backPanelWidth / 2), (Main.screenHeight / 4) - (backPanelHeight / 2), (int)(backPanelWidth * backPanelWidthMultiplier), (int)(backPanelHeight * backPanelHeightMultiplier));
            contentPanel = new Rectangle(backPanel.X + (backPanelPadding / 2), backPanel.Y + (backPanelPadding / 2), (int)((backPanelWidth - backPanelPadding) * contentPanelWidthMultiplier), (int)((backPanelHeight - backPanelPadding) * contentPanelHeightMultiplier));

            spriteBatch.Draw(Main.magicPixel, backPanel, targetColor);
            spriteBatch.Draw(Main.magicPixel, contentPanel, new Color(0.5f, 0.5f, 0.5f));
        }
    }
}