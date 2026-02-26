using UnityEngine;

namespace BattleArena.Weapons
{
    public class WeaponBow : Weapon
    {
        [SerializeField] Transform _projectileStartPosition;
        [SerializeField] Projectile _projectilePrefab;

        public override void ExecuteAttack() => CreateProjectile(_projectilePrefab, _projectileStartPosition.position);
    }
}