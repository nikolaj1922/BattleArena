using UnityEngine;

namespace BattleArena.Characters
{
    [CreateAssetMenu(menuName = "Character")]
    public class CharacterData : ScriptableObject
    {
        public string characterName;
        public float health;
        public float moveSpeed;
        public GameObject prefab;
    }
}