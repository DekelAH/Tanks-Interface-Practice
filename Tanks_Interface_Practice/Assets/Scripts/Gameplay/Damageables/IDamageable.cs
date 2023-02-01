using UnityEngine;

namespace Assets.Scripts.Gameplay.Damageables
{
    public interface IDamageable
    {
        void Damage(int damageAmount, Vector2 hitDirection);
    }
}
