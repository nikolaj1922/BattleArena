namespace BattleArena.Characters.StateMachine
{
    public interface IState { }

    public interface IEnterState : IState
    {
        void OnEnter();
    }

    public interface IExitState : IState
    {
        void OnExit();
    }

    public interface IUpdateState : IState
    {
        void OnUpdate();
    }
}

