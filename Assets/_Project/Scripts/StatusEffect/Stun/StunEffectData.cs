using UnityEngine;

namespace BattleArena.StatusEffects.Stun
{
    [CreateAssetMenu(menuName = "Effects/Stun")]
    public class StunEffectData : EffectData
    {
        public float duration;

        public override StatusEffect CreateEffect()
        {
            return new StunEffect(duration);
        }
    }
}