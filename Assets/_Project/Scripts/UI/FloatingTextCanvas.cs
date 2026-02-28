using TMPro;
using UnityEngine;
using System.Collections;

namespace BattleArena.UI
{
    [RequireComponent(typeof(CanvasGroup))]
    public class FloatingTextCanvas : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _text;
        [SerializeField] private float _floatSpeed = 1f;
        [SerializeField] private float _duration = 1f;

        private CanvasGroup _canvasGroup;

        private void Awake()
        {
            _canvasGroup = GetComponent<CanvasGroup>();
        }

        public void Init(string canvasText, Color color)
        {
            _text.text = canvasText;
            _text.color = color;
            StartCoroutine(FloatingCoroutine());
        }

        private IEnumerator FloatingCoroutine()
        {
            float elapsed = 0f;
            Vector3 startPos = transform.position;
            Vector3 worldUp = Vector3.up;
            while (elapsed < _duration)
            {
                transform.position = startPos + worldUp * _floatSpeed * elapsed;
                _canvasGroup.alpha = 1f - (elapsed / _duration);
                elapsed += Time.deltaTime;
                yield return null;
            }

            Destroy(gameObject);
        }
    }
}
