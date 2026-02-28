using BattleArena.FSM;

namespace BattleArena.Characters.States
{
    public class AttackState : IUpdateState
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