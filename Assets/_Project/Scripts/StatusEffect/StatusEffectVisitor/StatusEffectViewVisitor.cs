using UnityEngine;
using BattleArena.Characters.Managers;
using BattleArena.StatusEffects.Stun;
using BattleArena.StatusEffects.DamageModifier;
using BattleArena.StatusEffects.Poison;

namespace BattleArena.StatusEffects.Visitors
{
    public class StatusEffectViewVisitor : IStatusEffectVisitor
    {
        private readonly CharacterView _characterView;

        public StatusEffectViewVisitor(CharacterView characterView)
        {
            _characterView = characterView;
        }

        public void Visit(StunEffect effect) => _characterView.ShowFloatingText("Stunned!", Color.yellow);

        public void Visit(PoisonEffect effect) => _characterView.ShowFloatingText("Poison!", Color.green);

        public void Visit(ReduceDamageEffect effect) => _characterView.ShowFloatingText("Weakness!", Color.lightPink);
    }
}