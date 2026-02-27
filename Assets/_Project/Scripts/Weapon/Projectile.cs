namespace BattleArena.Weapons
{
    public class Projectile : MonoBehaviour
    {
        public event Action OnHit;

        [SerializeField] private float _speed;
        private Vector3 _direction;
        private float _damage;
        private Character _owner;

        private void Update()
        {
            transform.position += _speed * Time.deltaTime * _direction;
        }

        private void OnTriggerEnter(Collider other)
        {
            var target = other.GetComponent<Character>();

            if (target != null && target != _owner)
            {
                target.TakeDamage(_owner.Attack.GetFinalDamage(_damage));
                OnHit?.Invoke();
                Destroy(gameObject);
            }
        }

        public void Init(Vector3 direction, float damage, Character attacker)
        {
            _direction = direction.normalized;
            _damage = damage;
            _owner = attacker;

            transform.rotation = Quaternion.LookRotation(_direction);
        }

    }
}
