using UnityEngine;
using System.Collections;

namespace BattleArena.Characters.Managers
{
    [RequireComponent(typeof(Character))]
    public class CharacterLocomotion : MonoBehaviour
    {
        private Character _character;
        private Coroutine _moveRoutine;

        private void Awake()
        {
            _character = GetComponent<Character>();
        }

        public void MoveToTarget()
        {
            _moveRoutine = StartCoroutine(MoveToTargetCoroutine(_character.AttackTarget.transform, _character.Weapon.weaponData.attackRange, _character.CharacterData.moveSpeed));
        }
        public void StopMove()
        {
            if (_moveRoutine != null)
            {
                StopCoroutine(_moveRoutine);
                _moveRoutine = null;
            }
        }

        private IEnumerator MoveToTargetCoroutine(Transform target, float attackRange, float moveSpeed)
        {
            while (Vector3.Distance(transform.position, target.position) > attackRange)
            {
                Vector3 direction = (_character.AttackTarget.transform.position - transform.position).normalized;
                direction.y = 0;

                if (direction != Vector3.zero)
                {
                    Quaternion targetQuaternion = Quaternion.LookRotation(direction);
                    _character.Rb.MoveRotation(targetQuaternion);
                }

                Vector3 newPosition = transform.position + moveSpeed * Time.fixedDeltaTime * direction;

                _character.Rb.MovePosition(newPosition);

                yield return null;
            }

            _character.StateManager.ChangeState(_character.StateManager.AttackState);
        }
    }
}

