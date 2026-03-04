using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace BattleArena.UI.RestartPanel
{
    public class RestartPanelView : MonoBehaviour, IRestartPanelView
    {
        public event Action RestartClicked;

        [SerializeField] private Button _restartButton;
        [SerializeField] private TextMeshProUGUI _winnerName;
        private IRestartPanelModel _model;

        private void OnEnable() => _restartButton.onClick.AddListener(OnRestartClicked);

        private void OnDisable() => _restartButton.onClick.RemoveListener(OnRestartClicked);

        [Inject]
        public void Construct(IRestartPanelModel model) => _model = model;

        public void Hide() => gameObject.SetActive(false);

        public void Show()
        {
            _winnerName.text = $"Winner is {_model.WinnerName}";
            gameObject.SetActive(true);
        }

        private void OnRestartClicked() => RestartClicked?.Invoke();
    }
}