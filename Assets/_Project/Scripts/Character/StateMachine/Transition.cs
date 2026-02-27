using System;

namespace BattleArena.Characters.StateMachine
{
    public class Transition<TFrom, TTo> : ITransition
        where TFrom : ICharacterState where TTo : ICharacterState
    {
        private readonly Func<bool> _condition;
        public Type From { get; }
        public Type To { get; }

        public Transition(Func<bool> condition)
        {
            _condition = condition;

            From = typeof(TFrom);
            To = typeof(TTo);
        }

        public bool CanTransition() => _condition();
    }
}