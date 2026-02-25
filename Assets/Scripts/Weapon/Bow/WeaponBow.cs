using UnityEngine;

namespace BattleArena.Weapons
{
    public class WeaponBow : Weapon
    {
        [SerializeField] Transform _projectileStartPosition;
        [SerializeField] GameObject _projectilePrefab;

        public override void ExecuteAttack() => CreateProjectile(_projectilePrefab, _projectileStartPosition.position);
    }
}