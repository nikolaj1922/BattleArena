using UnityEngine;
using BattleArena.Characters;

namespace BattleArena
{
    public class CharacterDestroyer : ICharacterDestroyer
    {
        public void Destroy(Character character) => Object.Destroy(character.gameObject);
    }
}