using System;
using BattleArena.Battle;

namespace BattleArena.UI.RestartPanel
{
    public class RestartPanelModel : IDisposable
    {
        private readonly IRestartBattle _battle;

        public event Action<string> OnBattleEnded;

        public string WinnerName { get; private set; }

        public RestartPanelModel(IRestartBattle battle)
        {
            _battle = battle;
            _battle.OnBattleEnded += HandleBattleEnded;
        }

        private void HandleBattleEnded(string winnerName)
        {
            WinnerName = winnerName;
            OnBattleEnded?.Invoke(winnerName);
        }

        public void RestartBattle()
        {
            _battle.RestartBattle();
            WinnerName = null;
        }

        public void Dispose() => _battle.OnBattleEnded -= HandleBattleEnded;

    }
}