using UnityEngine;
using UnityEngine.UI;

namespace Tanks.Gameplay.Indicators
{
    public class CooldownIndicator : MonoBehaviour
    {
        #region Editor

        [SerializeField]
        private RectTransform _selfTransform;

        [SerializeField]
        private Slider _cooldownBar;

        [SerializeField]
        private CanvasGroup _canvasGroup;
        
        #endregion

        #region Fields

        #endregion
        
        #region Methods
        
        private void Update()
        {
            FollowTarget();
            UpdateCooldownBar();
            UpdateVisibility();
        }

        private void UpdateVisibility()
        {
        }

        private void FollowTarget()
        {
        }

        private void UpdateCooldownBar()
        {
        }
        
        #endregion
    }
}