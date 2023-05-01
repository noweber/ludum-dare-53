namespace Assets.Scripts.Player
{
    public interface ILevelUpController
    {
        int Level { get; }

        void AddExperiencePoints(int experiencePoints);

        int GetExperiencePointsToNextLevel();
    }
}
