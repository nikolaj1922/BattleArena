using Zenject;

namespace BattleArena
{
    public class GameEntryPoint : IInitializable
    {
        private readonly Battle _battle;

        public GameEntryPoint(Battle battle)
        {
            _battle = battle;
        }

        public void Initialize() => _battle.StartBattle();
    }
}