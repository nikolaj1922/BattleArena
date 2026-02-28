using System;
using BattleArena.Characters.States;
using BattleArena.FSM;
using UnityEngine;

namespace BattleArena.Characters
{
    public enum CharacterType
    {
        Knight,
        Rogue,
        Mage
    }

    [CreateAssetMenu(menuName = "Character/Factory")]
    public class CharacterFactory : ScriptableObject
    {
        [SerializeField]
        private CharacterData _knight, _mage, _rogue;

        public Character Create(CharacterType characterType, Vector3 pos)
        {
            CharacterData data = GetData(characterType);
            Character character = Instantiate(data.prefab, pos, Quaternion.identity);

            StateMachine stateMachine = new(
                new IState[]
                    {
                        new IdleState(character),
                        new DeathState(character),
                        new AttackState(character),
                        new MoveState(character)
                    },
                new ITransition[]
                    {
                        new Transition<IdleState, MoveState>(() => character.AttackTarget != null),
                        new Transition<MoveState, AttackState>(() => character.CloseToAttackTarget()),
                        new Transition<AttackState, DeathState>(() => character.CurrentHealth <= 0),
                        new Transition<IdleState, DeathState>(() => character.CurrentHealth <= 0),
                        new Transition<AttackState, MoveState>(() => !character.CloseToAttackTarget()),
                        new Transition<AttackState, IdleState>(() => character.AttackTarget == null)
                    }
            );

            character.Init(data, stateMachine);

            return character;
        }

        private CharacterData GetData(CharacterType characterType)
        {
            switch (characterType)
            {
                case CharacterType.Knight:
                    return _knight;
                case CharacterType.Mage:
                    return _mage;
                case CharacterType.Rogue:
                    return _rogue;
                default:
                    throw new ArgumentException(nameof(characterType));
            }
        }
    }
}