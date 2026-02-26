using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace BattleArena.UI
{
    public class WinnerMenu : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _winnerName;
        [SerializeField] private Button _restartButton;

        public Action OnResetClicked;

        private void Awake()
        {
            _restartButton.onClick.AddListener(() =>
            {
                OnResetClicked?.Invoke();
            });
        }

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