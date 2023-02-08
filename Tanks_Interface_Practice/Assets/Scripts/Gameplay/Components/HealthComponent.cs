using Assets.Scripts.Gameplay.Damageables;
using UnityEngine;

namespace Tanks.Gameplay.Components
{
    public class HealthComponent : MonoBehaviour, IDamageable
    {
        #region Editor

        [SerializeField]
        [Range(1, 100)]
        private int _health = 100;

        #endregion

        #region Methods

        public void Damage(int damageAmount, Vector2 hitDirection)
        {
            _health -= damageAmount;
            if (_health <= 0)
            {
                Destroy(gameObject);
            }
        }

        #endregion

        #region Properties

        public int Health => _health;

        #endregion
    }
}