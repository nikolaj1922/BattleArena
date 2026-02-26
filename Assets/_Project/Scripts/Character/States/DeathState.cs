using BattleArena.Characters.Managers;

namespace BattleArena.Characters.States
{
    public class DeathState : ICharacterState
    {
        public void Enter(Character character)
        {
            character.Animation.PlayAnimation(CharacterAnimationType.Death);
        }
        public void Tick(Character character) { }
        public void Exit(Character character) { }
    }
}