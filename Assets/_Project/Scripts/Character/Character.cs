using System;
using UnityEngine;
using BattleArena.Characters.Managers;
using BattleArena.Weapons;

namespace BattleArena.Characters
{
    [RequireComponent(typeof(Rigidbody))]
    [RequireComponent(typeof(CharacterViewManager))]
    [RequireComponent(typeof(CharacterStateManager))]
    [RequireComponent(typeof(CharacterAttackManager))]
    [RequireComponent(typeof(CharacterEffectManager))]
    [RequireComponent(typeof(CharacterAnimationManager))]
    [RequireComponent(typeof(CharacterLocomotionManager))]
    public class Character : MonoBehaviour
    {
        public Rigidbody Rb { get; private set; }
        public CharacterViewManager ViewManager { get; private set; }
        public CharacterStateManager StateManager { get; private set; }
        public CharacterEffectManager EffectManager { get; private set; }
        public CharacterAttackManager AttackManager { get; private set; }
        public CharacterAnimationManager AnimationManager { get; private set; }
        public CharacterLocomotionManager LocomotionManager { get; private set; }


        [Header("Character data")]
        public CharacterData CharacterData { get; private set; }

        [Header("Character stats")]
        public float CurrentHealth { get; private set; }

        [Header("Attack Settings")]
        [SerializeField] Transform weaponSlot;
        public Weapon Weapon { get; private set; }
        public Character AttackTarget { get; private set; }

        public Action OnDeath;


        private void Awake()
        {
            Rb = GetComponent<Rigidbody>();
            ViewManager = GetComponent<CharacterViewManager>();
            StateManager = GetComponent<CharacterStateManager>();
            AttackManager = GetComponent<CharacterAttackManager>();
            EffectManager = GetComponent<CharacterEffectManager>();
            AnimationManager = GetComponent<CharacterAnimationManager>();
            LocomotionManager = GetComponent<CharacterLocomotionManager>();

            OnDeath += () => StateManager.ChangeState(StateManager.DeathState);
            OnDeath += () => EffectManager.ClearEffects();
        }

        private void Update() => StateManager.CurrentState.Tick(this);

        public virtual void Init(CharacterData characterData)
        {
            StateManager.InitStates();

            CharacterData = characterData;
            CurrentHealth = characterData.health;

            StateManager.ChangeState(StateManager.IdleState);

            ViewManager.HealthBar.Bind(this);
        }

        public void SetTarget(Character targetCharacter)
        {
            AttackTarget = targetCharacter;
            StateManager.ChangeState(StateManager.MoveState);
        }

        public void SetWeapon(GameObject weaponObject)
        {
            if (!weaponObject.TryGetComponent(out Weapon weapon))
            {
                Debug.LogError("Object is not weapon!");
                return;
            }

            weaponObject.transform.SetParent(weaponSlot);
            weaponObject.transform.SetLocalPositionAndRotation(Vector3.zero, Quaternion.identity);
            Weapon = weapon;
            weapon.SetOwnerCharacter(this);
        }

        public void TakeDamage(float damage)
        {
            float newHealth = CurrentHealth - damage;

            CurrentHealth = Mathf.Max(0, newHealth);
            ViewManager.OnHealthChanged?.Invoke(CurrentHealth, CharacterData.health);
            ViewManager.ShowFloatingText(damage.ToString("0"), Color.white);

            if (CurrentHealth <= 0)
                OnDeath?.Invoke();

        }
    }

}