using System;
using UnityEngine;

namespace Assets.Scripts.Gameplay.Indicators
{
    public interface ICoolDownIndicatorTarget : IUiIndicatorTarget
    {
        float CooldownProgress { get; }

        bool IsInCooldown { get; }

    }
}
