using UnityEngine;
using BattleArena.Weapons;
using BattleArena.Characters;
using BattleArena.UI;

namespace BattleArena.Battle
{
    public class BattleInstaller : MonoBehaviour
    {
        [SerializeField] private CharacterFactory _characterFactory;
        [SerializeField] private WeaponFactory _weaponFactory;
        [SerializeField] private Transform[] _spawnPoints;
        [SerializeField] private RestartPanel _restartGamePanel;

        public void Compose()
        {
            RestartPanel restartPanelInstance = Instantiate(_restartGamePanel);

            BattleService battleService = new(
                _characterFactory,
                _weaponFactory,
                _spawnPoints,
                new CharacterDestroyer()
            );

            GameMediator mediator = new(battleService, restartPanelInstance);

            restartPanelInstance.Init(mediator);

            battleService.StartBattle();
        }
    }
}
