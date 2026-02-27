using BattleArena.Characters;
using BattleArena.StatusEffects.Visitors;

namespace BattleArena.StatusEffects.Stun
{
    public class StunEffect : StatusEffect
    {
        public StunEffect(float duration) : base(duration) { }

        public override void Accept(IStatusEffectVisitor visitor) => visitor.Visit(this);

        public override void OnAdd(Character target)
        {
            target.Attack.IncreaseBlockCounter();
        }

        public override void OnRemove(Character target)
        {
            target.Attack.DecreaseBlockCounter();
        }
    }
}