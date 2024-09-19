using UnityEngine;
using Unity.Entities;
using Unity.Mathematics;

public class EnemyAuthoring : MonoBehaviour
{
    public float EnemyMoveSpeed;

    class EnemyAuthoringBaker : Baker<EnemyAuthoring>
    {
        public override void Bake(EnemyAuthoring authoring)
        {
            Entity enemyEntity = GetEntity(TransformUsageFlags.Dynamic);

            AddComponent(enemyEntity, new EnemyMoveSpeed { 
                Value = authoring.EnemyMoveSpeed 
            });
        }
    }
}

public struct EnemyMoveSpeed : IComponentData
{
    public float Value;
}