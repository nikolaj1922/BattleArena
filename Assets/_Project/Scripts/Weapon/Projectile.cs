using System;
using BattleArena.Characters;
using UnityEngine;

namespace BattleArena.Weapons
{
    public class Projectile : MonoBehaviour
    {
        [SerializeField] private float _speed;

        private Vector3 _direction;
        private float _damage;
        private Character _owner;

        public event Action OnHit;

        public void Init(Vector3 direction, float damage, Character attacker)
        {
            _direction = direction.normalized;
            _damage = damage;
            _owner = attacker;

            transform.rotation = Quaternion.LookRotation(_direction);
        }

        void Update()
        {
            transform.position += _speed * Time.deltaTime * _direction;
        }

        void OnTriggerEnter(Collider other)
        {
            var target = other.GetComponent<Character>();
            if (target != null && target != _owner)
            {
                target.TakeDamage(_owner.AttackManager.GetFinalDamage(_damage));
                OnHit?.Invoke();
                Destroy(gameObject);
            }
        }
    }
}
