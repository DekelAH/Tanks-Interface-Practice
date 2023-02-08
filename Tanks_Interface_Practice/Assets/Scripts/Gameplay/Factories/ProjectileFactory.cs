using Assets.Scripts.Gameplay.Projectiles;
using UnityEngine;

namespace Assets.Scripts.Gameplay.Factories
{
    public abstract class ProjectileFactory : MonoBehaviour
    {
        #region Methods

        public abstract IProjectile Create();

        #endregion
    }
}
