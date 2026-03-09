using TMPro;
using UnityEngine;
using DG.Tweening;

namespace BattleArena.UI
{
    [RequireComponent(typeof(CanvasGroup))]
    public class FloatingTextCanvas : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _text;
        [SerializeField] private float _floatSpeed = 1f;
        [SerializeField] private float _duration = 1f;

        private Tween _animationTween;

        public void Init(string canvasText, Color color)
        {
            _text.text = canvasText;
            _text.color = color;
            PlayFloatingAnimation();
        }

        private void PlayFloatingAnimation()
        {
            float startAlpha = 1f;

            Vector3 startPos = transform.position;
            Vector3 endPos = startPos + _duration * _floatSpeed * Vector3.up;

            Sequence sequence = DOTween.Sequence();

            sequence.Join(transform.DOMove(endPos, _duration).SetEase(Ease.Linear));
            sequence.Join(DOTween.To(
                () => startAlpha,
                a =>
                {
                    startAlpha = a;
                    Color c = _text.color;
                    c.a = a;
                    _text.color = c;
                },
                0f,
                _duration
            ));


            sequence.OnComplete(() => Destroy(gameObject));

            _animationTween = sequence;
        }

        private void OnDisable() => _animationTween?.Kill();
    }
}
