using UnityEngine;
using BattleArena.Characters;
using BattleArena.StatusEffects.Visitors;

namespace BattleArena.StatusEffects
{
    public abstract class StatusEffect
    {
        private float _elapsedTime;
        private readonly float _duration;

        public StatusEffect(float duration)
        {
            _duration = duration;
        }

        public abstract void Accept(IStatusEffectVisitor visiter);

        public bool IsFinished { get; private set; }

        public abstract void OnAdd(Character target);

        public abstract void OnRemove(Character target);

        public virtual void OnTick(Character target)
        {
            _elapsedTime += Time.deltaTime;
            if (_elapsedTime >= _duration)
            {
                IsFinished = true;
            }
        }
    }
}