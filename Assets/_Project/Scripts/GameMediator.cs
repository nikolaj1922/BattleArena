using System;
using BattleArena.UI;

namespace BattleArena
{
    public class GameMediator : IDisposable
    {
        private readonly Battle _battleService;
        private readonly RestartPanel _restartGamePanel;

        public GameMediator(Battle battleService, RestartPanel restartGamePanel)
        {
            _battleService = battleService;
            _restartGamePanel = restartGamePanel;
        }

        public void Initialize()
        {
            _battleService.OnBattleEnded += EndBattle;
        }

        public void Dispose() => _battleService.OnBattleEnded -= EndBattle;

        public void EndBattle(string winnerName) => _restartGamePanel.Show(winnerName);

        public void RestartBattle()
        {
            _battleService.RestartBattle();
            _restartGamePanel.Hide();
        }
    }
}