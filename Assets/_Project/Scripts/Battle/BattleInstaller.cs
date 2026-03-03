using UnityEngine;
using BattleArena.Weapons;
using BattleArena.Characters;
using BattleArena.Characters.Config;
using BattleArena.Weapons.Config;

namespace BattleArena
{
    public class BattleInstaller : MonoBehaviour
    {
        [SerializeField] private Transform[] _spawnPoints;
        [SerializeField] private CharacterConfig _characterConfig;
        [SerializeField] private WeaponConfig _weaponConfig;

        public Battle Compose()
        {
            return new Battle(
                new CharacterFactory(_characterConfig),
                new WeaponFactory(_weaponConfig),
                _spawnPoints,
                new CharacterDestroyer()
            );
        }
    }
}
