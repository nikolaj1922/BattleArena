using System;
using Zenject;

namespace BattleArena.UI.RestartPanel
{
    public class RestartPanelPresenter : IInitializable, IDisposable
    {
        private readonly RestartPanelView _view;
        private readonly RestartPanelModel _model;

        public RestartPanelPresenter(RestartPanelView view, RestartPanelModel model)
        {
            _view = view;
            _model = model;
        }

        public void Initialize()
        {
            _view.OnRestartClicked += OnRestartClicked;
            _model.OnBattleEnded += _view.Show;
        }

        public void Dispose()
        {
            _view.OnRestartClicked -= OnRestartClicked;
            _model.OnBattleEnded -= _view.Show;
        }


        private void OnRestartClicked()
        {
            _model.RestartBattle();
            _view.Hide();
        }
    }
}