using Zenject;
using UnityEngine;
using BattleArena.Weapons;
using BattleArena.Battle;
using BattleArena.Characters;
using BattleArena.Characters.Config;
using BattleArena.Weapons.Config;
using BattleArena.Infrastructure.ObjectPool;
using BattleArena.UI.FloatingText;

namespace BattleArena.Infrastructure.DI.SceneContext
{
    public class BattleInstaller : MonoInstaller
    {
        [SerializeField] private Transform[] _spawnPoints;
        [SerializeField] private CharacterConfig _characterConfig;
        [SerializeField] private WeaponConfig _weaponConfig;
        [SerializeField] private FloatingTextCanvas _floatTextPrefab;

        public override void InstallBindings()
        {
            Container.Bind<ObjectPool<FloatingTextCanvas>>().AsSingle().WithArguments(_floatTextPrefab);

            Container.Bind<CharacterConfig>().FromInstance(_characterConfig).AsSingle();
            Container.Bind<WeaponConfig>().FromInstance(_weaponConfig).AsSingle();

            Container.Bind<CharacterFactory>().AsSingle();
            Container.Bind<WeaponFactory>().AsSingle();

            Container.Bind<ICharacterDestroyer>().To<CharacterDestroyer>().AsSingle();

            Container.BindInterfacesAndSelfTo<BattleManager>().AsSingle().WithArguments(_spawnPoints);
        }
    }
}
