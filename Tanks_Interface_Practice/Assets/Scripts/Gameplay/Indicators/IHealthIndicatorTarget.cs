using System;
using UnityEngine;

namespace Assets.Scripts.Gameplay.Indicators
{
    public interface IHealthIndicatorTarget : IUiIndicatorTarget
    {
        int Health { get; }
    }
}
