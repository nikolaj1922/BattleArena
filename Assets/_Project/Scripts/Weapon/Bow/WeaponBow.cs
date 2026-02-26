using UnityEngine;

namespace BattleArena.Weapons
{
    public class WeaponBow : Weapon
    {
        [SerializeField] Projectile _projectilePrefab;
        [SerializeField] Transform _projectileStartPosition;

        public override void ExecuteAttack() => CreateProjectile(_projectilePrefab, _projectileStartPosition.position);
    }
}