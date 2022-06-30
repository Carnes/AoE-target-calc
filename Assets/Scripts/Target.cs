using UnityEngine;

namespace AoeExample
{
    public class Target : MonoBehaviour
    {
        public GameObject Prefab_BodyPart;
        [Range(0.1f,5f)]
        public float BodyPartSpawnRange;
        [Range(1,100)]
        public int BodyPartSpawnMinCount;
        [Range(1,100)]
        public int BodyPartSpawnMaxCount;
        
        [ContextMenu("Hit")]
        public void Hit()
        {
            Debug.Log($"{name} was hit!");
            SpawnBodyParts();
            Destroy(gameObject);
        }

        private void SpawnBodyParts()
        {
            var numParts = Random.Range(BodyPartSpawnMinCount, BodyPartSpawnMaxCount);
            for(var i = 0; i<numParts; i++)
                SpawnBodyPart();
        }

        private void SpawnBodyPart()
        {
            var spawnOffset = Random.insideUnitSphere * BodyPartSpawnRange;
            var spawnPoint = transform.position + spawnOffset;
            Instantiate(Prefab_BodyPart, spawnPoint, Random.rotation);
        }
    }
}