using System.Collections;
using UnityEngine;

namespace Tanks.Gameplay.Components
{
    public class CooldownComponent : MonoBehaviour
    {
        #region Editor

        [SerializeField]
        private float _cooldownTime;

        #endregion
        
        #region Methods

        public void Begin()
        {
            IsInCooldown = true;
            StartCoroutine(CooldownCoroutine(_cooldownTime));
        }

        private IEnumerator CooldownCoroutine(float cooldownTime)
        {
            IsInCooldown = true;
            var currentCooldownTime = 0f;
            while (currentCooldownTime < cooldownTime)
            {
                CooldownProgress = currentCooldownTime / cooldownTime;
                currentCooldownTime += Time.deltaTime;
                yield return null;
            }

            IsInCooldown = false;
        }

        #endregion

        #region Properties

        private float CooldownProgress { get; set; }

        public float InverseCooldownProgress => 1 - CooldownProgress;
        
        public bool IsInCooldown { get; private set; }

        #endregion
    }
}