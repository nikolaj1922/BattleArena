using Zenject;
using UnityEngine;
using BattleArena.UI;

namespace BattleArena.DI
{
    public class EntryPointInstaller : MonoInstaller
    {
        [SerializeField] private RestartPanel _restartPanelPrefab;

        public override void InstallBindings()
        {
            Container
                .Bind<RestartPanel>()
                .FromComponentInNewPrefab(_restartPanelPrefab)
                .AsSingle();

            Container.BindInterfacesAndSelfTo<GameMediator>().AsSingle();
            Container.BindInterfacesAndSelfTo<GameEntryPoint>().AsSingle();
        }
    }
}