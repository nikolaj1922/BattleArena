
using BattleArena.Characters;

namespace BattleArena.StatusEffects
{
    public interface IStatusEffect
    {
        void OnAdd(Character target);
        void OnTick(Character target);
        void OnRemove(Character target);
    }
}

