using BattleArena.Characters;
using UnityEngine;

namespace BattleArena.UI
{
    public class ResetFlagsOnAttackEnd : StateMachineBehaviour
    {
        public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            Character character = animator.GetComponent<Character>();
            character.Attack.DecreaseBlockCounter();
        }
    }
}
