using BattleArena.Characters;
using UnityEngine;

namespace BattleArena.Weapons
{
    public abstract class Weapon : MonoBehaviour
    {
        protected Character _character;
        [field: SerializeField] public WeaponData Data { get; private set; }

        public void SetOwnerCharacter(Character character)
        {
            _character = character;
        }

        public void StartAttack() => _character.Animation.PlayAnimation(Data.attackAnimationType);

        public abstract void ExecuteAttack();

        protected void CreateProjectile(Projectile projectile, Vector3 projectileStartPosition)
        {
            Projectile projectileInstance = Instantiate(projectile);
            projectileInstance.transform.SetPositionAndRotation(projectileStartPosition, Quaternion.identity);

            Vector3 direction = _character.AttackTarget.transform.position - _character.transform.position;

            projectileInstance.Init(direction, Data.damage, _character);
            projectileInstance.OnHit += TryToApplyEffects;
        }

        protected void TryToApplyEffects()
        {
            Character target = _character.AttackTarget;

            if (target.CurrentHealth <= 0) return;

            foreach (var effectData in Data.effects)
            {
                if (CanApplyStatusEffect(effectData.chance))
                {
                    var effect = effectData.CreateEffect();
                    target.Effects.AddEffect(effect);
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
