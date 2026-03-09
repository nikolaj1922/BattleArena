using UnityEngine;
using BattleArena.StatusEffects;
using BattleArena.StatusEffects.Visitors;
using BattleArena.UI.FloatingText;
using BattleArena.Infrastructure.ObjectPool;
using Zenject;

namespace BattleArena.Characters.Managers
{
    [RequireComponent(typeof(CharacterEffect))]
    public class CharacterView : MonoBehaviour
    {
        [Header("Float text")]
        [SerializeField] private Transform _floatTextStartPos;
        private ObjectPool<FloatingTextCanvas> _floatTextPool;

        private CharacterEffect _characterEffect;
        private IStatusEffectVisitor _statusEffectVisitor;

        private void Awake()
        {
            _characterEffect = GetComponent<CharacterEffect>();
            _characterEffect.OnEffectAdded += HandleEffectAdded;

            _statusEffectVisitor = new StatusEffectViewVisitor(this);
        }

        [Inject]
        public void Construct(ObjectPool<FloatingTextCanvas> floatTextPool)
        {
            _floatTextPool = floatTextPool;
        }

        private void OnDestroy() => _characterEffect.OnEffectAdded -= HandleEffectAdded;

        public void ShowFloatingText(string text, Color color)
        {
            FloatingTextCanvas canvasObj = _floatTextPool.Get();
            canvasObj.transform.SetLocalPositionAndRotation(_floatTextStartPos.position, Quaternion.identity);
            canvasObj.GetComponent<FloatingTextCanvas>().Init(text, color, OnAnimationEnd: () => _floatTextPool.Release(canvasObj));
        }

        private void HandleEffectAdded(StatusEffect effect) => effect.Accept(_statusEffectVisitor);
    }
}

