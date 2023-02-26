using Assets.Scripts.Gameplay.Damageables;
using Assets.Scripts.Gameplay.Indicators;
using System;
using UnityEngine;

namespace Tanks.Gameplay.Components
{
    public class RecoverableHealthComponent : MonoBehaviour, IDamageable, IHealthIndicatorTarget
    {
        #region Events

        public event Action Killed;

        #endregion

        #region Editor

        [SerializeField]
        [Range(1, 100)]
        private int _health = 100;

        [SerializeField]
        [Range(1, 25)]
        private int _reconverHealthPortion = 10;
        
        [SerializeField]
        [Range(0.5f, 10f)]
        private float _recoverPeriodInSeconds = 2f;

        [SerializeField]
        private Transform _indicatorTarget;

        #endregion

        #region Methods

        private void Start()
        {
            InvokeRepeating(nameof(RecoverHealth), 0, _recoverPeriodInSeconds);
        }

        private void OnDestroy()
        {
            CancelInvoke(nameof(RecoverHealth));
        }

        private void RecoverHealth()
        {
            _health = Mathf.Min(100, _health + _reconverHealthPortion);
        }

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

        public Vector3 PivotPoint => _indicatorTarget.position;

        #endregion
    }
}