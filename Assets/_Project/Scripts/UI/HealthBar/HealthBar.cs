using TMPro;
using UnityEngine;
using UnityEngine.UI;
using BattleArena.Characters;

namespace BattleArena.UI
{
    public class HealthBar : MonoBehaviour
    {
        [SerializeField] private Image _healthBar;
        [SerializeField] private TextMeshProUGUI _maxHealthText;
        [SerializeField] private TextMeshProUGUI _currentHealthText;
        private Character _character;

        private void OnDestroy()
        {
            if (_character != null)
                _character.OnHealthChanged -= UpdateHealth;
        }

        public void Bind(Character character)
        {
            _character = character;

            character.OnHealthChanged += UpdateHealth;
            _maxHealthText.text = $"/{character.CharacterData.health}";
            UpdateHealth(character.CharacterData.health, character.CharacterData.health);
        }

        private void UpdateHealth(float current, float maxHealth)
        {
            _healthBar.fillAmount = current / maxHealth;
            _currentHealthText.text = current.ToString("0");
        }
    }
}
