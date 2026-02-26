
using BattleArena.Characters;
using UnityEngine;

namespace BattleArena.StatusEffects.Stun
{
    public class StunEffect : StatusEffect
    {
        public StunEffect(float duration) : base(duration) { }

        public override void OnAdd(Character target)
        {
            target.ViewManager.ShowFloatingText("Stunned!", Color.yellow);
            target.AttackManager.IncreaseBlockCounter();
        }

        public override void OnRemove(Character target)
        {
            target.AttackManager.DecreaseBlockCounter();
        }
    }
}