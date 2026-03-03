using UnityEngine;

namespace BattleArena.Weapons.Config
{
    [CreateAssetMenu(fileName = "WeaponConfig", menuName = "Weapon/Config")]
    public class WeaponConfig : ScriptableObject
    {
        public WeaponData Bow;
        public WeaponData OneHandedSword;
        public WeaponData MagicStaff;
    }
}