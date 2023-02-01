using Tanks.Infrastructure;
using Tanks.Gameplay.Components;
using UnityEngine;
using Assets.Scripts.Gameplay.Factories;

namespace Tanks.Gameplay.Wehicles
{
    [RequireComponent(typeof(Animator))]
    [RequireComponent(typeof(Rigidbody2D))]
    public class Tank : MonoBehaviour
    {
        #region Consts

        private const string FIRE_TRIGGER_NAME = "fire";

        #endregion

        #region Editor

        [SerializeField]
        private Animator _animator;

        [SerializeField]
        private Rigidbody2D _rb;

        [SerializeField]
        [Range(0.1f, 2f)]
        private float _moveSpeed;

        [SerializeField]
        [Range(0.1f, 2f)]
        private float _turnSpeed;

        [SerializeField]
        private Transform _firePosition;

        [SerializeField]
        private CooldownComponent _cooldownComponent;

        [SerializeField]
        private ProjectileFactory _projectileFactory;

        #endregion

        #region Fields

        private int _fireTriggerHash;

        #endregion

        #region Methods

        private void Awake()
        {
            _fireTriggerHash = Animator.StringToHash(FIRE_TRIGGER_NAME);
        }

        private void FixedUpdate()
        {
            Move(InputManager.GetMovementInput());
            Rotate(InputManager.GetRotationInput());
        }

        private void Update()
        {
            if (InputManager.IsFireRequested())
            {
                Fire();
            }
        }

        private void Rotate(float rotationInput)
        {
            transform.RotateAround(transform.position, Vector3.back, rotationInput * _turnSpeed);
        }

        private void Move(float moveInput)
        {
            _rb.velocity = _moveSpeed * moveInput * transform.up;
        }

        private void Fire()
        {
            if (_cooldownComponent.IsInCooldown)
            {
                return;
            }

            var projectile = _projectileFactory.Create();
            projectile.Fire(_firePosition.position, transform.up);

            _animator.SetTrigger(_fireTriggerHash);
            _cooldownComponent.Begin();
        }

        #endregion
    }
}