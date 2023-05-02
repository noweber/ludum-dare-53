using Assets.Scripts.Audio;
using TMPro;
using UnityEngine;

namespace Assets.Scripts.Score
{
    public sealed class ScoreController : SoundEffectPlayer, IScoreController
    {
        [SerializeField] private TextMeshProUGUI scoreUiText;

        [SerializeField] private TextMeshProUGUI highScoreUiText;

        private const string HIGH_SCORE_KEY = "HighScore";

        public int Score
        {
            get { return CurrentScore; }
        }

        [SerializeField] private int CurrentScore;

        public int HighScore
        {
            get { return CurrentHighScore; }
        }

        [SerializeField] private int CurrentHighScore;

        protected override void Start()
        {
            base.Start();
            CurrentHighScore = LoadHighScore();
        }

        public void AddScorePoints(int scorePoints)
        {
            CurrentScore += scorePoints;
            if (CurrentScore < 0)
            {
                CurrentScore = 0;
            }
            if (Score > CurrentHighScore)
            {
                CurrentHighScore = Score;
                SaveHighScore(HighScore);
                UpdateScoreText(scoreUiText, Score, "High Score: ");
            }
            UpdateScoreText(scoreUiText, Score, "");
        }


        private void SaveHighScore(int highScore)
        {
            PlayerPrefs.SetInt(HIGH_SCORE_KEY, highScore);
            PlayerPrefs.Save();
        }

        private int LoadHighScore()
        {
            return PlayerPrefs.GetInt(HIGH_SCORE_KEY, 0);
        }

        private static void UpdateScoreText(TextMeshProUGUI text, int value, string? label = null)
        {
            if (text != null)
            {
                if (label != null)
                {
                    text.text = label;
                }
                text.text += value.ToString();
            }
        }
    }
}
