namespace BattleArena.Characters.StateMachine
{
    public class IdleState : IEnterState
    {
        private readonly Character _character;

        public IdleState(Character character)
        {
            _character = character;
        }

        public void OnEnter()
        {
            _character.Animation.PlayAnimation(_character.Weapon.Data.idleAnimationType);
        }
    }
}