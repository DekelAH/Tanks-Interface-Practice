using Assets.Scripts.Gameplay.Projectiles;
using Tanks.Infrastructure;
using UnityEngine;

namespace Assets.Scripts.Gameplay.Factories
{
    public abstract class ProjectileFactory : MonoBehaviour
    {
        #region Methods

        private void FixedUpdate()
        {
            
        }

        private IProjectile ProjectileChoosing()
        {
            if (InputManager.IsSelectRightRequested())
            {
                return Create();
            }
            else if (InputManager.IsSelectLeftRequested())
            {
                return Create();
            }

            return null;
        }

        public abstract IProjectile Create();

        #endregion
    }
}
