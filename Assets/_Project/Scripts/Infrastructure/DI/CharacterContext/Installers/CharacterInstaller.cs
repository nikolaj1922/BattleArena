using Zenject;
using BattleArena.UI.HealthBar;
using BattleArena.Characters;
using UnityEngine;

namespace BattleArena.Infrastructure.DI
{
    public class CharacterInstaller : MonoInstaller
    {
        [SerializeField] private Character _character;
        [SerializeField] private HealthBarView _healthBarView;


        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<HealthBarPresenter>().AsSingle().WithArguments(_character);
            Container.Bind<HealthBarModel>().AsSingle();
            Container
                .BindInterfacesAndSelfTo<HealthBarView>()
                .FromInstance(_healthBarView)
                .AsSingle();
        }
    }
}