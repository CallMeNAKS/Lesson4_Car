using System;
using System.Collections;
using UnityEngine;

namespace CodeBase.Enemy
{
    public class RedEnemy : AbstractEnemy
    {
        private Rigidbody _rb;
        [SerializeField] private float _moveSpeed = 5f;
        [SerializeField] private float _changeDirectionInterval = 2f;
        [SerializeField] private float _smoothTime = 0.5f;

        private Vector3 _targetDirection;
        private Vector3 _velocity = Vector3.zero;

        private void OnEnable()
        {
            _rb = GetComponent<Rigidbody>();
        }

        public override void Attack()
        {
            Debug.Log("Attack");
        }

        public override void Move()
        {
            StartCoroutine(RandomMoving());
        }
        private IEnumerator RandomMoving()
        {
            while (gameObject.activeSelf)
            {
                SetRandomDirection();
                for (float timer = 0; timer < _changeDirectionInterval; timer += Time.deltaTime)
                {
                    MoveTowardsDirection();
                    yield return null;
                }
            }
        }

        private void SetRandomDirection()
        {
            _targetDirection = new Vector3(
                UnityEngine.Random.Range(-1f, 1f),
                0,
                UnityEngine.Random.Range(-1f, 1f)).normalized;
        }

        private void MoveTowardsDirection()
        {
            Vector3 smoothDirection = Vector3.SmoothDamp(
                _rb.velocity,
                _targetDirection * _moveSpeed,
                ref _velocity,
                _smoothTime);

            _rb.velocity = smoothDirection;
        }
    }
}
