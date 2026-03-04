namespace BattleArena.UI.RestartPanel
{
    public class RestartPanelModel : IRestartPanelModel
    {
        public string WinnerName { get; private set; }
        public void SetWinnerName(string winnerName) => WinnerName = winnerName;
    }
}