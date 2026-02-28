using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace BattleArena.UI
{
    public class RestartPanel : MonoBehaviour
    {
        [SerializeField] private Button _restartButton;
        [SerializeField] private TextMeshProUGUI _winnerName;

        private GameMediator _mediator;

        private void OnEnable() => _restartButton.onClick.AddListener(_mediator.RestartBattle);

        private void OnDisable() => _restartButton.onClick.RemoveListener(_mediator.RestartBattle);

        public void Init(GameMediator mediator) => _mediator = mediator;

        public void Hide() => gameObject.SetActive(false);

        public void Show(string winnerName)
        {
            _winnerName.text = $"Winner is {winnerName}";
            gameObject.SetActive(true);
        }
    }
}