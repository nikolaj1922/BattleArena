using System;

namespace BattleArena.UI.HealthBar
{
    public class HealthBarModel : IHealthBarModel
    {
        public event Action<float, float> OnHealthChanged;
        public event Action<float> OnMaxHealthChanged;

        public float MaxHealth { get; private set; }
        public float CurrentHealth { get; private set; }

        public void SetMaxHealth(float maxHealth)
        {
            MaxHealth = maxHealth;
            OnMaxHealthChanged?.Invoke(MaxHealth);
        }
        public void ChangeHealth(float currentHealth)
        {
            CurrentHealth = currentHealth;
            OnHealthChanged?.Invoke(CurrentHealth, MaxHealth);
        }
    }
}