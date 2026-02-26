using UnityEngine;
using BattleArena.UI;
using BattleArena.StatusEffects;
using BattleArena.StatusEffects.Stun;
using BattleArena.StatusEffects.Poison;
using BattleArena.StatusEffects.DamageModifier;

namespace BattleArena.Characters.Managers
{
    [RequireComponent(typeof(CharacterEffect))]
    public class CharacterView : MonoBehaviour
    {
        [Header("Float text")]
        [SerializeField] private Transform floatTextStartPos;
        [SerializeField] private Canvas floatTextPrefab;

        private CharacterEffect _characterEffect;

        [field: SerializeField] public HealthBar HealthBar { get; private set; }

        private void Awake()
        {
            _characterEffect = GetComponent<CharacterEffect>();
            _characterEffect.OnEffectAdded += HandleEffectAdded;
        }

        private void OnDestroy() => _characterEffect.OnEffectAdded -= HandleEffectAdded;

        public void ShowFloatingText(string text, Color color)
        {
            Canvas canvasObj = Instantiate(floatTextPrefab, floatTextStartPos);
            canvasObj.transform.SetLocalPositionAndRotation(Vector3.zero, Quaternion.identity);
            canvasObj.GetComponent<FloatingTextCanvas>().Init(text, color);
        }

        private void HandleEffectAdded(StatusEffect effect) => ShowFloatingText(effect.DisplayName, effect.DisplayColor);

    }
}

