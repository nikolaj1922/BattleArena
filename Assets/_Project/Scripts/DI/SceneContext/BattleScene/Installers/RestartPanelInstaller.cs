using Zenject;
using UnityEngine;
using BattleArena.UI.RestartPanel;

namespace BattleArena.DI
{
    public class RestartPanelInstaller : MonoInstaller
    {
        [SerializeField] private RestartPanelView _restartPanelPrefab;

        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<RestartPanelPresenter>().AsSingle();
            Container.Bind<IRestartPanelModel>().To<RestartPanelModel>().AsSingle();
            Container
                .BindInterfacesAndSelfTo<RestartPanelView>()
                .FromComponentInNewPrefab(_restartPanelPrefab)
                .AsSingle();
        }
    }
}