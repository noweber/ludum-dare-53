namespace Assets.Scripts.Score
{
    public interface IScoreController
    {
        int Score { get; }
        int HighScore { get; }

        void AddScorePoints(int experiencePoints);
    }
}
