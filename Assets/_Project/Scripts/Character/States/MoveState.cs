using UnityEngine;

namespace BattleArena.Characters.States
{
    public class MoveState : ICharacterState
    {
        public void Enter(Character character)
        {
            if (character.AttackTarget == null)
            {
                Debug.LogError("Attack target not found!");
                return;
            }

            character.Animation.PlayAnimation(character.Weapon.Data.moveAnimationType);
            character.Locomotion.MoveToTarget();
        }
        public void Tick(Character character) { }
        public void Exit(Character character)
        {
            character.Locomotion.StopMove();
            character.Animation.PlayAnimation(character.Weapon.Data.idleAnimationType);
        }
    }
}