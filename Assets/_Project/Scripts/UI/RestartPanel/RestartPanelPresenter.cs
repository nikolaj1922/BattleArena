using System;
using Zenject;
using BattleArena.Battle;

namespace BattleArena.UI.RestartPanel
{
    public class RestartPanelPresenter : IInitializable, IDisposable
    {
        private readonly IRestartPanelView _view;
        private readonly IRestartPanelModel _model;
        private readonly IRestartBattle _battle;

        public RestartPanelPresenter(IRestartPanelView view, IRestartPanelModel model, IRestartBattle battle)
        {
            _view = view;
            _model = model;
            _battle = battle;
        }

        public void Initialize()
        {
            _view.RestartClicked += RestartBattle;
            _battle.OnBattleEnded += ShowWinner;
        }

        public void Dispose()
        {
            _view.RestartClicked -= RestartBattle;
            _battle.OnBattleEnded -= ShowWinner;
        }

        private void ShowWinner(string winnerName)
        {
            _model.SetWinnerName(winnerName);
            _view.Show(winnerName);
        }

        private void RestartBattle()
        {
            _battle.RestartBattle();
            _model.SetWinnerName(null);
            _view.Hide();
        }
    }
}