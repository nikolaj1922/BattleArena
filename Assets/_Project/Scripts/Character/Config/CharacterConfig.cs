using UnityEngine;

namespace BattleArena.Characters.Config
{
    [CreateAssetMenu(fileName = "CharacterConfig", menuName = "Character/Config")]
    public class CharacterConfig : ScriptableObject
    {
        public CharacterData Knight;
        public CharacterData Mage;
        public CharacterData Rogue;
    }
}