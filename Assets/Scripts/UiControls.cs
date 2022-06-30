using UnityEngine;

namespace AoeExample
{
    public class UiControls : MonoBehaviour
    {
        public GameObject Prefab_Target;
        public GameObject Prefab_Bomb;
        public GameObject Prefab_Bomb90;
        
        [Range(1f, 20f)]
        public float SpawnRange;
        [Range(1f, 20f)]
        public float SpawnHeight;

        [ContextMenu("SpawnTarget")]
        public void SpawnTarget()
        {
            Instantiate(Prefab_Target, GetRandomSpawn(), Quaternion.identity);
        }

        [ContextMenu("DropBomb")]
        public void DropBomb()
        {
            Instantiate(Prefab_Bomb, GetRandomSpawn(), Random.rotation);
        }

        [ContextMenu("DropBomb90")]
        public void DropBomb90()
        {
            // var direction = new Vector3(0, Random.Range(0f, 359f), 0);
            var rotation = Quaternion.Euler(0, Random.Range(0f, 359f), 0);
            Instantiate(Prefab_Bomb90, GetRandomSpawn(), rotation);
        }

        private Vector3 GetRandomSpawn()
        {
            var x = Random.Range(SpawnRange * -1, SpawnRange);
            var z = Random.Range(SpawnRange * -1, SpawnRange);
            return new Vector3(x, SpawnHeight, z);
        }
    }
}