using BattleArena.Battle;
using BattleArena.UI;
using UnityEngine;

namespace BattleArena
{
    public class GameEntryPoint : MonoBehaviour
    {
        [SerializeField] private BattleInstaller _installer;
        [SerializeField] private RestartPanel _restartGamePanel;

        private GameMediator _mediator;

        private void Awake()
        {
            BattleService battleService = _installer.Compose();

            RestartPanel restartPanelInstance = Instantiate(_restartGamePanel);

            _mediator = new(battleService, restartPanelInstance);

            restartPanelInstance.Init(_mediator);

            battleService.StartBattle();
        }

        public void OnDestroy()
        {
            _mediator?.Dispose();
        }
    }
}