using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace BattleArena.UI.HealthBar
{
    public class HealthBarView : MonoBehaviour
    {
        [SerializeField] private Image _healthBar;
        [SerializeField] private TextMeshProUGUI _maxHealthText;
        [SerializeField] private TextMeshProUGUI _currentHealthText;

        public void UpdateCurrentHealthView(float current, float maxHealth)
        {
            _healthBar.fillAmount = current / maxHealth;
            _currentHealthText.text = current.ToString("0");
        }

        public void SetMaxHealthView(float maxHealth) => _maxHealthText.text = $"/{maxHealth}";
    }
}
