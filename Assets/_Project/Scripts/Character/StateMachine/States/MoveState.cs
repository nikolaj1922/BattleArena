using UnityEngine;

namespace BattleArena.Characters.StateMachine
{
    public class MoveState : IEnterCharacterState, IExitCharacterState
    {
        private readonly Character _character;

        public MoveState(Character character)
        {
            _character = character;
        }

        public void OnEnter()
        {
            if (_character.AttackTarget == null)
            {
                Debug.LogError("Attack target not found!");
                return;
            }

            _character.Animation.PlayAnimation(_character.Weapon.Data.moveAnimationType);
            _character.Locomotion.MoveToTarget();
        }

        public void OnExit()
        {
            _character.Locomotion.StopMove();
            _character.Animation.PlayAnimation(_character.Weapon.Data.idleAnimationType);
        }
    }
}