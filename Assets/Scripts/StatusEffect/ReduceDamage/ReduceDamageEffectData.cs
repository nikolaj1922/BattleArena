using UnityEngine;

namespace BattleArena.StatusEffects.DamageModifier
{

    [CreateAssetMenu(menuName = "Effects/Damage Modifier")]
    public class ReduceDamageEffectData : EffectData
    {
        public float duration;
        public float multiplier;
        public override StatusEffect CreateEffect()
        {
            return new ReduceDamageEffect(duration, multiplier);
        }
    }
}