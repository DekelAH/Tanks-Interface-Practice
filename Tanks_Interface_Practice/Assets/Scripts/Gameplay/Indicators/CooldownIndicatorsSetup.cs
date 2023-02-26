using Assets.Scripts.Gameplay.Indicators;
using System.Linq;
using UnityEngine;

namespace Tanks.Gameplay.Indicators
{
    public class CooldownIndicatorsSetup : MonoBehaviour
    {
        #region Editor

        [SerializeField]
        private RectTransform _parentTransform;

        [SerializeField]
        private Camera _transformationCamera;

        [SerializeField]
        private CooldownIndicator _cooldownIndicatorPrefabRef;
        
        #endregion
        
        #region Methods

        private void Start()
        {
            AddCooldownIndicators();
        }

        private void AddCooldownIndicators()
        {
            var cooldownIndicatorTargets = FindObjectsOfType<MonoBehaviour>().OfType<ICoolDownIndicatorTarget>();

            foreach (var cooldownIndicatorTarget in cooldownIndicatorTargets)
            {
                var cooldownIndicatorInstance = Instantiate(_cooldownIndicatorPrefabRef, _parentTransform);
                cooldownIndicatorInstance.Attach(cooldownIndicatorTarget, _transformationCamera);
            }
        }

        #endregion
    }
}