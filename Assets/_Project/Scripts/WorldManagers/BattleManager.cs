using System;
using UnityEngine;
using System.Collections.Generic;
using Random = UnityEngine.Random;
using BattleArena.UI;
using BattleArena.Weapons;
using BattleArena.Characters;

namespace BattleArena.Managers
{
    public class BattleManager : MonoBehaviour
    {
        [Header("Character Factory")]
        [SerializeField] private CharacterFactory _characterFactory;

        [Header("Weapon Factory")]
        [SerializeField] private WeaponFactory _weaponFactory;

        [Header("Start positions")]
        [SerializeField] private Transform[] _spawnPositions = new Transform[2];

        [Header("Winner menu")]
        [SerializeField] private WinnerMenu _battleWinnerMenu;

        private readonly List<Character> _inBattleCharacters = new();

        private void Start()
        {
            StartBattle();
            _battleWinnerMenu.OnRestartClicked += RestartBattle;
        }

        private void OnDestroy() => _battleWinnerMenu.OnRestartClicked -= RestartBattle;

        private void StartBattle()
        {
            int firstCharacterIndex = GetRandomCharacterIndex();
            int secondCharacterIndex = GetRandomCharacterIndex();

            Character firstCharacter = _characterFactory.Create((CharacterType)firstCharacterIndex, _spawnPositions[0].position);
            Character secondCharacter = _characterFactory.Create((CharacterType)secondCharacterIndex, _spawnPositions[1].position);

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
                Destroy(character.gameObject);

            _inBattleCharacters.Clear();
            _battleWinnerMenu.Hide();

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

            string winnerName = deadCharacter.AttackTarget.CharacterData.characterName;
            _battleWinnerMenu.Show(winnerName);
        }

        private int GetRandomCharacterIndex() => Random.Range(0, Enum.GetValues(typeof(CharacterType)).Length);
    }
}

