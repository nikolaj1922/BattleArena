using System;

namespace BattleArena.Characters.StateMachine
{
    public interface ITransition
    {
        Type From { get; }
        Type To { get; }

        bool CanTransition();
    }
}