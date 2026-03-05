namespace BattleArena.UI.HealthBar
{
    public interface IHealthBarView
    {
        void UpdateCurrentHealthView(float current, float maxHealth);
        void SetMaxHealthView(float maxHealth);
    }
}