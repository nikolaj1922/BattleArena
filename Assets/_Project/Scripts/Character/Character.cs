using System;
using UnityEngine;
using BattleArena.Characters.Managers;
using BattleArena.Weapons;
using BattleArena.Characters.StateMachine;

namespace BattleArena.Characters
{
    [RequireComponent(typeof(Rigidbody))]
    [RequireComponent(typeof(CharacterView))]
    [RequireComponent(typeof(CharacterAttack))]
    [RequireComponent(typeof(CharacterEffect))]
    [RequireComponent(typeof(CharacterAnimation))]
    [RequireComponent(typeof(CharacterLocomotion))]
    public class Character : MonoBehaviour
    {
        public event Action<Character> OnDeath;
        public event Action<float, float> OnHealthChanged;

        private CharacterStateMachine _stateMachine;

        public Rigidbody Rb { get; private set; }
        public CharacterView View { get; private set; }
        public CharacterEffect Effects { get; private set; }
        public CharacterAttack Attack { get; private set; }
        public CharacterAnimation Animation { get; private set; }
        public CharacterLocomotion Locomotion { get; private set; }


        [Header("Character data")]
        public CharacterData CharacterData { get; private set; }

        [Header("Character stats")]
        public float CurrentHealth { get; private set; }

        [Header("Attack Settings")]
        [SerializeField] private Transform _weaponSlot;
        public Weapon Weapon { get; private set; }
        public Character AttackTarget { get; private set; }

        private void Awake()
        {
            Rb = GetComponent<Rigidbody>();
            View = GetComponent<CharacterView>();
            Attack = GetComponent<CharacterAttack>();
            Effects = GetComponent<CharacterEffect>();
            Animation = GetComponent<CharacterAnimation>();
            Locomotion = GetComponent<CharacterLocomotion>();

            _stateMachine = new CharacterStateMachine(
                new IState[]
                    {
                        new IdleState(this),
                        new DeathState(this),
                        new AttackState(this),
                        new MoveState(this)
                    },
                new ITransition[]
                    {
                        new Transition<IdleState, MoveState>(() => AttackTarget != null),
                        new Transition<MoveState, AttackState>(() => CloseToAttackTarget()),
                        new Transition<AttackState, DeathState>(() => CurrentHealth <= 0),
                        new Transition<IdleState, DeathState>(() => CurrentHealth <= 0),
                        new Transition<AttackState, MoveState>(() => !CloseToAttackTarget()),
                        new Transition<AttackState, IdleState>(() => AttackTarget == null)
                    }
            );

            OnDeath += HandleDeath;
        }

        private void Update() => _stateMachine.Update();

        public void Init(CharacterData characterData)
        {
            CharacterData = characterData;
            CurrentHealth = characterData.health;

            View.HealthBar.Bind(this);
        }

        public void SetTarget(Character targetCharacter)
        {
            AttackTarget = targetCharacter;
        }

        public void SetWeapon(Weapon weapon)
        {
            weapon.transform.SetParent(_weaponSlot);
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
            OnDeath -= HandleDeath;
            Effects.ClearEffects();
        }

        private bool CloseToAttackTarget() =>
            AttackTarget != null && Weapon != null && Vector3.Distance(transform.position, AttackTarget.transform.position) <= Weapon.Data.attackRange;
    }

}