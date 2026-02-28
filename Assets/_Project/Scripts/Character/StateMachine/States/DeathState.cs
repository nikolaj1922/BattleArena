using BattleArena.Characters.Managers;

namespace BattleArena.Characters.StateMachine
{
    public class DeathState : IEnterState
    {
        private readonly Character _character;

        public DeathState(Character character)
        {
            _character = character;
        }

        public void OnEnter()
        {
            _character.Animation.PlayAnimation(CharacterAnimationType.Death);
        }
    }
}