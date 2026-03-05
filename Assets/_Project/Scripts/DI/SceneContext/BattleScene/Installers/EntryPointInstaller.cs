using Zenject;

namespace BattleArena.DI.SceneContext
{
    public class EntryPointInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<GameEntryPoint>().AsSingle();
        }
    }
}