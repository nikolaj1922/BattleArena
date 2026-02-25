using UnityEngine;

namespace BattleArena.StatusEffects.Poison
{
    [CreateAssetMenu(menuName = "Effects/Poison")]
    public class PoisonEffectData : EffectData
    {
        public float poisonDamage;
        public float poisonDuration;
        public float poisonTickFrequency;

        public override StatusEffect CreateEffect()
        {
            return new PoisonEffect(poisonDuration, poisonDamage, poisonTickFrequency);
        }
    }
}