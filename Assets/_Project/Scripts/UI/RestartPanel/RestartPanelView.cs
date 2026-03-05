using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace BattleArena.UI.RestartPanel
{
    public class RestartPanelView : MonoBehaviour, IRestartPanelView
    {
        public event Action RestartClicked;

        [SerializeField] private Button _restartButton;
        [SerializeField] private TextMeshProUGUI _winnerName;

        private void OnEnable() => _restartButton.onClick.AddListener(OnRestartClicked);

        private void OnDisable() => _restartButton.onClick.RemoveListener(OnRestartClicked);

        public void Hide() => gameObject.SetActive(false);

        public void Show(string winnerName)
        {
            _winnerName.text = $"Winner is {winnerName}";
            gameObject.SetActive(true);
        }

        private void OnRestartClicked() => RestartClicked?.Invoke();
    }
}