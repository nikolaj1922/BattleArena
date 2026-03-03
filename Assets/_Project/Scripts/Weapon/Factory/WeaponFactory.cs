using System;
using UnityEngine;
using BattleArena.Weapons.Config;

namespace BattleArena.Weapons
{
    public enum WeaponType
    {
        OneHandedSword,
        Bow,
        MagicStaff
    }

    public class WeaponFactory
    {
        private readonly WeaponConfig _config;

        public WeaponFactory(WeaponConfig config)
        {
            _config = config;
        }

        public Weapon Create(WeaponType weaponType)
        {
            return UnityEngine.Object.Instantiate(GetData(weaponType).weapon);
        }

        private WeaponData GetData(WeaponType weaponType)
        {
            switch (weaponType)
            {
                case WeaponType.OneHandedSword:
                    return _config.OneHandedSword;
                case WeaponType.Bow:
                    return _config.Bow;
                case WeaponType.MagicStaff:
                    return _config.MagicStaff;
                default:
                    throw new ArgumentException(nameof(weaponType));
            }
        }
    }
}