using BattleArena.UI;
using TMPro;
using UnityEngine;

namespace BattleArena.Characters.Managers
{
    public class CharacterView : MonoBehaviour
    {
        [Header("Float text")]
        [SerializeField] private Transform floatTextStartPos;
        [SerializeField] private Canvas floatTextPrefab;
        [field: SerializeField] public HealthBar HealthBar { get; private set; }

        public void ShowFloatingText(string text, Color color)
        {
            Canvas canvasObj = Instantiate(floatTextPrefab, floatTextStartPos);
            canvasObj.transform.SetLocalPositionAndRotation(Vector3.zero, Quaternion.identity);
            canvasObj.GetComponent<FloatingTextCanvas>().Init(text, color);
        }

    }
}

