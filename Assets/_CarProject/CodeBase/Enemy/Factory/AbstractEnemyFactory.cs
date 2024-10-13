using CodeBase.Enemy.ObjectPool;
using UnityEngine;

namespace CodeBase.Enemy.Factory
{
    public abstract class AbstractEnemyFactory : MonoBehaviour
    {
        protected ObjectPool<AbstractEnemy> _pool;

        public AbstractEnemyFactory(AbstractEnemy prefab, int initialCapacity)
        {
            _pool = new ObjectPool<AbstractEnemy>(prefab, initialCapacity);
        }

        public abstract AbstractEnemy CreateEnemy(Vector3 position);
    }
}