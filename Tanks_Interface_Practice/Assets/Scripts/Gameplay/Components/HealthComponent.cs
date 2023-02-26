using Assets.Scripts.Gameplay.Damageables;
using Assets.Scripts.Gameplay.Indicators;
using System;
using UnityEngine;

namespace Tanks.Gameplay.Components
{
    public class HealthComponent : MonoBehaviour, IDamageable, IHealthIndicatorTarget
    {
        #region Events

        public event Action Killed;

        #endregion

        #region Editor

        [SerializeField]
        [Range(1, 100)]
        private int _health = 100;

        [SerializeField]
        private Transform _indicatorPivot;

        #endregion

        #region Methods

        public void Damage(int damageAmount, Vector2 hitDirection)
        {
            _health -= damageAmount;
            if (_health <= 0)
            {
                Killed?.Invoke();
                Destroy(gameObject);
            }
        }

        #endregion

        #region Properties

        public int Health => _health;

        public Vector3 PivotPoint => _indicatorPivot.position;

        #endregion
    }
}