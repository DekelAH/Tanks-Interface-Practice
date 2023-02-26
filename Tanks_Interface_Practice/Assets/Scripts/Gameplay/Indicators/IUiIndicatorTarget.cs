using System;
using UnityEngine;

namespace Assets.Scripts.Gameplay.Indicators
{
    public interface IUiIndicatorTarget
    {
        Vector3 PivotPoint { get; }

        event Action Killed;
    }
}
