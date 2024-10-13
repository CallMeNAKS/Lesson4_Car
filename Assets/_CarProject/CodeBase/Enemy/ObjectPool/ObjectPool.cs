using System;
using System.Collections.Generic;
using UnityEngine;

namespace CodeBase.Enemy.ObjectPool
{
    public class ObjectPool<T> where T : MonoBehaviour
    {
        private readonly Queue<T> _pool = new Queue<T>();
        private readonly T _prefab;
        private readonly Transform _parent;

        public ObjectPool(T prefab, int initialCapacity, Transform parent = null)
        {
            _prefab = prefab;
            _parent = parent;

            for (int i = 0; i < initialCapacity; i++)
            {
                T obj = CreateNewObject();
                ReturnToPool(obj);
            }
        }

        public T CreateNewObject()
        {
            T obj = UnityEngine.Object.Instantiate(_prefab, _parent);
            obj.gameObject.SetActive(false);
            return obj;
        }

        public T GetFromPool()
        {
            if (_pool.Count > 0)
            {
                T obj = _pool.Dequeue();
                obj.gameObject.SetActive(true);
                return obj;
            }
            else
            {
                return CreateNewObject();
            }
        }

        public void ReturnToPool(T obj)
        {
            obj.gameObject.SetActive(false);
            _pool.Enqueue(obj);
        }
    }
}

