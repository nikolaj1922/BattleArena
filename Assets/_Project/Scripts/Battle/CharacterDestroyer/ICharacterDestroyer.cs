using BattleArena.Characters;

namespace BattleArena.Battle
{
    public interface ICharacterDestroyer
    {
        void Destroy(Character character);
    }
}