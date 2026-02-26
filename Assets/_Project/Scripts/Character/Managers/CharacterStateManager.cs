using UnityEngine;
using BattleArena.Characters.States;

namespace BattleArena.Characters.Managers
{
    [RequireComponent(typeof(Character))]
    public class CharacterStateManager : MonoBehaviour
    {
        private Character _character;

        [Header("Character states")]
        public ICharacterState IdleState { get; private set; }
        public ICharacterState MoveState { get; private set; }
        public ICharacterState AttackState { get; private set; }
        public ICharacterState DeathState { get; private set; }
        public ICharacterState CurrentState { get; private set; }

        private void Awake()
        {
            _character = GetComponent<Character>();
        }

        public void InitStates()
        {
            IdleState = new IdleState();
            MoveState = new MoveState();
            AttackState = new AttackState();
            DeathState = new DeathState();
        }

        public void ChangeState(ICharacterState newState)
        {
            CurrentState?.Exit(_character);
            CurrentState = newState;
            CurrentState.Enter(_character);
        }
    }
}

