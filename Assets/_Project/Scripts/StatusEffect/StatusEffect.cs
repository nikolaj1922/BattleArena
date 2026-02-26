using BattleArena.Characters;
using UnityEngine;

namespace BattleArena.StatusEffects
{
    public abstract class StatusEffect
    {
        private float _elapsedTime;
        private readonly float _duration;

        public abstract string DisplayName { get; }
        public abstract Color DisplayColor { get; }

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