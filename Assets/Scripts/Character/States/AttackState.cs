namespace BattleArena.Characters.States
{
    public class AttackState : ICharacterState
    {
        public void Enter(Character character) { }
        public void Tick(Character character)
        {
            character.AttackManager.PerformAttack();
        }
        public void Exit(Character character) { }


    }
}