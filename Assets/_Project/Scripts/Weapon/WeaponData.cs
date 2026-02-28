using UnityEngine;
using System.Collections.Generic;
using BattleArena.Characters.Managers;
using BattleArena.StatusEffects;

namespace BattleArena.Weapons
{
    [CreateAssetMenu(menuName = "Weapon/Weapon")]
    public class WeaponData : ScriptableObject
    {
        public Weapon weapon;
        public float attackCooldown;
        public float attackRange;
        public float damage;
        public CharacterAnimationType attackAnimationType;
        public CharacterAnimationType moveAnimationType;
        public CharacterAnimationType idleAnimationType;
        public List<EffectData> effects;
    }
}