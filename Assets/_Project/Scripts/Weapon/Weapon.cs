using BattleArena.Characters;
using UnityEngine;

namespace BattleArena.Weapons
{
    public abstract class Weapon : MonoBehaviour, IWeapon
    {
        protected Character character;
        public WeaponData weaponData;

        public void SetOwnerCharacter(Character character) => this.character = character;

        public void StartAttack() => character.AnimationManager.PlayAnimation(weaponData.attackAnimationType);

        public abstract void ExecuteAttack();

        protected void CreateProjectile(Projectile projectile, Vector3 projectileStartPosition)
        {
            Projectile projectileObject = Instantiate(projectile);
            projectileObject.transform.SetPositionAndRotation(projectileStartPosition, Quaternion.identity);

            Vector3 direction = character.AttackTarget.transform.position - character.transform.position;
            projectile.Init(direction, weaponData.damage, character);
            projectile.OnHit += TryToApplyEffects;
        }

        protected void TryToApplyEffects()
        {
            Character target = character.AttackTarget;

            if (target.CurrentHealth <= 0) return;

            foreach (var effectData in weaponData.effects)
            {
                if (CanApplyStatusEffect(effectData.chance))
                {
                    var effect = effectData.CreateEffect();
                    target.EffectManager.AddEffect(effect);
                }
            }
        }

        private bool CanApplyStatusEffect(float chance)
        {
            float roll = Random.Range(0f, 100f);
            return roll <= chance;
        }
    }
}
