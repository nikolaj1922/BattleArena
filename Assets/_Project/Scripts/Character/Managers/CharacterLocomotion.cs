using System;
using System.Threading;
using UnityEngine;
using Cysharp.Threading.Tasks;


namespace BattleArena.Characters.Managers
{
    [RequireComponent(typeof(Character))]
    public class CharacterLocomotion : MonoBehaviour
    {
        private Character _character;
        private CancellationTokenSource _moveCts;

        private void Awake()
        {
            _character = GetComponent<Character>();
        }

        public void MoveToTarget()
        {
            StopMove();
            MoveToTargetAsync().Forget();
        }

        public void StopMove()
        {
            if (_moveCts != null)
            {
                _moveCts.Cancel();
                _moveCts.Dispose();
                _moveCts = null;
            }
        }

        private async UniTask MoveToTargetAsync()
        {
            _moveCts = new CancellationTokenSource();
            var token = _moveCts.Token;

            try
            {
                await MoveToTargetTaskAsync(
                    _character.AttackTarget.transform,
                    _character.Weapon.Data.attackRange,
                    _character.CharacterData.moveSpeed,
                    token
                );
            }
            catch (OperationCanceledException)
            {

            }
        }

        private async UniTask MoveToTargetTaskAsync(
            Transform target,
            float attackRange,
            float moveSpeed,
            CancellationToken cancellationToken
            )
        {
            while (Vector3.Distance(transform.position, target.position) > attackRange)
            {
                cancellationToken.ThrowIfCancellationRequested();

                Vector3 direction = (_character.AttackTarget.transform.position - transform.position).normalized;
                direction.y = 0;

                if (direction != Vector3.zero)
                {
                    Quaternion targetQuaternion = Quaternion.LookRotation(direction);
                    _character.Rb.MoveRotation(targetQuaternion);
                }

                Vector3 newPosition = transform.position + moveSpeed * Time.fixedDeltaTime * direction;

                _character.Rb.MovePosition(newPosition);

                await UniTask.Yield(PlayerLoopTiming.FixedUpdate, cancellationToken);
            }

        }
    }
}

