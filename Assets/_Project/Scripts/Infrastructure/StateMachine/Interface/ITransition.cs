using System;

namespace BattleArena.FSM
{
    public interface ITransition
    {
        Type From { get; }
        Type To { get; }

        bool CanTransition();
    }
}