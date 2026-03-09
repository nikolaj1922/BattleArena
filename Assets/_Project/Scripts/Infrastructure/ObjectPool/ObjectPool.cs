using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace BattleArena.Infrastructure.ObjectPool
{
    public class ObjectPool<T> where T : MonoBehaviour
    {
        private readonly T _prefab;
        private readonly List<T> _objects = new();

        public ObjectPool(T prefab)
        {
            _prefab = prefab;
        }

        public T Get()
        {
            var obj = _objects.FirstOrDefault(x => !x.isActiveAndEnabled) ?? Create();

            obj.gameObject.SetActive(true);
            return obj;
        }

        public void Release(T obj)
        {
            obj.gameObject.SetActive(false);
        }

        private T Create()
        {
            T obj = Object.Instantiate(_prefab);
            _objects.Add(obj);
            return obj;
        }
    }
}