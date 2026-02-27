using System.Collections.Generic;
using UnityEngine;

namespace BattleArena.Characters.Managers
{
    public enum CharacterAnimationType
    {
        Death,
        Hit,
        MeleeAttack,
        MageAttack,
        BowAttackDraw,
        OneHandedWeaponMove,
        BowHandedMove,
        OneHandedWeaponIdle,
        BowHandedIdle,
        MagicSpellcasting,
        MagicShoot
    }

    [RequireComponent(typeof(Animator))]
    public class CharacterAnimation : MonoBehaviour
    {
        private const float CROSS_FADE_DURATION = 0.2f;
        private Animator _anim;
        private Dictionary<CharacterAnimationType, int> _animationMap;

        private void Awake()
        {
            _anim = GetComponent<Animator>();

            CreateAnimationDictionary();
        }

        public void PlayAnimation(CharacterAnimationType animationType)
        {
            if (_animationMap.TryGetValue(animationType, out int hash))
                _anim.CrossFade(hash, CROSS_FADE_DURATION, 0);
        }

        private void CreateAnimationDictionary()
        {
            _animationMap = new Dictionary<CharacterAnimationType, int>
        {
            { CharacterAnimationType.BowHandedIdle, Animator.StringToHash("Bow Handed Idle") },
            { CharacterAnimationType.BowHandedMove, Animator.StringToHash("Bow Handed Move") },
            { CharacterAnimationType.BowAttackDraw, Animator.StringToHash("Bow Attack Draw") },

            { CharacterAnimationType.MagicShoot, Animator.StringToHash("Magic Shoot") },
            { CharacterAnimationType.MagicSpellcasting, Animator.StringToHash("Magic Spellcasting") },

            { CharacterAnimationType.OneHandedWeaponIdle, Animator.StringToHash("One Handed Weapon Idle") },
            { CharacterAnimationType.OneHandedWeaponMove, Animator.StringToHash("One Handed Weapon Move") },
            { CharacterAnimationType.MeleeAttack, Animator.StringToHash("Melee Attack") },

            { CharacterAnimationType.MageAttack, Animator.StringToHash("Mage Attack") },

            { CharacterAnimationType.Hit, Animator.StringToHash("Hit") },
            { CharacterAnimationType.Death, Animator.StringToHash("Death") },
        };
        }
    }
}
