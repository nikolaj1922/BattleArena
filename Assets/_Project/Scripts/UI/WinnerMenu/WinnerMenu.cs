using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace BattleArena.UI
{
    public class WinnerMenu : MonoBehaviour
    {
        public event Action OnRestartClicked;

        [SerializeField] private Button _restartButton;
        [SerializeField] private TextMeshProUGUI _winnerName;

        private void OnEnable() => _restartButton.onClick.AddListener(HandleRestartClick);

        private void OnDisable() => _restartButton.onClick.RemoveListener(HandleRestartClick);

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

        private void HandleRestartClick()
        {
            OnRestartClicked?.Invoke();
        }
    }
}