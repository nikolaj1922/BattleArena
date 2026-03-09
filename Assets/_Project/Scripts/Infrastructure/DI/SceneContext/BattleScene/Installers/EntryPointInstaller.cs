using Zenject;

namespace BattleArena.Infrastructure.DI.SceneContext
{
    public class EntryPointInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<GameEntryPoint>().AsSingle();
        }
    }
}