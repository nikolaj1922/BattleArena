
namespace BattleArena.Weapons
{
    public class WeaponSwordOneHanded : Weapon
    {
        public override void ExecuteAttack()
        {
            float finalDamage = character.AttackManager.GetFinalDamage(weaponData.damage);

            character.AttackTarget.TakeDamage(finalDamage);
            TryToApplyEffects();
        }
    }
}