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
        
        #endregion
        
        #region Methods

        private void Start()
        {
            AddHealthIndicators();
        }

        private void AddHealthIndicators()
        {
        }

        #endregion
    }
}