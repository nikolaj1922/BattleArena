using BattleArena.Characters;
using UnityEngine;

public class ResetFlagsOnAttackEnd : StateMachineBehaviour
{
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        Character character = animator.GetComponent<Character>();
        character.AttackManager.DecreaseBlockCounter();
    }
}
