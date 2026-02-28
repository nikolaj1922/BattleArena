using System;
using System.Linq;

namespace BattleArena.Characters.StateMachine
{
    public class CharacterStateMachine
    {
        private IState _currentState;
        private readonly IState[] _states;
        private readonly ITransition[] _transitions;

        public CharacterStateMachine(IState[] states, ITransition[] transitions)
        {
            _states = states;
            _transitions = transitions;

            _currentState = _states[0];
        }

        public void Update()
        {
            if (_currentState is IUpdateState updateState)
                updateState.OnUpdate();

            foreach (ITransition transition in _transitions)
            {
                if (transition.From == _currentState.GetType() && transition.CanTransition())
                {
                    SwitchState(transition.To);
                }
            }
        }

        private void SwitchState(Type to)
        {
            if (_currentState is IExitState exitState)
                exitState.OnExit();

            _currentState = _states.First(s => s.GetType() == to);

            if (_currentState is IEnterState enterState)
                enterState.OnEnter();
        }
    }
}