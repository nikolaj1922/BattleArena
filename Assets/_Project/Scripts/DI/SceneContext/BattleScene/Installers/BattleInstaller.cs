using Zenject;
using UnityEngine;
using BattleArena.Weapons;
using BattleArena.Battle;
using BattleArena.Characters;
using BattleArena.Characters.Config;
using BattleArena.Weapons.Config;

namespace BattleArena
{
    public class BattleInstaller : MonoInstaller
    {
        [SerializeField] private Transform[] _spawnPoints;
        [SerializeField] private CharacterConfig _characterConfig;
        [SerializeField] private WeaponConfig _weaponConfig;

        public override void InstallBindings()
        {
            Container.Bind<CharacterConfig>().FromInstance(_characterConfig).AsSingle();
            Container.Bind<WeaponConfig>().FromInstance(_weaponConfig).AsSingle();

            Container.Bind<CharacterFactory>().AsSingle();
            Container.Bind<WeaponFactory>().AsSingle();

            Container.Bind<ICharacterDestroyer>().To<CharacterDestroyer>().AsSingle();

            Container.BindInterfacesAndSelfTo<BattleManager>().AsSingle().WithArguments(_spawnPoints);
        }
    }
}
