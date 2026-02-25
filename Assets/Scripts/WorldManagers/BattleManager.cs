using UnityEngine;
using System.Collections.Generic;
using BattleArena.UI;
using BattleArena.Weapons;
using BattleArena.Characters;

namespace BattleArena.Managers
{
    public class BattleManager : MonoBehaviour
    {
        [Header("Characters")]
        [SerializeField] private CharacterData[] _characters = new CharacterData[3];

        [Header("Weapons")]
        [SerializeField] private WeaponData[] _weapons = new WeaponData[3];

        [Header("Start positions")]
        [SerializeField] private Transform[] _spawnPositions = new Transform[2];

        [Header("Winner menu")]
        [SerializeField] private WinnerMenu _battleWinnerMenu;

        private readonly List<GameObject> _inBattleCharacters = new();

        private void Start() => StartBattle();

        public void RestartBattle()
        {
            foreach (var character in _inBattleCharacters)
                Destroy(character);

            _inBattleCharacters.Clear();
            _battleWinnerMenu.Hide();

            StartBattle();
        }

        private void RegisterCharacter(Character character)
        {
            _inBattleCharacters.Add(character.gameObject);
            character.OnDeath += () => OnCharacterDeath(character.AttackTarget.CharacterData.characterName);
        }

        private void StartBattle()
        {
            Character firstCharacter = CreateCharacter(_spawnPositions[0].position);
            Character secondCharacter = CreateCharacter(_spawnPositions[1].position);

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

        private void OnCharacterDeath(string winnerName) => _battleWinnerMenu.Show(winnerName);

        private Character CreateCharacter(Vector3 spawnPosition)
        {
            int randomIndex = GetRandomCharacterIndex();
            CharacterData characterData = _characters[randomIndex];
            WeaponData characterWeapon = _weapons[randomIndex];

            return SpawnCharacter(characterData, characterWeapon, spawnPosition);
        }

        private Character SpawnCharacter(CharacterData characterData, WeaponData weaponData, Vector3 spawnPosition)
        {
            GameObject characterObject = Instantiate(characterData.prefab, spawnPosition, Quaternion.identity);
            GameObject weaponObject = Instantiate(weaponData.prefab);

            if (!characterObject.TryGetComponent(out Character character))
            {
                Debug.LogError("Character component not found!");
                return null;
            }

            character.SetWeapon(weaponObject);
            character.Init(characterData);

            return character;
        }

        private int GetRandomCharacterIndex() => Random.Range(0, _characters.Length);

    }
}

