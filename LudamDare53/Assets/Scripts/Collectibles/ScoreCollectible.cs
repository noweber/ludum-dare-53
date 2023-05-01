using Assets.Scripts.Collectibles;
using Assets.Scripts.Score;
using UnityEngine;

public sealed class ScoreCollectible : CollectibleItem
{
    public int scoreValue = 10;         // Amount of score awarded to player upon collection

    protected override bool TryToBeCollectedBy(GameObject collectorGameObject)
    {
        var controller = collectorGameObject.GetComponent<IScoreController>();
        if (controller != null)
        {
            controller.AddScorePoints(scoreValue);
            return true;
        }
        return false;
    }
}
