using System;

namespace Assets.Scripts.Collectibles
{
    public interface ICollectible
    {
        event Action OnCollection;
    }
}
