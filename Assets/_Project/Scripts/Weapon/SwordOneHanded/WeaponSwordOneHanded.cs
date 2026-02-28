namespace BattleArena.Weapons
{
    public class WeaponSwordOneHanded : Weapon
    {
        public override void ExecuteAttack()
        {
            float finalDamage = _character.Attack.GetFinalDamage(Data.damage);

            _character.AttackTarget.TakeDamage(finalDamage);
            TryToApplyEffects();
        }
    }
}