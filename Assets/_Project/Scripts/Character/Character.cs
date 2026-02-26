using System;
using UnityEngine;
using BattleArena.Characters.Managers;
using BattleArena.Weapons;

namespace BattleArena.Characters
{
    [RequireComponent(typeof(Rigidbody))]
    [RequireComponent(typeof(CharacterView))]
    [RequireComponent(typeof(CharacterState))]
    [RequireComponent(typeof(CharacterAttack))]
    [RequireComponent(typeof(CharacterEffect))]
    [RequireComponent(typeof(CharacterAnimation))]
    [RequireComponent(typeof(CharacterLocomotion))]
    public class Character : MonoBehaviour
    {
        public event Action<Character> OnDeath;
        public event Action<float, float> OnHealthChanged;

        public Rigidbody Rb { get; private set; }
        public CharacterView View { get; private set; }
        public CharacterState State { get; private set; }
        public CharacterEffect Effects { get; private set; }
        public CharacterAttack Attack { get; private set; }
        public CharacterAnimation Animation { get; private set; }
        public CharacterLocomotion Locomotion { get; private set; }


        [Header("Character data")]
        public CharacterData CharacterData { get; private set; }

        [Header("Character stats")]
        public float CurrentHealth { get; private set; }

        [Header("Attack Settings")]
        [SerializeField] Transform weaponSlot;
        public Weapon Weapon { get; private set; }
        public Character AttackTarget { get; private set; }

        private void Awake()
        {
            Rb = GetComponent<Rigidbody>();
            View = GetComponent<CharacterView>();
            State = GetComponent<CharacterState>();
            Attack = GetComponent<CharacterAttack>();
            Effects = GetComponent<CharacterEffect>();
            Animation = GetComponent<CharacterAnimation>();
            Locomotion = GetComponent<CharacterLocomotion>();

            OnDeath += HandleDeath;
        }

        private void Update() => State.CurrentState.Tick(this);

        public virtual void Init(CharacterData characterData)
        {
            State.InitStates();

            CharacterData = characterData;
            CurrentHealth = characterData.health;

            State.ChangeState(State.IdleState);

            View.HealthBar.Bind(this);
        }

        public void SetTarget(Character targetCharacter)
        {
            AttackTarget = targetCharacter;
            State.ChangeState(State.MoveState);
        }

        public void SetWeapon(Weapon weapon)
        {
            weapon.transform.SetParent(weaponSlot);
            weapon.transform.SetLocalPositionAndRotation(Vector3.zero, Quaternion.identity);
            Weapon = weapon;
            weapon.SetOwnerCharacter(this);
        }

        public void TakeDamage(float damage)
        {
            float newHealth = CurrentHealth - damage;

            CurrentHealth = Mathf.Max(0, newHealth);
            OnHealthChanged?.Invoke(CurrentHealth, CharacterData.health);
            View.ShowFloatingText(damage.ToString("0"), Color.white);

            if (CurrentHealth <= 0)
                OnDeath?.Invoke(this);

        }

        private void HandleDeath(Character character)
        {
            State.ChangeState(State.DeathState);
            Effects.ClearEffects();
        }
    }

}