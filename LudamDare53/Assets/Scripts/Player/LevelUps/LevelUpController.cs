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

        [SerializeField] private GameObject levelUpParticlesPrefab;

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
            ExperiencePointsToNextLevel += ExperiencePointsNeededThisLevel();
            PlaySoundEffect();
            if (levelUpParticlesPrefab != null)
            {
                Instantiate(levelUpParticlesPrefab, transform.position, Quaternion.identity);
            }
        }

        private int ExperiencePointsNeededThisLevel()
        {
            return BaseLevelUpExperiencePointsCost * Level;
        }

        private void LateUpdate()
        {
            if (UiText == null)
            {
                return;
            }
            float xpTotalThisLevel = ExperiencePointsNeededThisLevel();
            UiText.text = textPrefixLabel + CurrentLevel.ToString() + "." + Mathf.RoundToInt(((xpTotalThisLevel - ExperiencePointsToNextLevel) / xpTotalThisLevel) * 100).ToString();
        }
    }
}
