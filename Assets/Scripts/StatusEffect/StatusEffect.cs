using BattleArena.Characters;
using UnityEngine;

namespace BattleArena.StatusEffects
{
    public abstract class StatusEffect : IStatusEffect
    {
        private readonly float _duration;
        private float _elapsedTime;

        public StatusEffect(float duration)
        {
            _duration = duration;
        }

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