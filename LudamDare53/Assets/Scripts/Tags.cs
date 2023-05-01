using UnityEngine;

namespace Assets.Scripts
{
    public static class Tags
    {
        public static string Platform { get; private set; } = "Platform";
        public static string Player { get; private set; } = "Player";

        public static string Hero { get; private set; } = "Hero";

        public static string Enemy { get; private set; } = "Enemy";
        public static string Collectible { get; private set; } = "Collectible";
    }
}
