using BattleArena.StatusEffects.Stun;
using BattleArena.StatusEffects.Poison;
using BattleArena.StatusEffects.DamageModifier;

namespace BattleArena.StatusEffects.Visitors
{
    public interface IStatusEffectVisitor
    {
        void Visit(StunEffect effect);
        void Visit(PoisonEffect effect);
        void Visit(ReduceDamageEffect effect);
    }
}