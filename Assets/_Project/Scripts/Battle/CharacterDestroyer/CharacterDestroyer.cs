using UnityEngine;
using BattleArena.Characters;

namespace BattleArena.Battle
{
    public class CharacterDestroyer : ICharacterDestroyer
    {
        public void Destroy(Character character) => Object.Destroy(character.gameObject);
    }
}