using UnityEngine;

namespace AoeExample
{
    public static class AoeExampleHelper
    {
        public static float GetRandomAxisLength(float range) => Random.Range(range * -1, range);
    }
}