using System;

namespace BattleArena.UI.HealthBar
{
    public interface IHealthBarModel
    {
        event Action<float, float> OnHealthChanged;
        event Action<float> OnMaxHealthChanged;

        float MaxHealth { get; }
        float CurrentHealth { get; }

        void SetMaxHealth(float maxHealth);
        void ChangeHealth(float currentHealth);
    }
}