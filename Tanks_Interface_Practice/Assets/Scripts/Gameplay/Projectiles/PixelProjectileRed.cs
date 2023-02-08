using Assets.Scripts.Gameplay.Damageables;
using System;
using UnityEngine;

namespace Assets.Scripts.Gameplay.Projectiles
{
    public class PixelProjectileRed : Projectile
    {
        #region Editor

        [SerializeField]
        private Rigidbody2D _rb;

        [SerializeField]
        [Range(1f, 100f)]
        private float _sinAmplitude;

        [SerializeField]
        [Range(1f, 20f)]
        private float _amplitudeFrequency;

        #endregion

        #region Fields

        private Vector2 _startPosition;

        private Vector2 _direction;

        #endregion

        #region Methods

        private void FixedUpdate()
        {
            Fly();
            ValidateMaxDistance();
        }

        public override void Fire(Vector2 fromDirection, Vector2 flyDirection)
        {
            _startPosition = fromDirection;
            _direction = flyDirection;
            transform.position = _startPosition;
        }

        private void Fly()
        {
            var sinDeviation = Mathf.Sin(Time.time * _amplitudeFrequency) * _sinAmplitude;
            var sinDeviatedDirection = Quaternion.Euler(0, 0, sinDeviation) * _direction;
            _rb.velocity = sinDeviatedDirection * _speed;

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
