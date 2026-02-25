using TMPro;
using UnityEngine;

namespace BattleArena.UI
{
    public class WinnerMenu : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _winnerName;

        public void Show(string winnerName)
        {
            _winnerName.text = $"Winner is {winnerName}";
            gameObject.SetActive(true);
        }

        public void Hide()
        {
            _winnerName.text = null;
            gameObject.SetActive(false);
        }
    }
}