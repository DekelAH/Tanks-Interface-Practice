using Assets.Scripts.Gameplay.Damageables;
using Assets.Scripts.Gameplay.Projectiles;
using UnityEngine;

namespace Tanks.Gameplay.Projectiles
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class PixelProjectile : Projectile
    {
        #region Editor

        [SerializeField]
        private Rigidbody2D _rb;
        
        #endregion

        #region Fields

        private Vector2 _startPosition;

        private Vector2 _direction;

        #endregion
        
        #region Methods
        
        public override void Fire(Vector2 fromDirection, Vector2 flyDirection)
        {
            _startPosition = fromDirection;
            _direction = flyDirection;
            transform.position = _startPosition;
        }

        private void FixedUpdate()
        {
            Fly();
            ValidateMaxDistance();
        }

        private void Fly()
        {
            _rb.velocity = _direction * _speed;
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            var damageReciever = other.GetComponent<IDamageable>();
            if (damageReciever == null)
            {
                return;
            }

            damageReciever.Damage(_damageToApply, _direction);
            Destroy(gameObject);
        }

        private void ValidateMaxDistance()
        {
            if (Vector3.Distance(_startPosition, transform.position) > _maxDistance)
            {
                Destroy(gameObject);
            }
        }

        #endregion
    }
}