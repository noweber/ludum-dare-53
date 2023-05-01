using Assets.Scripts.Audio;
using TMPro;
using UnityEngine;

namespace Assets.Scripts.Player
{
    public sealed class LevelUpController : SoundEffectPlayer, ILevelUpController
    {
        public int Level
        {
            get { return CurrentLevel; }
        }

        [SerializeField] private int CurrentLevel;

        [SerializeField] private int BaseLevelUpExperiencePointsCost;

        [SerializeField] private int ExperiencePointsToNextLevel;

        [SerializeField] private TextMeshProUGUI UiText;

        [SerializeField] private string textPrefixLabel;

        protected override void Awake()
        {
            base.Awake();
        }

        public void AddExperiencePoints(int experiencePoints)
        {
            ExperiencePointsToNextLevel -= experiencePoints;
            if (ExperiencePointsToNextLevel <= 0)
            {
                LevelUp();
            }
        }

        public int GetExperiencePointsToNextLevel()
        {
            return ExperiencePointsToNextLevel;
        }

        private void LevelUp()
        {
            CurrentLevel++;
            ExperiencePointsToNextLevel += (BaseLevelUpExperiencePointsCost * Level);
            PlaySoundEffect();
        }
        private void LateUpdate()
        {
            if (UiText == null)
            {
                return;
            }

            UiText.text = textPrefixLabel + CurrentLevel.ToString();
        }
    }
}
