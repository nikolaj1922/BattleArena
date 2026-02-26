using UnityEngine;

namespace BattleArena.StatusEffects
{
    public abstract class EffectData : ScriptableObject
    {
        public float chance;
        public abstract StatusEffect CreateEffect();
    }

}