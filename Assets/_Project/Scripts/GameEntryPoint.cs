using BattleArena.Battle;
using UnityEngine;

namespace BattleArena
{
    public class GameEntryPoint : MonoBehaviour
    {
        [SerializeField] private BattleInstaller _installer;

        private void Awake()
        {
            _installer.Compose();
        }
    }
}