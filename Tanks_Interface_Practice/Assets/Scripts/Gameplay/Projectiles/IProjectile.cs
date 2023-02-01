using UnityEngine;

namespace Assets.Scripts.Gameplay.Projectiles
{
    public interface IProjectile
    {
        void Fire(Vector2 fromDirection, Vector2 flyDirection);
    }
}
