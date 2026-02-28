using System;
using UnityEngine;

namespace BattleArena.Weapons
{
    public enum WeaponType
    {
        OneHandedSword,
        Bow,
        MagicStaff
    }

    [CreateAssetMenu(menuName = "Weapon/Factory")]
    public class WeaponFactory : ScriptableObject
    {
        [SerializeField] WeaponData _oneHandedSword, _bow, _magicStaff;

        public Weapon Create(WeaponType weaponType)
        {
            return Instantiate(GetData(weaponType).weapon);
        }

        private WeaponData GetData(WeaponType weaponType)
        {
            switch (weaponType)
            {
                case WeaponType.OneHandedSword:
                    return _oneHandedSword;
                case WeaponType.Bow:
                    return _bow;
                case WeaponType.MagicStaff:
                    return _magicStaff;
                default:
                    throw new ArgumentException(nameof(weaponType));
            }
        }
    }
}