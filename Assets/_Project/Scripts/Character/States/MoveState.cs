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

            character.AnimationManager.PlayAnimation(character.Weapon.weaponData.moveAnimationType);
            character.LocomotionManager.MoveToTarget();
        }
        public void Tick(Character character) { }
        public void Exit(Character character)
        {
            character.LocomotionManager.StopMove();
            character.AnimationManager.PlayAnimation(character.Weapon.weaponData.idleAnimationType);
        }
    }
}