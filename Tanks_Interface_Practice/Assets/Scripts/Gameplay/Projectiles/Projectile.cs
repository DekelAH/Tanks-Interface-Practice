using UnityEngine;

namespace Assets.Scripts.Gameplay.Projectiles
{
    public abstract class Projectile : MonoBehaviour, IProjectile
    {
        #region Methods

        public abstract void Fire(Vector2 fromDirection, Vector2 flyDirection);

        #endregion
    }
}
