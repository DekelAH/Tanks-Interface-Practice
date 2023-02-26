using Assets.Scripts.Gameplay.Indicators;
using System;
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

        #region Fields

        private IHealthIndicatorTarget _target;

        private Camera _transformationCamera;

        #endregion

        #region Methods

        private void Update()
        {
            FollowTarget();
            UpdateHealthBar();
        }

        private void FollowTarget()
        {
            if (_target == null)
            {
                return;
            }

            _selfTransform.anchoredPosition = _transformationCamera.WorldToScreenPoint(_target.PivotPoint);
        }

        private void UpdateHealthBar()
        {
            _healthBar.value = _target.Health;
        }

        public void Attach(IHealthIndicatorTarget indicatorTarget, Camera transformationCamera)
        {
            _target = indicatorTarget;
            _target.Killed += OnTargetKilled;
            _transformationCamera = transformationCamera;
        }

        private void OnTargetKilled()
        {
            _target.Killed -= OnTargetKilled;
            _target = null;
            _transformationCamera = null;
            Destroy(gameObject);
        }

        #endregion
    }
}