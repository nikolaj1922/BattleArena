using BattleArena.Characters;
using BattleArena.Interfaces;
using UnityEngine;

namespace BattleArena.StatusEffects.DamageModifier
{
    public class ReduceDamageEffect : StatusEffect, IDamageModifier
    {
        private readonly float _multiplier;
        public ReduceDamageEffect(float duration, float multiplier) : base(duration)
        {
            _multiplier = multiplier;
        }

        public override string DisplayName => "Weakness!";

        public override Color DisplayColor => Color.lightPink;

        public float Modify(float baseDamage) => baseDamage * _multiplier;

        public override void OnAdd(Character target)
        {
            target.AttackManager.AddDamageModifier(this);
        }

        public override void OnRemove(Character target) => target.AttackManager.RemoveDamageModifier(this);

    }
}