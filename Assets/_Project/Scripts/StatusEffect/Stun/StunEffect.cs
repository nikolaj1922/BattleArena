using BattleArena.Characters;
using UnityEngine;

namespace BattleArena.StatusEffects.Stun
{
    public class StunEffect : StatusEffect
    {

        public StunEffect(float duration) : base(duration) { }

        public override string DisplayName => "Stunned!";

        public override Color DisplayColor => Color.yellow;

        public override void OnAdd(Character target)
        {
            target.AttackManager.IncreaseBlockCounter();
        }

        public override void OnRemove(Character target)
        {
            target.AttackManager.DecreaseBlockCounter();
        }
    }
}