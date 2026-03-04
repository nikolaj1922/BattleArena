namespace BattleArena.UI.RestartPanel
{
    public interface IRestartPanelModel
    {
        string WinnerName { get; }
        void SetWinnerName(string winnerName);
    }
}