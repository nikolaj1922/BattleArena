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
        public Rigidbody Rb { get; private set; }
        public CharacterView ViewManager { get; private set; }
        public CharacterState StateManager { get; private set; }
        public CharacterEffect EffectManager { get; private set; }
        public CharacterAttack AttackManager { get; private set; }
        public CharacterAnimation AnimationManager { get; private set; }
        public CharacterLocomotion LocomotionManager { get; private set; }


        [Header("Character data")]
        public CharacterData CharacterData { get; private set; }

        [Header("Character stats")]
        public float CurrentHealth { get; private set; }

        [Header("Attack Settings")]
        [SerializeField] Transform weaponSlot;
        public Weapon Weapon { get; private set; }
        public Character AttackTarget { get; private set; }

        public event Action OnDeath;
        public event Action<float, float> OnHealthChanged;


        private void Awake()
        {
            Rb = GetComponent<Rigidbody>();
            ViewManager = GetComponent<CharacterView>();
            StateManager = GetComponent<CharacterState>();
            AttackManager = GetComponent<CharacterAttack>();
            EffectManager = GetComponent<CharacterEffect>();
            AnimationManager = GetComponent<CharacterAnimation>();
            LocomotionManager = GetComponent<CharacterLocomotion>();

            OnDeath += HandleDeath;
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
            OnHealthChanged?.Invoke(CurrentHealth, CharacterData.health);
            ViewManager.ShowFloatingText(damage.ToString("0"), Color.white);

            if (CurrentHealth <= 0)
                OnDeath?.Invoke();

        }

        private void HandleDeath()
        {
            StateManager.ChangeState(StateManager.DeathState);
            EffectManager.ClearEffects();
        }
    }

}