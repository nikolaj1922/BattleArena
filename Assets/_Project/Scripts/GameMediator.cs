using System;
using BattleArena.UI;
using Zenject;

namespace BattleArena
{
    public class GameMediator : IInitializable, IDisposable
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
            _restartGamePanel.RestartClicked += RestartBattle;
        }

        public void Dispose()
        {
            _battleService.OnBattleEnded -= EndBattle;
            _restartGamePanel.RestartClicked -= RestartBattle;
        }

        private void EndBattle(string winnerName) => _restartGamePanel.Show(winnerName);

        private void RestartBattle()
        {
            _battleService.RestartBattle();
            _restartGamePanel.Hide();
        }
    }
}