using System;
using BattleArena.Battle;
using BattleArena.UI;

namespace BattleArena
{
    public class GameMediator : IDisposable
    {
        private readonly BattleService _battleService;
        private readonly RestartPanel _restartGamePanel;

        public GameMediator(BattleService battleService, RestartPanel restartGamePanel)
        {
            _battleService = battleService;
            _restartGamePanel = restartGamePanel;

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