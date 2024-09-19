using UnityEngine;
using Unity.Mathematics;
using Unity.Entities;

public class PlayerAuthoring : MonoBehaviour
{
    public float MoveSpeed;

    public GameObject BulletPrefab;

    public float ProjectileLifeTime;

    class PlayerAuthoringBaker : Baker<PlayerAuthoring>
    {
        public override void Bake(PlayerAuthoring authoring)
        {
            Entity playerEntity = GetEntity(TransformUsageFlags.Dynamic);

            AddComponent<PlayerTag>(playerEntity);
            AddComponent<PlayerMoveInput>(playerEntity);

            AddComponent(playerEntity, new PlayerMoveSpeed { Value = authoring.MoveSpeed });

            AddComponent<FireProjectileTag>(playerEntity);
            
            // Disabled by defualt.
            SetComponentEnabled<FireProjectileTag>(playerEntity, false);

            AddComponent(playerEntity, new ProjectilePrefab 
            { 
                Value = GetEntity(authoring.BulletPrefab, TransformUsageFlags.Dynamic) 
            });
            AddComponent(playerEntity, new ProjectileLifeTime
            {
                Value = authoring.ProjectileLifeTime
            });
        }
    }
}

public struct PlayerMoveInput : IComponentData
{
    public float2 Value;
}

public struct PlayerMoveSpeed : IComponentData
{
    public float Value;
}

// Empty struct used as a tag to identify the player.
public struct PlayerTag : IComponentData { }

public struct ProjectilePrefab : IComponentData
{
    public Entity Value;
}

public struct ProjectileMoveSpeed : IComponentData
{
    public float Value;
}

// Added IEnableableComponent to toggle this Component on/off.
public struct FireProjectileTag : IComponentData, IEnableableComponent { }


public struct ProjectileLifeTime : IComponentData
{
    public float Value;
}
public struct LifeTime: IComponentData
{
    public float Value;
}
public struct IsDestroying : IComponentData { }
