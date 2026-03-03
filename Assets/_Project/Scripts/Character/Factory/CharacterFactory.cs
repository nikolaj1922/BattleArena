using System;
using UnityEngine;
using BattleArena.FSM;
using BattleArena.Characters.States;
using BattleArena.Characters.Config;

namespace BattleArena.Characters
{
    public enum CharacterType
    {
        Knight,
        Rogue,
        Mage
    }

    public class CharacterFactory
    {
        private readonly CharacterConfig _config;

        public CharacterFactory(CharacterConfig config)
        {
            _config = config;
        }

        public Character Create(CharacterType characterType, Vector3 pos)
        {
            CharacterData data = GetData(characterType);
            Character character = UnityEngine.Object.Instantiate(data.prefab, pos, Quaternion.identity);

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
                    return _config.Knight;
                case CharacterType.Mage:
                    return _config.Mage;
                case CharacterType.Rogue:
                    return _config.Rogue;
                default:
                    throw new ArgumentException(nameof(characterType));
            }
        }
    }
}