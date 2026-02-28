using UnityEngine;
using BattleArena.Weapons;
using BattleArena.Characters;

namespace BattleArena.Battle
{
    public class BattleInstaller : MonoBehaviour
    {
        [SerializeField] private CharacterFactory _characterFactory;
        [SerializeField] private WeaponFactory _weaponFactory;
        [SerializeField] private Transform[] _spawnPoints;

        public BattleService Compose()
        {
            return new BattleService(
                _characterFactory,
                _weaponFactory,
                _spawnPoints,
                new CharacterDestroyer()
            );
        }
    }
}
