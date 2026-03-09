using TMPro;
using UnityEngine;
using DG.Tweening;
using System;

namespace BattleArena.UI.FloatingText
{
    [RequireComponent(typeof(CanvasGroup))]
    public class FloatingTextCanvas : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _text;
        [SerializeField] private float _floatSpeed = 1f;
        [SerializeField] private float _duration = 1f;

        private Tween _animationTween;

        public void Init(string canvasText, Color color, Action OnAnimationEnd = null)
        {
            _text.text = canvasText;
            _text.color = color;
            PlayFloatingAnimation(OnAnimationEnd);
        }

        private void PlayFloatingAnimation(Action OnAnimationEnd = null)
        {

            Vector3 startPos = transform.position;
            Vector3 endPos = startPos + _duration * _floatSpeed * Vector3.up;

            Sequence sequence = DOTween.Sequence();

            sequence.Join(transform.DOMove(endPos, _duration).SetEase(Ease.Linear));
            sequence.Join(_text.DOFade(0f, _duration).Play());

            sequence.OnComplete(() => OnAnimationEnd?.Invoke());

            _animationTween = sequence;
        }

        private void OnDisable() => _animationTween?.Kill();
    }
}
