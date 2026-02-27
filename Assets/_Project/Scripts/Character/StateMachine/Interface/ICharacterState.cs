namespace BattleArena.Characters.StateMachine
{
    public interface ICharacterState { }

    public interface IEnterCharacterState : ICharacterState
    {
        void OnEnter();
    }

    public interface IExitCharacterState : ICharacterState
    {
        void OnExit();
    }

    public interface IUpdateCharacterState : ICharacterState
    {
        void OnUpdate();
    }
}

