using Assets.Scripts.Gameplay.Indicators;
using System.Collections;
using UnityEngine;
using System;

namespace Tanks.Gameplay.Components
{
    public class CooldownComponent : MonoBehaviour, ICoolDownIndicatorTarget
    {
        #region Events

        public event Action Killed;

        #endregion

        #region Editor

        [SerializeField]
        private float _cooldownTime;

        [SerializeField]
        private Transform _indicatorPivot;

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

        public float CooldownProgress { get; set; }

        public float InverseCooldownProgress => 1 - CooldownProgress;
        
        public bool IsInCooldown { get; private set; }

        public Vector3 PivotPoint => _indicatorPivot.position;

        #endregion
    }
}