using System;
using BattleArena.Battle;

namespace BattleArena.UI.RestartPanel
{
    public class RestartPanelModel : IDisposable
    {
        private readonly IRestartBattle _battle;
        public event Action<string> OnBattleEnded;

        public RestartPanelModel(IRestartBattle battle)
        {
            _battle = battle;
            _battle.OnBattleEnded += HandleBattleEnded;
        }

        public void RestartBattle()
        {
            _battle.RestartBattle();
        }

        public void Dispose() => _battle.OnBattleEnded -= HandleBattleEnded;

        private void HandleBattleEnded(string winnerName)
        {
            OnBattleEnded?.Invoke(winnerName);
        }
    }
}