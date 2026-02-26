using System;
using UnityEngine;
using System.Collections.Generic;
using BattleArena.StatusEffects;

namespace BattleArena.Characters.Managers
{
    [RequireComponent(typeof(Character))]
    public class CharacterEffect : MonoBehaviour
    {
        private Character _character;

        [SerializeField] private List<StatusEffect> _activeEffects = new();

        public event Action<StatusEffect> OnEffectAdded;

        private void Awake()
        {
            _character = GetComponent<Character>();
        }

        private void Update()
        {
            TickEffects();
        }

        public void AddEffect(StatusEffect newEffect)
        {
            var existingEffect = _activeEffects.Find(e => e.GetType() == newEffect.GetType());

            if (existingEffect != null)
                return;


            newEffect.OnAdd(_character);
            _activeEffects.Add(newEffect);

            OnEffectAdded?.Invoke(newEffect);
        }

        public void ClearEffects() => _activeEffects.Clear();

        private void TickEffects()
        {
            for (int i = _activeEffects.Count - 1; i >= 0; i--)
            {
                var effect = _activeEffects[i];
                effect.OnTick(_character);

                if (effect.IsFinished)
                {
                    effect.OnRemove(_character);
                    _activeEffects.RemoveAt(i);
                }
            }
        }
    }
}

