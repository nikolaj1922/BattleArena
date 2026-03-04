using Zenject;
using BattleArena.Battle;

namespace BattleArena
{
    public class GameEntryPoint : IInitializable
    {
        private readonly BattleManager _battle;

        public GameEntryPoint(BattleManager battle)
        {
            _battle = battle;
        }

        public void Initialize() => _battle.StartBattle();
    }
}