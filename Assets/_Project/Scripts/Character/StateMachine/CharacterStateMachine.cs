using System;
using System.Linq;

namespace BattleArena.Characters.StateMachine
{
    public class CharacterStateMachine
    {
        private ICharacterState _currentState;
        private readonly ICharacterState[] _states;
        private readonly ITransition[] _transitions;

        public CharacterStateMachine(ICharacterState[] states, ITransition[] transitions)
        {
            _states = states;
            _transitions = transitions;

            _currentState = _states[0];
        }

        public void Update()
        {
            if (_currentState is IUpdateCharacterState updateState)
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
            if (_currentState is IExitCharacterState exitState)
                exitState.OnExit();

            _currentState = _states.First(s => s.GetType() == to);

            if (_currentState is IEnterCharacterState enterState)
                enterState.OnEnter();
        }
    }
}