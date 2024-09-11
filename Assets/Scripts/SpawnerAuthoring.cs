using Unity.Entities;
using Unity.Mathematics;
using UnityEngine;

public class SpawnerAuthoring : MonoBehaviour
{
    public GameObject Prefab;
    public float SpawnRate;

    class SpawnerBaker : Baker<SpawnerAuthoring> 
    {
        public override void Bake(SpawnerAuthoring authoring)
        {
            Entity entity = GetEntity(TransformUsageFlags.Dynamic);

            AddComponent(entity, new Spawner
            {
                prefab = GetEntity(authoring.Prefab, TransformUsageFlags.Dynamic),
                spawnPosition = float2.zero,
                NextSpawnTime = 0,
                SpawnRate = authoring.SpawnRate
            });
        }
    }
}
