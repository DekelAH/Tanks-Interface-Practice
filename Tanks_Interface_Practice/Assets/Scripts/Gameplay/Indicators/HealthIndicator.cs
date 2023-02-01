using UnityEngine;
using UnityEngine.UI;

namespace Tanks.Gameplay.Indicators
{
    public class HealthIndicator : MonoBehaviour
    {
        #region Editor

        [SerializeField]
        private RectTransform _selfTransform;

        [SerializeField]
        private Slider _healthBar;
        
        #endregion
        
        #region Methods

        private void Update()
        {
            FollowTarget();
            UpdateHealthBar();
        }

        private void FollowTarget()
        {
        }

        private void UpdateHealthBar()
        {
        }

        #endregion
    }
}