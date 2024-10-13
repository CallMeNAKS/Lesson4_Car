using UnityEngine;

namespace CodeBase.Enemy.Factory
{
    public class RedEnemyFactory : AbstractEnemyFactory
    {
        public RedEnemyFactory(AbstractEnemy prefab, int initialCapacity) : base(prefab, initialCapacity) { }

        public override AbstractEnemy CreateEnemy(Vector3 position)
        {
            AbstractEnemy redEnemy = _pool.GetFromPool();
            redEnemy.transform.position = position;
            return redEnemy;
        }
    }
}