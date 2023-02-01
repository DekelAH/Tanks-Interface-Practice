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
        
        #endregion
        
        #region Methods

        private void Start()
        {
            AddCooldownIndicators();
        }

        private void AddCooldownIndicators()
        {
        }

        #endregion
    }
}