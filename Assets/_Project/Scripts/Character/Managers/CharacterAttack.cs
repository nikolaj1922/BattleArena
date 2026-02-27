using UnityEngine;
using System.Collections.Generic;
using BattleArena.Interfaces;



namespace BattleArena.Characters.Managers
{
    [RequireComponent(typeof(Character))]
    public class CharacterAttack : MonoBehaviour
    {
        private Character _character;
        private int _attackBlockCounter = 0;
        private float _lastTimeAttack;
        private readonly List<IDamageModifier> _damageModifiers = new();

        private void Awake()
        {
            _character = GetComponent<Character>();
        }

        public void PerformAttack()
        {
            if (_character.AttackTarget.CurrentHealth <= 0)
                return;

            float targetDistance = Vector3.Distance(
                _character.transform.position,
                _character.AttackTarget.transform.position
            );

            if (targetDistance > _character.Weapon.Data.attackRange)
                return;

            bool isAttackCooldownAvailable = (Time.time - _lastTimeAttack) > _character.Weapon.Data.attackCooldown;

            if (_attackBlockCounter == 0 && isAttackCooldownAvailable)
            {
                IncreaseBlockCounter();
                _lastTimeAttack = Time.time;

                _character.Weapon.StartAttack();
            }
        }

        public void ExecuteAttack() => _character.Weapon.ExecuteAttack();

        public void IncreaseBlockCounter() => _attackBlockCounter++;

        public void DecreaseBlockCounter() => _attackBlockCounter--;

        public void AddDamageModifier(IDamageModifier modifier) => _damageModifiers.Add(modifier);

        public void RemoveDamageModifier(IDamageModifier modifier) => _damageModifiers.Remove(modifier);

        public float GetFinalDamage(float baseDamage)
        {
            float finalDamage = baseDamage;

            foreach (var modifier in _damageModifiers)
            {
                finalDamage = modifier.Modify(finalDamage);
            }

            return Mathf.Max(0, finalDamage);
        }
    }
}
