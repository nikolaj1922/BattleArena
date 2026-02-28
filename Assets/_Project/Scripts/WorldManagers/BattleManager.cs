using UnityEngine;
using System.Collections.Generic;
using BattleArena.UI;
using BattleArena.Characters;
using System;
using Random = UnityEngine.Random;

namespace BattleArena.Managers
{
    public class BattleManager : MonoBehaviour
    {
        [Header("CharacterFactory")] private CharacterFactory _characterFactory;

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

        private void StartBattle()
        {
            Character firstCharacter = _characterFactory.Create((CharacterType)GetRandomCharacterIndex(), _spawnPositions[0].position);
            Character secondCharacter = _characterFactory.Create((CharacterType)GetRandomCharacterIndex(), _spawnPositions[1].position);

            if (firstCharacter && secondCharacter)
            {
                firstCharacter.SetTarget(secondCharacter);
                secondCharacter.SetTarget(firstCharacter);

                RegisterCharacter(firstCharacter);
                RegisterCharacter(secondCharacter);
            }
            else
            {
                Debug.LogError("Characters are undefined!");
            }
        }

        private int GetRandomCharacterIndex() => Random.Range(0, Enum.GetValues(typeof(CharacterType)).Length);
    }
}

