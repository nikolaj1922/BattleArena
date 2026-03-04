using System;

namespace BattleArena.Battle
{
    public interface IRestartBattle
    {
        event Action<string> OnBattleEnded;
        void RestartBattle();
    }
}