namespace BattleArena.Characters.States
{
    public interface ICharacterState
    {
        void Enter(Character character);
        void Tick(Character character);
        void Exit(Character character);
    }
}

