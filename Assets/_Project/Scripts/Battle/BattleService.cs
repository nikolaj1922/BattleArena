using System;
using System.Collections.Generic;
using BattleArena.Characters;
using BattleArena.Weapons;
using UnityEngine;
using Random = UnityEngine.Random;

namespace BattleArena.Battle
{
    public class BattleService
    {
        public event Action<string> OnBattleEnded;

        private readonly CharacterFactory _characterFactory;
        private readonly WeaponFactory _weaponFactory;
        private readonly Transform[] _spawnPoints;
        private readonly ICharacterDestroyer _destroyer;
        private readonly List<Character> _inBattleCharacters = new();

        public BattleService(CharacterFactory characterFactory, WeaponFactory weaponFactory, Transform[] spawnPoints, ICharacterDestroyer characterDestroyer)
        {
            _characterFactory = characterFactory;
            _weaponFactory = weaponFactory;
            _spawnPoints = spawnPoints;
            _destroyer = characterDestroyer;
        }

        public void StartBattle()
        {
            int firstCharacterIndex = GetRandomCharacterIndex();
            int secondCharacterIndex = GetRandomCharacterIndex();

            Character firstCharacter = _characterFactory.Create((CharacterType)firstCharacterIndex, _spawnPoints[0].position);
            Character secondCharacter = _characterFactory.Create((CharacterType)secondCharacterIndex, _spawnPoints[1].position);

            Weapon firstWeapon = _weaponFactory.Create((WeaponType)firstCharacterIndex);
            Weapon secondWeapon = _weaponFactory.Create((WeaponType)secondCharacterIndex);

            firstCharacter.SetWeapon(firstWeapon);
            firstCharacter.SetTarget(secondCharacter);

            secondCharacter.SetWeapon(secondWeapon);
            secondCharacter.SetTarget(firstCharacter);

            RegisterCharacter(firstCharacter);
            RegisterCharacter(secondCharacter);
        }

        public void RestartBattle()
        {
            foreach (var character in _inBattleCharacters)
                _destroyer.Destroy(character);

            _inBattleCharacters.Clear();

            StartBattle();
        }

        private void RegisterCharacter(Character character)
        {
            _inBattleCharacters.Add(character);
            character.OnDeath += HandleCharacterDeath;
        }

        private void HandleCharacterDeath(Character deadCharacter)
        {
            deadCharacter.OnDeath -= HandleCharacterDeath;
            OnBattleEnded?.Invoke(deadCharacter.AttackTarget.CharacterData.characterName);
        }

        private int GetRandomCharacterIndex() => Random.Range(0, Enum.GetValues(typeof(CharacterType)).Length);
    }
}