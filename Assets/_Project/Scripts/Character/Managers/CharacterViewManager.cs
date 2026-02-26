using System;
using BattleArena.UI;
using UnityEngine;

namespace BattleArena.Characters.Managers
{
    public class CharacterViewManager : MonoBehaviour
    {
        [Header("Float text")]
        [SerializeField] private Transform floatTextStartPos;
        [SerializeField] private GameObject floatTextPrefab;
        [field: SerializeField] public HealthBar HealthBar { get; private set; }

        public Action<float, float> OnHealthChanged;

        public void ShowFloatingText(string text, Color color)
        {
            GameObject canvasObj = Instantiate(floatTextPrefab, floatTextStartPos);
            canvasObj.transform.SetLocalPositionAndRotation(Vector3.zero, Quaternion.identity);
            canvasObj.GetComponent<FloatingTextCanvas>().Init(text, color);
        }

    }
}

