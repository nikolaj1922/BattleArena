namespace BattleArena.Characters.StateMachine
{
    public class AttackState : IUpdateCharacterState
    {
        private readonly Character _character;

        public AttackState(Character character)
        {
            _character = character;
        }

        public void OnUpdate()
        {
            _character.Attack.PerformAttack();
        }
    }
}