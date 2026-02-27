using BattleArena.Characters;
using BattleArena.Interfaces;
using BattleArena.StatusEffects.Visitors;

namespace BattleArena.StatusEffects.DamageModifier
{
    public class ReduceDamageEffect : StatusEffect, IDamageModifier
    {
        private readonly float _multiplier;

        public ReduceDamageEffect(float duration, float multiplier) : base(duration)
        {
            _multiplier = multiplier;
        }

        public float Modify(float baseDamage) => baseDamage * _multiplier;

        public override void OnAdd(Character target)
        {
            target.Attack.AddDamageModifier(this);
        }

        public override void OnRemove(Character target) => target.Attack.RemoveDamageModifier(this);

        public override void Accept(IStatusEffectVisitor visitor) => visitor.Visit(this);
    }
}