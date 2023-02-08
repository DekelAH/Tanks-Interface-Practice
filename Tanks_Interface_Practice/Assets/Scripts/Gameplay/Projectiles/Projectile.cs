using UnityEngine;

namespace Assets.Scripts.Gameplay.Projectiles
{
    public abstract class Projectile : MonoBehaviour, IProjectile
    {
        #region Editor

        [SerializeField]
        [Range(0.1f, 5f)]
        protected float _speed;

        [SerializeField]
        [Range(5f, 25f)]
        protected float _maxDistance;

        [SerializeField]
        [Range(1, 100)]
        protected int _damageToApply;

        #endregion

        #region Methods

        public abstract void Fire(Vector2 fromDirection, Vector2 flyDirection);

        #endregion
    }
}
