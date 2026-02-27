using UnityEngine;
using BattleArena.Characters;
using BattleArena.StatusEffects.Visitors;

namespace BattleArena.StatusEffects.Poison
{
    public class PoisonEffect : StatusEffect
    {
        private float _tickTimer;
        private readonly float _frequency;
        private readonly float _damage;

        public PoisonEffect(float duration, float damage, float frequency) : base(duration)
        {
            _damage = damage;
            _frequency = frequency;
        }

        public override void OnAdd(Character target) { }

        public override void OnRemove(Character target) { }

        public override void OnTick(Character target)
        {
            base.OnTick(target);

            _tickTimer += Time.deltaTime;

            if (_tickTimer >= _frequency)
            {
                _tickTimer = 0f;
                target.TakeDamage(_damage);
            }
        }

        public override void Accept(IStatusEffectVisitor visiter) => visiter.Visit(this);
    }
}
