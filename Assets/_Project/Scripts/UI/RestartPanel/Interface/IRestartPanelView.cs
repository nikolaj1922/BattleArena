using System;

namespace BattleArena.UI.RestartPanel
{
    public interface IRestartPanelView
    {
        event Action RestartClicked;
        void Hide();
        void Show();
    }
}