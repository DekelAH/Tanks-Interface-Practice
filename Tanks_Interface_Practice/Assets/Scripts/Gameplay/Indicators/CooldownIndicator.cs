using Assets.Scripts.Gameplay.Indicators;
using System;
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

        private ICoolDownIndicatorTarget _indicatorTarget;

        private Camera _transformationCamera;

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
            _canvasGroup.alpha = _indicatorTarget.IsInCooldown ? 1 : 0;
        }

        private void FollowTarget()
        {
            if (_indicatorTarget == null)
            {
                return;
            }

            _selfTransform.anchoredPosition = _transformationCamera.WorldToScreenPoint(_indicatorTarget.PivotPoint);
        }

        private void UpdateCooldownBar()
        {
            _cooldownBar.value = _indicatorTarget.CooldownProgress;
        }

        public void Attach(ICoolDownIndicatorTarget indicatorTarget, Camera transformationCamera)
        {
            _indicatorTarget = indicatorTarget;
            _indicatorTarget.Killed += OnTargetKilled;
            _transformationCamera = transformationCamera;
        }

        private void OnTargetKilled()
        {
            _indicatorTarget.Killed -= OnTargetKilled;
            _indicatorTarget = null;
            _transformationCamera = null;
            Destroy(gameObject);
        }

        #endregion
    }
}