using Assets.Scripts.Gameplay.Indicators;
using System.Linq;
using UnityEngine;

namespace Tanks.Gameplay.Indicators
{
    public class HealthIndicatorsSetup : MonoBehaviour
    {
        #region Editor

        [SerializeField]
        private RectTransform _parentTransform;

        [SerializeField]
        private Camera _transformationCamera;

        [SerializeField]
        private HealthIndicator _healthIndicatorPrefabRef;

        #endregion
        
        #region Methods

        private void Start()
        {
            AddHealthIndicators();
        }

        private void AddHealthIndicators()
        {
            var indicatorTargets = FindObjectsOfType<MonoBehaviour>().OfType<IHealthIndicatorTarget>();

            foreach (var indicatorTarget in indicatorTargets)
            {
                var indicatorInstance = Instantiate(_healthIndicatorPrefabRef, _parentTransform);
                indicatorInstance.Attach(indicatorTarget, _transformationCamera);
            }
        }

        #endregion
    }
}