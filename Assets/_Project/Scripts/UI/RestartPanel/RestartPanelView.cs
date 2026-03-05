using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace BattleArena.UI.RestartPanel
{
    public class RestartPanelView : MonoBehaviour
    {
        public event Action OnRestartClicked;

        [SerializeField] private Button _restartButton;
        [SerializeField] private TextMeshProUGUI _winnerName;

        private void OnEnable() => _restartButton.onClick.AddListener(RestartClicked);

        private void OnDisable() => _restartButton.onClick.RemoveListener(RestartClicked);

        public void Hide() => gameObject.SetActive(false);

        public void Show(string winnerName)
        {
            _winnerName.text = $"Winner is {winnerName}";
            gameObject.SetActive(true);
        }

        private void RestartClicked() => OnRestartClicked?.Invoke();
    }
}