using Assets.Scripts.Gameplay.Projectiles;
using System;
using Tanks.Gameplay.Projectiles;
using Tanks.Infrastructure;
using UnityEngine;

namespace Assets.Scripts.Gameplay.Factories
{
    public class PixelProjectileFactory : ProjectileFactory
    {
        #region Editor

        [SerializeField]
        private Projectile[] _pixelProjectilePrefabRefs;

        #endregion

        #region Fields

        private Projectile _selectedProjectile;
        private int _projectileIndex = 0;

        #endregion

        #region Methods

        private void Start()
        {
            _selectedProjectile = _pixelProjectilePrefabRefs[_projectileIndex];
        }

        private void Update()
        {
            ProjectileChoosing();
        }

        private void ProjectileChoosing()
        {
            if (InputManager.IsSelectRightRequested())
            {
                if (_projectileIndex >= _pixelProjectilePrefabRefs.Length - 1)
                {
                    return;
                }

                _projectileIndex++;
                _selectedProjectile = _pixelProjectilePrefabRefs[_projectileIndex];
            }
            else if (InputManager.IsSelectLeftRequested())
            {
                if (_projectileIndex <= 0)
                {
                    return;
                }

                _projectileIndex--;
                _selectedProjectile = _pixelProjectilePrefabRefs[_projectileIndex];
            }
        }

        public override IProjectile Create()
        {
            var prefabInstance = Instantiate(_selectedProjectile);
            var projectile = prefabInstance.GetComponent<IProjectile>();
            if (projectile == null)
            {
                throw new InvalidOperationException("Can't find IProjectile on the instantiated prefab");
            }

            return projectile;
        }

        #endregion
    }
}
