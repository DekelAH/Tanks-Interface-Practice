using Assets.Scripts.Gameplay.Projectiles;
using System;
using Tanks.Gameplay.Projectiles;
using UnityEngine;

namespace Assets.Scripts.Gameplay.Factories
{
    public class PixelProjectileFactory : ProjectileFactory
    {
        #region Editor

        [SerializeField]
        private Projectile _pixelProjectilePrefabRef;

        #endregion

        #region Methods

        public override IProjectile Create()
        {
            var prefabInstance = Instantiate(_pixelProjectilePrefabRef);
            var projectile = prefabInstance.GetComponent<IProjectile>();
            if (projectile == null)
            {
                throw new InvalidOperationException("Can't find IProjectile on the instantiate prefab");
            }

            return projectile;
        }

        #endregion
    }
}
